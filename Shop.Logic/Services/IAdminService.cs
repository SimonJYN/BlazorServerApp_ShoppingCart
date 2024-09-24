using Shop.DataModels.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
	public interface IAdminService
	{
		ResponseModel AdminLogin(LoginModel loginModel);
		CategoryModel SaveCategory(CategoryModel categoryModel);
		List<CategoryModel> GetCategories();
		ResponseModel UpdateCategory(CategoryModel categoryModel);
		ResponseModel DeleteCategory(CategoryModel categoryModel);
		
	}
}
