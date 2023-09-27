using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookAPI.Models.Models
{
	public class LoginModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری وارد نشده است.")]
		public string UserName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = " رمز عبور وارد نشده است.")]
		public string Password { get; set; }
	}
}
