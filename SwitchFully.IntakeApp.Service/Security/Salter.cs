using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SwitchFully.IntakeApp.Service.Security
{
	public class Salter
	{
		public string CreateRandomSalt()
		{
			byte[] randomBytes = new byte[128 / 8];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(randomBytes);
				return Convert.ToBase64String(randomBytes);
			}
		}

	}
}
