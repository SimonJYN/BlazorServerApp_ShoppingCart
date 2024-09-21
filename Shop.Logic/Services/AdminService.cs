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
	}
}
