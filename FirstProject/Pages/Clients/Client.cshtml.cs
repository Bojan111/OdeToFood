using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientData;
using Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace FirstProject.Pages.Clients
{
    public class ClientModel : PageModel
    {
		private readonly IConfiguration config;
		private readonly IClient client;
	
		public IEnumerable<Client> Clients { get; set; }

		public List<Client> Client { get; set; }

		[BindProperty(SupportsGet = true)]

		public string SearchTerm { get; set; }
		public ClientModel(IClient client)
		{
			this.client = client;
		}
        public void OnGet(string searchform)
        {
			
			Clients = client.GetClient(SearchTerm);
        }
    }
}