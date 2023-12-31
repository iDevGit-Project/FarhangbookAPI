﻿using FarhangbookAPI.BussinessLogic.PublicMethod;
using FarhangbookAPI.Models.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Claims;

namespace FarhangbookAPI.Areas.AdminArea.Controllers
{
	[Area(nameof(AdminArea))]
	[Authorize(Roles = "admin, user")]
	public class GradeStudentController : Controller
    {
		private readonly IConfiguration _config;

        public GradeStudentController(IConfiguration config)
        {
            _config = config;
        }
		public async Task<IActionResult> Index()
		{

            // مربوط به سرور به صورت لوکال نوشته شده که بعد از پابلیش پروژه می بایست آن را فقط یکبار در این فایل تغییر داد URL جهت تغییر داینامیک آدرس  appsettings در فایل 
            string apiUrl = _config["ApiAddress"] + "GradeStudentsApi/GetGradeStudents";
            GetListApi GA = new GetListApi();

			// ارسال توکن های معتبر کاربران و دیگر مقادیر به سرور
			string jsonfullmodel = await GA.GetApiList(apiUrl, User.FindFirstValue("Token"));

			dynamic jsondataPars = JObject.Parse(jsonfullmodel);
            var model = JsonConvert.DeserializeObject<List<GradeStudentDto>>(jsondataPars.data.ToString());

            ViewBag.UserId = User.FindFirstValue("UserID");
            ViewBag.ApiAddress = _config["ApiAddress"];
            ViewBag.Token = User.FindFirstValue("Token");
            return View(model);
        }
	}
}
