using FarhangbookAPI.Models.Models;
using FarhangbookAPI.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarhangbookAPI.Controllers
{
	public class AccountController : Controller
	{
		private readonly ILoginService _login;
		private readonly IConfiguration _config;

		public AccountController(ILoginService login, IConfiguration config)
		{
			_login = login;
			_config = config;
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				return Redirect("/AdminArea/Home");
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			var result = _login.Login(model);

			if (result.Result == null)
			{
				ViewBag.ErrorMessage = "نام کاربری یا رمز عبور صحیح نیست.";

				return View();
			}

			var claims = new List<Claim>()
			{
                // اندیس شماره 0
                new Claim("Token", result.Result.Token),
                // اندیس شماره 1
                new Claim("Role", result.Result.Roles.ToString()),
                // اندیس شماره 2
                new Claim("UserID", result.Result.UserID),

				new Claim(ClaimTypes.Role, string.Join(",",result.Result.Roles))
			};

			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var principal = new ClaimsPrincipal(identity);

			var properties = new AuthenticationProperties
			{
				IsPersistent = true,
				ExpiresUtc = DateTime.UtcNow.AddHours(1)
			};

			await HttpContext.SignInAsync(principal, properties);

			//return Redirect("https://google.com");

			//_config["JwtTokenValidator"] = claims[0].Value;
			//_config["UserID"] = claims[2].Value;
			//_config["Token"] = claims[0].Value;


			//return RedirectToPage("/Home/Index", new { area = "AdminArea" });

			return Redirect("/AdminArea/Home/Index");
		}

		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction(nameof(Login));
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
