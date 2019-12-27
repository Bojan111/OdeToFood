using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodData;

namespace FirstProject.Pages.Restaurants
{
    public class AddModel : PageModel
    {
		private readonly IRestaurantData restaurantData;
		private readonly IHtmlHelper htmlHelper;

		public IEnumerable<SelectListItem> CulsineTypes { get; set; }
		public AddModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) 
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}
		[BindProperty]
		public Restoraunt Restoraunt { get; set; }
        public void OnGet(int id)
        {
			Restoraunt = restaurantData.GetRestoraunt(id);
			CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
        }
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				Restoraunt = restaurantData.Add(Restoraunt);

				return RedirectToPage("./Details", new { Id = Restoraunt.Id });
			}
			CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
			return Page();
		}
    }
}