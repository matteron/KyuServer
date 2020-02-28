using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.Services.Abstract;
using KyuApi.Business.Utilities;
using KyuApi.Business.ViewModels;
using KyuApi.Data.Entities;
using KyuApi.Data.Options;
using KyuApi.Data.Repositories.Interfaces;
using Microsoft.Extensions.Options;

namespace KyuApi.Business.Services.Auth
{
	public class AuthService : ApiService, IAuthService
	{
		private readonly JwtOptions _jwtOptions;
		public AuthService(IRepositoryWrapper repo, IOptions<JwtOptions> jwtOptions) : base(repo)
		{
			_jwtOptions = jwtOptions.Value;
		}

		public JwtViewModel Login(string password)
		{
			var hashHolder = _repo.HashHolder.Query().FirstOrDefault();
			if (hashHolder == null)
			{
				var salt = Crypt.Salt();
				hashHolder = new HashHolder
				{
					Salt = salt,
					Hash = Crypt.Hash(password, salt)
				};
				_repo.HashHolder.CreateSave(hashHolder);
			}
			return Crypt.Validate(password, hashHolder.Salt, hashHolder.Hash)
				? new JwtViewModel { Token = JwtHelper.GenerateToken(_jwtOptions.Secret) }
				: null;
		}

	}
}
