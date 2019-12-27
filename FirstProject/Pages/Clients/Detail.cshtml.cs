using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientData;
using Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstProject.Pages.Clients
{
    public class DetailModel : PageModel
    {
		private readonly IClient client;

		public DetailModel(IClient client)
		{
			this.client = client;
		}
		[BindProperty(SupportsGet = true)]
		public int Id { get; set; }

		public Client Client { get; private set; }
		[TempData]
		public string Message { get; set; }
		public IActionResult OnGet()
		{
			Client = client.GetClient(Id);
			if (Client == null)
			{
				return RedirectToPage("./NotFound");
			}

			return Page();
		}
	}
}