using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Customers;
using ICustomersssss;

namespace FirstProject.Pages.Customers
{
    public class CustomerPageModel : PageModel
    {

		private readonly ICustomers _customers;
		private readonly IVehicleType _vehicles;
		public IEnumerable<Class1> Customer { get; set; }
		public List<Class1> Customers { get; set; }
		public IEnumerable<CustomersTypeOfVehicle> Vehicle { get; set; }
		public List<CustomersTypeOfVehicle> Vehicles { get; set; }

		[BindProperty(SupportsGet =true)]
		public string SearchTerm { get; set; }
		public CustomerPageModel(ICustomers _customer, IVehicleType _vehicle)
		{
			_customers = _customer;
			_vehicles = _vehicle;
		}
		public void OnGet()
        {
			Customer = _customers.GetAll(SearchTerm);
			Vehicle = _vehicles.GetAll();
        }
    }
}