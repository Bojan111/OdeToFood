using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFoodType
{
	public interface ICustomers
	{
		IEnumerable<Class1> GetAll();
	}

	public class Customers : ICustomers
	{
		private List<Class1> _customer;
		
		public Customers()
		{
			_customer = new List<Class1>
			{
				new Class1
				{
					Id = 1,
					FirstName = "Goran",
					LastName = "Cvetkovski",
					City = "Skopje",
					Country = "Macedonia"
				},
				new Class1
				{
					Id = 2,
					FirstName = "Bojan",
					LastName = "Kovachevski",
					City = "Skopje",
					Country = "Macedonia"
				},
				new Class1
				{
					Id = 3,
					FirstName = "Bojan",
					LastName = "Kovachevski",
					City = "Skopje",
					Country = "Macedonia"
				}

			};
		}


		public IEnumerable<Class1> GetAll()
		{
			return from r in _customer
				   orderby r.City
				   select r;

		}
	}

	
}
