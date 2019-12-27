using System;
using System.Collections.Generic;
using System.Text;

namespace NewUser
{
	public class UserCars
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public City City { get; set; }
		public Country Country { get; set; }
	}
}
