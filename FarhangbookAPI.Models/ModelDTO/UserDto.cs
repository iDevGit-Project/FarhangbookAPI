using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookAPI.Models.ModelDTO
{
	#region مدل مربوط به کاربران جهت ورود به سیستم
	public class UserModel
	{
		public string Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		//public string UserImage { get; set; }

		public string MelliCode { get; set; }

		public string PersonalCode { get; set; }

		public DateTime BirthDayDate { get; set; }

		public string UserName { get; set; }

		public string PhoneNumber { get; set; }

		public bool GenderSex { get; set; }
		//1 = Admin
		//2 = User
		public byte UserType { get; set; }
	}
	#endregion

	#region مدل مربوط به ورود کاربران به سیستم + توکن اختصاصی
	public class UserLoginDto
	{
		public string UserName { get; set; }
		public string Token { get; set; }
		public string UserID { get; set; }
		public IList<string> Roles { get; set; }
	}
	#endregion
}
