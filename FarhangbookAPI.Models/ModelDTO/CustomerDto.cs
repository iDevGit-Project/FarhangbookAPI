using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarhangbookAPI.Models.ModelDTO
{
	public class CustomerDto
	{
		public int CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Mobile { get; set; }

        // تعیین نوع مشتری
        public int TypeCustomerID { get; set; }

		// پایه تحصیلی دانش آموز
		public int GradeStudentID { get; set; }

		public DateTime BirthdayDate { get; set; }

		// کد اشتراک
		public int CodeCustomer { get; set; }
		public string Address { get; set; }
		public virtual TypeCustomerDto TypeCustomer { get; set; }
		public virtual GradeStudentDto GradeStudent { get; set; }
	}

	public class CustomerForDropDown
	{
		public int DrId { get; set; }
		public string DrName { get; set; }
	}
}
