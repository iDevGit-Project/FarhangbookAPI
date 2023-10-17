using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin, user")]
	public class HomeController : Controller
	{
        private readonly IConfiguration _config;
		private readonly IToastNotification _toastNotification;

		public HomeController(IConfiguration config, IToastNotification toastNotification)
        {
            _config = config;
			_toastNotification = toastNotification;
		}
        public IActionResult Index()
		{
            ViewBag.UserId = User.FindFirstValue("UserID");
            ViewBag.ApiAddress = _config["ApiAddress"];
            ViewBag.Token = User.FindFirstValue("Token");

			_toastNotification.AddInfoToastMessage("کاربرگرامی: این برنامه در حال حاظر نسخه آزمایشی می باشد.", new NotyOptions()
			{
				ProgressBar = true,
				Timeout = 6000,
				Layout = "topCenter",
				Theme = "metroui"
			});

			return View();
		}
	}
}
