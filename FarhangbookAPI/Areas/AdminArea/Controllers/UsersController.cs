using FarhangbookAPI.Models.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Claims;
using FarhangbookAPI.BussinessLogic.PublicMethod;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin")]
	public class UsersController : Controller
	{
		private readonly IConfiguration _config;

		public UsersController(IConfiguration config)
		{
			_config = config;
		}

		public async Task<IActionResult> Index()
		{
			string apiUrl = _config["ApiAddress"] + "UsersApi/GetUsers";
			GetListApi GA = new GetListApi();

			// ارسال توکن های معتبر کاربران و دیگر مقادیر به سرور
			string jsonfullmodel = await GA.GetApiList(apiUrl, _config["JwtTokenValidator"]);

			dynamic jsondataPars = JObject.Parse(jsonfullmodel);
			var model = JsonConvert.DeserializeObject<List<UserModel>>(jsondataPars.data.ToString());

            ViewBag.UserId = User.FindFirstValue("UserID");
            ViewBag.ApiAddress = _config["ApiAddress"];
            ViewBag.Token = User.FindFirstValue("Token");
            return View(model);
		}
	}
}
