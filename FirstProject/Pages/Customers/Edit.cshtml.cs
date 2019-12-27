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
    public class EditModel : PageModel
    {
		private readonly ICustomers customers;

		public EditModel(ICustomers customers)
		{
			this.customers = customers;
		}


		public Class1 Customer { get; private set; }

		public void OnGet(int id)
		{
			Customer = customers.GetCustomers(id);
		}
	}
}
