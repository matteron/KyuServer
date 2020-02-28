using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.Services.Auth;
using KyuApi.Business.ViewModels.Requests;
using KyuApi.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers
{
	public class AuthController : CustomController
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost]
		public IActionResult Login([FromBody]LoginRequest req)
		{
			var result = _authService.Login(req.Password);
			if (result == null)
			{
				return BadRequest("Login Failed");
			}

			return Ok(result);
		}
	}
}
