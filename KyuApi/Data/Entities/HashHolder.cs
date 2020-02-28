using System;
using System.Text;
using KyuApi.Business.Utilities;
using KyuApi.Data.Entities.Abstract;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KyuApi.Data.Entities
{
	public class HashHolder : IntEntity
	{
		public string Hash { get; set; }
		public string Salt { get; set; }
	}
}
