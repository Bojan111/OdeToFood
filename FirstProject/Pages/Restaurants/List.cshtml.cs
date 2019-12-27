using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFoodData;
using OdeToFood;
using ClassCore;

namespace FirstProject
{
    public class ListModel : PageModel
    {

		private readonly IConfiguration config;
		private readonly IRestaurantData restaurantData;
		public string Message { get;set; }

		
		[BindProperty(SupportsGet =true)]

		public string SearchTerm { get; set; }

		public IEnumerable<Restoraunt> Restoraunts { get; set; }
		public List<Restoraunt> Restoraunt { get; set; }
		public DateTime Date { get; set; }
		public ListModel(IConfiguration config, IRestaurantData restaurantData)
		{
			this.config = config;
			this.restaurantData = restaurantData;
		}

        public void OnGet(string searchform)
        {
			Message = $"{config ["Message"]} {DateTime.Now}";
			Message = $"{config["Logging:LogLevel:Default"]} {DateTime.Now}";
			Restoraunts = restaurantData.GetAll(SearchTerm);
		}
    }
}