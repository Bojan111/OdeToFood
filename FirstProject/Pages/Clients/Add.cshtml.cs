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
    public class AddModel : PageModel
    {
		private readonly IClient client;
		private readonly IHtmlHelper htmlHelper;

		public IEnumerable<SelectListItem> CityTypes { get; set; }
		public IEnumerable<SelectListItem> CountryTypes { get; set; }
		public AddModel(IClient client, IHtmlHelper htmlHelper)
		{
			this.client = client;
			this.htmlHelper = htmlHelper;
		}
		[BindProperty]
		public Client Client { get; set; }

		public void OnGet(int id)
		{
			Client = new Client();
			Client = client.GetClient(id);
			CountryTypes = htmlHelper.GetEnumSelectList<Country>();
			CityTypes = htmlHelper.GetEnumSelectList<City>();
		}
		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				client.Add(Client);
				//client.Commit();

				return RedirectToPage("./Detail", new { Id = Client.Id });
			}
			CityTypes = htmlHelper.GetEnumSelectList<City>();
			CountryTypes = htmlHelper.GetEnumSelectList<Country>();
			return Page();
		}
	}
}