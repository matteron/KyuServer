using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KyuApi.Business.Utilities
{
	public static class Crypt
	{
		public static string Hash(string value, string salt)
		{
			var valueBytes = KeyDerivation.Pbkdf2(
				password: value,
				salt: Encoding.UTF8.GetBytes(salt),
				prf: KeyDerivationPrf.HMACSHA512,
				iterationCount: 100000,
				numBytesRequested: 256 / 8
			);
			return Convert.ToBase64String(valueBytes);
		}

		public static string RandomKey(int bits)
		{
			var bytes = new byte[bits / 8];
			using var generator = RandomNumberGenerator.Create();
			generator.GetBytes(bytes);
			return Convert.ToBase64String(bytes);
		}

		public static string Salt()
		{
			return RandomKey(128);
		}

		public static bool Validate(string value, string salt, string hash) => Hash(value, salt) == hash;
	}
}
