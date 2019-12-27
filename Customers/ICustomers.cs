using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Customers;
using ICustomersssss;

namespace ICustomersssss
{
	public interface ICustomers
	{
		public IEnumerable<Class1> GetAll(string name = null);

		Class1 GetCustomers(int id);
	}
}

namespace Customers
{
	public class CustomerMembers : ICustomers
	{
		private List<Class1> customer;

		public CustomerMembers()
		{
			customer = new List<Class1>
			{
				new Class1
				{
					Id = 1,
					FirstName = "Bojan",
					LastName = "Kovacevski",
					City = "Kumanovo",
					Country = "Macedonia"
				},
				new Class1
				{
					Id = 2,
					FirstName = "Nikola",
					LastName = "Kovacevski",
					City = "Kumanovo",
					Country = "Macedonia"
				},
				new Class1
				{
					Id = 3,
					FirstName = "Stefan",
					LastName = "Petkovski",
					City = "Kumanovo",
					Country = "Macedonia"
				}
			};

		}

		public Class1 GetCustomers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public IEnumerable<Class1> GetAll(string name = null)
		{
			return customer.Where(r => string.IsNullOrEmpty(name) || r.FirstName.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.FirstName);
		}

		Class1 ICustomers.GetCustomers(int id)
		{
			return customer.FirstOrDefault(r => r.Id == id);
		}
	}
}
