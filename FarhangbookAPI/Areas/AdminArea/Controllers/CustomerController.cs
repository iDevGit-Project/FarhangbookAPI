using FarhangbookAPI.BussinessLogic.PublicMethod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Claims;
using FarhangbookAPI.Models.ModelDTO;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin, user")]
	public class CustomerController : Controller
	{
		private readonly IConfiguration _config;

		public CustomerController(IConfiguration config)
		{
			_config = config;
		}
		public async Task<IActionResult> Index()
		{
            // مربوط به سرور به صورت لوکال نوشته شده که بعد از پابلیش پروژه می بایست آن را فقط یکبار در این فایل تغییر داد URL جهت تغییر داینامیک آدرس  appsettings در فایل 
            string apiUrl = _config["ApiAddress"] + "CustomerApi/GetCustomers";
            GetListApi GA = new GetListApi();

            // ارسال توکن های معتبر کاربران و دیگر مقادیر به سرور
            string jsonfullmodel = await GA.GetApiList(apiUrl, _config["Token"]);
            dynamic jsondataPars = JObject.Parse(jsonfullmodel);
            var model = JsonConvert.DeserializeObject<List<CustomerDto>>(jsondataPars.data.ToString());

            ViewBag.ApiAddress = _config["ApiAddress"];
            ViewBag.UserID = _config["UserID"];
            ViewBag.Token = _config["JwtTokenValidator"];
            return View(model);
        }
    }
}
