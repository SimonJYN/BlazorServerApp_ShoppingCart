using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataModels.CustomModels
{
	public class CategoryModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "*Category is Required")]
		public string Name { get; set; } = string.Empty;
	}
}
