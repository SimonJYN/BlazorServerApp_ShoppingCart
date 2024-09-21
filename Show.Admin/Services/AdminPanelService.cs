using Shop.DataModels.CustomModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace Show.Admin.Services
{
	public class AdminPanelService : IAdminPanelService
	{
		private readonly HttpClient _httpClient;

		public AdminPanelService(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}

		public async Task<ResponseModel> AdminLogin(LoginModel loginModel)
		{
			// Send the login request to the server
			HttpResponseMessage response1 = await _httpClient.PostAsJsonAsync("api/admin/AdminLogin", loginModel);

			// Ensure the request was successful
			//response.EnsureSuccessStatusCode();

			// Deserialize the response content into a ResponseModel object
			ResponseModel responseModel = await response1.Content.ReadFromJsonAsync<ResponseModel>();

			// Return the deserialized response model
			return responseModel;
			try
			{
				// 确保API URL是正确的
				HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/admin/AdminLogin", loginModel);

				// 检查响应状态码
				if (response.IsSuccessStatusCode)
				{
					// 解析响应内容
					return await response.Content.ReadFromJsonAsync<ResponseModel>();
				}
				else
				{
					// 处理不同的状态码
					string errorMessage = "登录失败";
					switch (response.StatusCode)
					{
						case System.Net.HttpStatusCode.Unauthorized:
							errorMessage = "未授权访问，请检查用户名和密码";
							break;
						case System.Net.HttpStatusCode.BadRequest:
							errorMessage = "请求无效，请检查输入的数据";
							break;
							// 根据需要添加更多情况
					}

					// 返回一个错误响应模型
					return new ResponseModel { Message = errorMessage + " : " + response.StatusCode };
				}
			}
			catch (HttpRequestException ex)
			{
				// 记录异常（在这里使用您的日志框架）
				// 例如：_logger.LogError(ex, "登录时发生网络请求错误。");

				// 返回一个通用的错误响应模型或根据您的错误处理策略重新抛出异常
				return new ResponseModel { Message = "网络请求失败，请稍后再试" };
			}
			catch (Exception ex)
			{
				// 记录其他异常
				// 例如：_logger.LogError(ex, "登录时发生意外错误。");

				// 处理其他异常
				throw; // 或者返回一个错误响应模型
			}
		}
	}
}
