using ClassCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Models
{
	public class RestaurantsIndexViewModel
	{
		public IEnumerable<Restoraunt> Restoraunts { get; set; }
		public string SearchTerm { get; set; }

		public string TempMessage { get; set; }
		public string Message { get; set; }
	}
}
