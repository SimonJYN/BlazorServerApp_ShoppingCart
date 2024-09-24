using Shop.DataModels.CustomModels;

namespace Show.Admin.Services
{
	public interface IAdminPanelService
	{
		Task<ResponseModel> AdminLogin(LoginModel loginModel);
		Task<CategoryModel> SaveCategory(CategoryModel categoryModel);
		Task<List<CategoryModel>> GetCategories();
		Task<ResponseModel> UpdateCategory(CategoryModel categoryModel);
		Task<ResponseModel> DeleteCategory(CategoryModel categoryModel);
		
	}
}
