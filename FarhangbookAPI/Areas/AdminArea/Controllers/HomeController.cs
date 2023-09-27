using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin, user")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
