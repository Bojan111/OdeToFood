using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Customers
{
	public interface IVehicleType
	{
		public IEnumerable<CustomersTypeOfVehicle> GetAll();
	}
	public class VehicleMembers : IVehicleType
	{
		public List<CustomersTypeOfVehicle> _vehicle;

		public VehicleMembers()
		{
			_vehicle = new List<CustomersTypeOfVehicle>
			{
				new CustomersTypeOfVehicle
				{
					Id = 1,
					Model = "Ferrari",
					Color = "Red",
					Year = 2019
				},
				new CustomersTypeOfVehicle
				{
					Id = 2,
					Model = "Range Rover",
					Color = "Silver",
					Year = 2018
				},
				new CustomersTypeOfVehicle
				{
					Id = 3,
					Model = "Rols Royce",
					Color = "Grey",
					Year = 2017
				}
			};
		}

		public IEnumerable<CustomersTypeOfVehicle> GetAll()
		{
			return from r in _vehicle
				   orderby r.Model
				   select r;
		}
	}
}
