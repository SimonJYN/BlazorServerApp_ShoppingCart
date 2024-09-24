using Microsoft.EntityFrameworkCore;
using Shop.DataModels.CustomModels;
using Shop.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Logic.Services
{
	public class AdminService : IAdminService
	{
		private readonly ShoppingCartDBContext dbContext = null;
		public AdminService(ShoppingCartDBContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public ResponseModel AdminLogin(LoginModel loginModel)
		{
			ResponseModel responseModel = new ResponseModel();
			try
			{
				var data = dbContext.AdminInfos.Where(x => x.Email.Equals(loginModel.EmailId)).FirstOrDefault();
				if (data != null)
				{
					if (data.Password.Equals(loginModel.Password))
					{
						responseModel.Status = true;
						responseModel.Message = $"{data.Id} | {data.Name} | {data.Email}";
					}
					else
					{
						responseModel.Status = false;
						responseModel.Message = "密码错误";
					}
				}
				else
				{
					responseModel.Status = false;
					responseModel.Message = "用户未注册";
				}

				return responseModel;
			}
			catch (Exception)
			{
				responseModel.Status = false;
				responseModel.Message = "发生错误，请再试一次";
				return responseModel;
			}
		}

		public CategoryModel SaveCategory(CategoryModel categoryModel)
		{
			try
			{
				Category _category = new Category();
				_category.Name = categoryModel.Name;
				dbContext.Add(_category);
				dbContext.SaveChanges();

				return categoryModel;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public List<CategoryModel> GetCategories()
		{
			var data = dbContext.Categories.ToList();
			List<CategoryModel> _categoryList = new List<CategoryModel>();
			foreach (var c in data)
			{
				CategoryModel _categoryModel = new CategoryModel();
				_categoryModel.Id = c.Id;
				_categoryModel.Name = c.Name;
				_categoryList.Add(_categoryModel);
			}
			return _categoryList;
		}

		public ResponseModel UpdateCategory(CategoryModel categoryModel)
		{
			ResponseModel responseModel = new ResponseModel();
			try
			{
				var data = dbContext.Categories.Where(x => x.Id.Equals(categoryModel.Id)).First();
				if (data != null)
				{
					data.Name = categoryModel.Name;
					dbContext.Categories.Update(data);
					dbContext.SaveChanges();
					responseModel.Status = true;
					responseModel.Message = "类别更新成功";
				}
				else
				{
					responseModel.Status = false;
					responseModel.Message = "类别不存在";
				}

				return responseModel;
			}
			catch (Exception)
			{
				responseModel.Status = false;
				responseModel.Message = "发生错误，请再试一次";
				return responseModel;
			}
		}

		public ResponseModel DeleteCategory(CategoryModel categoryModel)
		{
			ResponseModel responseModel = new ResponseModel();
			try
			{
				var data = dbContext.Categories.Where(x => x.Id.Equals(categoryModel.Id)).FirstOrDefault();
				if (data != null)
				{
					dbContext.Categories.Remove(data);
					dbContext.SaveChanges();
					responseModel.Status = true;
					responseModel.Message = "类别删除成功:" + categoryModel.Name;
				}
				else
				{
					responseModel.Status = false;
					responseModel.Message = "类别不存在";
				}

				return responseModel;
			}
			catch (Exception)
			{
				responseModel.Status = false;
				responseModel.Message = "发生错误，请再试一次";
				return responseModel;
			}
		}
	}
}
