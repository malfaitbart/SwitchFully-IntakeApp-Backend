using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.Text;

namespace SwitchFully.IntakeApp.Service.Security
{
	public class Hasher
	{
		public string CreateHashOfPasswordAndSalt(string userPassword, string salt)
		{
			return Convert.ToBase64String(GenerateHashOfPasswordAndSalt(userPassword, salt));
		}

		private byte[] GenerateHashOfPasswordAndSalt(string userPassword, string salt)
		{
			return KeyDerivation.Pbkdf2(
				password: userPassword,
				salt: Encoding.UTF8.GetBytes(salt),
				prf: KeyDerivationPrf.HMACSHA512,
				iterationCount: 10000,
				numBytesRequested: 256 / 8);
		}

		public bool DoesProvidedPasswordMatchPersistedPassword(string providedPassword, UserSecurity persistedUserSecurity)
		{
			return CreateHashOfPasswordAndSalt(providedPassword, persistedUserSecurity.Salt)
				.Equals(persistedUserSecurity.PasswordHash);
		}

	}
}
