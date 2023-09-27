using FarhangbookAPI.Models.ModelDTO;
using FarhangbookAPI.Models.Models;
using FarhangbookAPI.Services.Interface;

namespace FarhangbookAPI.Services
{
	public class LoginService : ILoginService
	{
		private readonly IConfiguration _config;

		public LoginService(IConfiguration config)
		{
			_config = config;
		}

		public async Task<UserLoginDto> Login(LoginModel request)
		{
			HttpResponseMessage response = null;
			try
			{
				string requestUrl = _config["ApiAddress"] + "AccountApi/Login";
				HttpClient http = new HttpClient();

				// می باشد Json و به صورت Post ارسال اطلاعات از طریق متد 
				response = await http.PostAsJsonAsync(requestUrl, request);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						UserLoginDto result = await response.Content.ReadFromJsonAsync<UserLoginDto>();
						return result;
					}
					catch (System.NotSupportedException ex)
					{
						string msg = ex.Message + " - The Content not Supported";
					}
				}
			}
			catch (HttpRequestException ex1)
			{
				string msg1 = ex1.Message;
			}
			finally
			{
				response.Dispose();
			}
			return default;
		}
	}
}
