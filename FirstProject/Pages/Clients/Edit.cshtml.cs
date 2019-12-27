using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientData;
using Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProject.Pages.Clients
{
    public class EditModel : PageModel
    {
		private readonly IClient client;
		private readonly IHtmlHelper htmlHelper;

		public IEnumerable<SelectListItem> CityTypes { get; set; }

		public IEnumerable<SelectListItem> CountryTypes { get; set; }
		public EditModel(IClient client, IHtmlHelper htmlHelper)
		{
			this.client = client;
			this.htmlHelper = htmlHelper;
		}

		[BindProperty]
		public Client Client { get;set; }

		public void OnGet(int id)
		{
			CountryTypes = htmlHelper.GetEnumSelectList<Country>();
			CityTypes = htmlHelper.GetEnumSelectList<City>();
			Client = client.GetClient(id);
		}
		public IActionResult OnPost()
		{
			if(ModelState != null)
			{
				client.Update(Client);
				client.Commit();
				TempData["Message"] = "The user is created";
				
			}
			TempData["Message"] = "The user is updated";
			CountryTypes = htmlHelper.GetEnumSelectList<Country>();
			CityTypes = htmlHelper.GetEnumSelectList<City>();
			return Page();
		}
	}
}