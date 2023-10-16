using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin, user")]
	public class HomeController : Controller
	{
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
		{
            ViewBag.UserId = User.FindFirstValue("UserID");
            ViewBag.ApiAddress = _config["ApiAddress"];
            ViewBag.Token = User.FindFirstValue("Token");

            return View();
		}
	}
}
