using FarhangbookAPI.Models.ModelDTO;
using FarhangbookAPI.Models.Models;

namespace FarhangbookAPI.Services.Interface
{
	public interface ILoginService
	{
		Task<UserLoginDto> Login(LoginModel request);
	}
}
