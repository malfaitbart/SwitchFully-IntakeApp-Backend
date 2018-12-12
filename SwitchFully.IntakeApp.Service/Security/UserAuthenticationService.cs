using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SwitchFully.IntakeApp.Data.Repositories.Users;
using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwitchFully.IntakeApp.Service.Security
{
	public class UserAuthenticationService
	{        // Never store secretive or sensitive information like this (never store them in source-code)
			 // Better approaches for development: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=windows
		public IConfiguration _configuration;

		private readonly UserRepository _userRepository;
		private readonly Hasher _hasher;
		private readonly Salter _salter;

		public UserAuthenticationService(UserRepository userRepository, Hasher hasher, Salter salter, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_hasher = hasher;
			_salter = salter;
			_configuration = configuration;
		}

		public JwtSecurityToken Authenticate(string providedEmail, string providedPassword)
		{
			User foundUser = _userRepository.FindByEmail(providedEmail);
			if (foundUser == null)
			{
				return null;
			}
			if (IsSuccessfullyAuthenticated(providedEmail, providedPassword, foundUser.SecurePassword))
			{
				_userRepository.SetLastLogon(foundUser);
				return new JwtSecurityTokenHandler().CreateToken(CreateTokenDescription(foundUser)) as JwtSecurityToken;
			}
			return null;
		}

		public User GetCurrentLoggedInUser(ClaimsPrincipal principleUser)
		{
			var emailOfAuthenticatedUser = principleUser.FindFirst(ClaimTypes.Email)?.Value;
			return _userRepository.FindByEmail(emailOfAuthenticatedUser);
		}

		public UserSecurity CreateUserSecurity(string userPassword)
		{
			var saltToBeUsed = _salter.CreateRandomSalt();
			return new UserSecurity(
				_hasher.CreateHashOfPasswordAndSalt(userPassword, saltToBeUsed),
				saltToBeUsed);
		}

		private SecurityTokenDescriptor CreateTokenDescription(User foundUser)
		{
			var user = foundUser;
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, foundUser.FirstName),
					new Claim(ClaimTypes.Email, foundUser.Email.Address)
					//new Claim("Role", foundUser.Role.Description)
				}),
				Expires = DateTime.UtcNow.AddHours(8),
				SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(GetSecretKey(_configuration["SecretKey"])), 
                    SecurityAlgorithms.HmacSha256Signature)
			};
			return tokenDescriptor;
		}

		private bool IsSuccessfullyAuthenticated(string providedEmail, string providedPassword, UserSecurity persistedUserSecurity)
		{
			return _hasher.DoesProvidedPasswordMatchPersistedPassword(providedPassword, persistedUserSecurity);
		}

        public static byte[] GetSecretKey(string localSecretKey)
        {
            if (IsSecretKeySetForRemoteServer())
            {
                return Encoding.ASCII.GetBytes(GetSecretKeyForRemoteServer());
            }
            if (IsSecretKeySetForContinuousIntegration())
            {
                return Encoding.ASCII.GetBytes(GetSecretKeyForContinuousIntegration());
            }
            if (IsSecretKeyForLocalDevelopment(localSecretKey))
            {
                return Encoding.ASCII.GetBytes(localSecretKey);
            }
            else
            {
                var errorMessage = "No secret key was found. A secret key needs to be configured: Locally with User Secrets, " +
                    "remotely with Environment variables";
                System.Diagnostics.Trace.TraceError(errorMessage);
                throw new ArgumentException(errorMessage);
            }
        }

        private static bool IsSecretKeyForLocalDevelopment(string localSecretKey)
        {
            return string.IsNullOrEmpty(localSecretKey) != true;
        }

        private static bool IsSecretKeySetForContinuousIntegration()
        {
            return string.IsNullOrEmpty(GetSecretKeyForContinuousIntegration()) != true;
        }

        private static bool IsSecretKeySetForRemoteServer()
        {
            return string.IsNullOrEmpty(GetSecretKeyForRemoteServer()) != true;
        }

        private static string GetSecretKeyForContinuousIntegration()
        {
            return Environment.GetEnvironmentVariable("SecretKey", EnvironmentVariableTarget.Machine);
        }

        private static string GetSecretKeyForRemoteServer()
        {
            return Environment.GetEnvironmentVariable("APPSETTING_SecretKey", EnvironmentVariableTarget.Process);
        }

    }
}
