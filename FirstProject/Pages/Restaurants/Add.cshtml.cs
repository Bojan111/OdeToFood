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
        public IActionResult OnGet(int? id)
        {
			if (id.HasValue)
			{
				Restoraunt = restaurantData.GetRestoraunt(id.Value);
				if (Restoraunt == null)
				{
					return RedirectToPage("./NotFound");
				}
			}
			else
			{
				Restoraunt = new Restoraunt();
			}
			CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
			return Page();
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				if (Restoraunt.Id == 0)
				{
					Restoraunt = restaurantData.Add(Restoraunt);
					TempData["Message"] = "The Object is created";
				}
				else
				{
					Restoraunt = restaurantData.Update(Restoraunt);
					TempData["Message"] = "The Object is updated";
				}
				restaurantData.Commit();
				return RedirectToPage("./List");
			}
			CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
			return Page();
		}
    }
}