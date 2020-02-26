using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassCore;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood;
using OdeToFoodData;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
	public class RestaurantsMvcController : Controller
	{
		private readonly IRestaurantData restaurantData;
		private readonly IHtmlHelper htmlHelper;
	

		public RestaurantsMvcController(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}
		public IActionResult Index(string SearchTerm)
		{
			var model = new RestaurantsIndexViewModel();
			//model.Message = $"{config["Message"]} {DateTime.Now}";
			model.Restoraunts = restaurantData.GetAll(SearchTerm);
			return View(model);
		}
		public IActionResult Detail(int Id)
		{
			var restourant = restaurantData.GetRestoraunt(Id);
			if (restourant == null)
			{
				return View("NotFound");
			}
			return View(restourant);
		}
		[HttpGet]
		public IActionResult Edit(int? id)
		{
			var model = new RestaurantsEditIndexViewModel();
			if (id.HasValue)
			{
				 model.Restaurant = restaurantData.GetRestoraunt(id.Value);
				if (model.Restaurant == null)
				{
					return RedirectToPage("./NotFound");
				}
			}
			else
			{
				model.Restaurant = new Restoraunt();
			}
			model.CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(RestaurantsEditIndexViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Restaurant.Id == 0)
				{
					model.Restaurant = restaurantData.Add(model.Restaurant);
					TempData["Message"] = "The Object is created";
				}
				else
				{
					model.Restaurant = restaurantData.Update(model.Restaurant);
					TempData["Message"] = "The Object is updated";
				}
				restaurantData.Commit();
				return RedirectToAction("Index");
			}
			model.CulsineTypes = htmlHelper.GetEnumSelectList<OdeToFood.CulsineType>();
			return View(model);
		}

	}
}
