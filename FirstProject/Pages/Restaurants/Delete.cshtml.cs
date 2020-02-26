using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodData;

namespace FirstProject
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restoraunt Restourant { get; set; }
        
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restourant = restaurantData.GetRestoraunt(id);
            if(Restourant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            var temp = restaurantData.Delete(id);
            if(temp == null)
            {
                return RedirectToPage("./NotFound");
            }
            restaurantData.Commit();
            TempData["Message"] = "The object is deleted";
            return RedirectToPage("./List");
        }
    }
}