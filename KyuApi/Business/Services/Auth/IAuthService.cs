using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.ViewModels;

namespace KyuApi.Business.Services.Auth
{
	public interface IAuthService
	{
		JwtViewModel Login(string password);
	}
}
