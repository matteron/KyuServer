using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace KyuApi.Business.Utilities
{
	public static class JwtHelper
	{
		public static string GenerateSecret()
		{
			return Crypt.RandomKey(256);
		}

		public static string GenerateToken(string jwtSecret)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var secret = Encoding.ASCII.GetBytes(jwtSecret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, "KyuApiUser"), 
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
