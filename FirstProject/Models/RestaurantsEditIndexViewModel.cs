using ClassCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Models
{
	public class RestaurantsEditIndexViewModel
	{
		public Restoraunt Restaurant { get; set; }
		public IEnumerable<SelectListItem> CulsineTypes { get; set; }
	}
}
