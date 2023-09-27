using MD.PersianDateTime.Standard;

namespace FarhangbookAPI.PublicClasses
{
	public class ConvertDate
	{
		public DateTime ConvertShamsiToMiladi(string Date)
		{
			PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
			return persianDateTime.ToDateTime();
		}

		public string ConvertMiladiToShamsi(DateTime Date, string Format)
		{
			PersianDateTime persianDateTime = new PersianDateTime(Date);
			return persianDateTime.ToString(Format);
		}
	}
}
