using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers;
using ICustomersssss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstProject.Pages.Customers
{
    public class CustomersDetailsModel : PageModel
    {
		public readonly ICustomers customers;

		public CustomersDetailsModel(ICustomers _customer)
		{
			customers = _customer;
		}

		[BindProperty(SupportsGet =true)]
		public int Id { get; set; }

		public Class1 Customers { get; set; }

		public IActionResult OnGet()
        {
			Customers = customers.GetCustomers(Id);
			if(Customers == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
        }
    }
}