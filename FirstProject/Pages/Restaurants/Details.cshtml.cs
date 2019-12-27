using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodData;

namespace FirstProject.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
		private readonly IRestaurantData restaurantData;

		public DetailsModel(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}
		[BindProperty(SupportsGet =true)]
		public int Id { get; set; }
		[TempData]
		public string Message { get; set; }
		public Restoraunt Restourant { get; private set; }

		public IActionResult OnGet()
		{
			
			Restourant = restaurantData.GetRestoraunt(Id);
			if(Restourant == null)
			{
				return RedirectToPage("./NotFound");
			}

			return Page();
		}
	}
}