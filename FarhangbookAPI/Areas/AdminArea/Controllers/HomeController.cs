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

			_toastNotification.AddInfoToastMessage("این برنامه نسخه آزمایشی می باشد.", new ToastrOptions()
			{
				ProgressBar = true,
				Title = "باشگاه مشتریان کتابفروشی فرهنگ",
				TimeOut = 3000,
				PositionClass = ToastPositions.TopCenter
			});

			return View();
		}
	}
}
