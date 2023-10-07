using Microsoft.AspNetCore.Mvc;

namespace FarhangbookAPI.Areas.AdminArea.ViewComponents
{
	#region کامپوننت آیتم اطلاعات برنامه و نسخه جاری نرم افزار
	public class TopRightDetailsApplicationViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("TopRightDetailsApplication");
		}
	}
	#endregion

	#region کامپوننت آیتم آیکن ارسال پیامک و ثبت داده جدید
	public class TopLeftSMSForCustomerViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("TopLeftSMSForCustomer");
		}
	}
	#endregion

	#region کامپوننت منوهای سفید سمت راست
	public class AsideRightMenuViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("AsideRightMenu");
		}
	}
	#endregion

	#region کامپوننت منوهای مشکی سمت راست
	public class AsideRightMenuDarkViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("AsideRightMenuDark");
		}
	}
	#endregion

	#region کامپوننت اطلاعات پروفایل کاربر و مدیر سیستم
	public class AsideRightDarkProfileViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("AsideRightDarkProfile");
		}
	}
	#endregion

	#region کامپوننت زیرمنوهای مشکی سمت راست
	public class AsideRightDarkSecondaryMenuViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("AsideRightDarkSecondaryMenu");
		}
	}
	#endregion

	#region کامپوننت آیتم های کپی رایت در قسمت فوتر
	public class ButtomRightCopyRightViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("ButtomRightCopyRight");
		}
	}
	#endregion

	#region کامپوننت آیتم اطلاعات تماس و درباره برنامه
	public class ButtomLeftinformationViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("ButtomLeftinformation");
		}
	}
	#endregion
}
