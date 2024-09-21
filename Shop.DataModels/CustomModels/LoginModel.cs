using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataModels.CustomModels
{
	public class LoginModel
	{
		public string UserKey { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "*EmailId is Required")] 
		public string EmailId { get; set; }
		[Required(ErrorMessage = "*password is Required")]
		public string Password { get; set; }
	}
}
