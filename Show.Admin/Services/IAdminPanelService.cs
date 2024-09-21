using Shop.DataModels.CustomModels;

namespace Show.Admin.Services
{
	public interface IAdminPanelService
	{
		Task<ResponseModel> AdminLogin(LoginModel loginModel);
	}
}
