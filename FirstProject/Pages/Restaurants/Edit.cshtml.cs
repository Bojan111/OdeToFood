using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood;
using OdeToFoodData;

namespace FirstProject.Pages.Restaurants
{
    public class EditModel : PageModel
    {
		private readonly IRestaurantData restaurantData;
		private readonly IHtmlHelper htmlHelper;

		public IEnumerable<SelectListItem> CulsineTypes { get; set; }
		public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}
		
		[BindProperty]
		public Restoraunt Restourant { get;  set; }

		public void OnGet(int id)
		{
			CulsineTypes = htmlHelper.GetEnumSelectList<CulsineType>();
			Restourant = restaurantData.GetRestoraunt(id);
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				restaurantData.Update(Restourant);
				restaurantData.Commit();
				TempData["Message"] = "The restaurant is updated";
				return RedirectToPage("./Details", new { Id = Restourant.Id});
			}
			
			CulsineTypes = htmlHelper.GetEnumSelectList<CulsineType>();
		
			return Page();
		}
	}
}