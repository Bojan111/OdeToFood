using System;
using System.Collections.Generic;
using System.Text;

namespace Users
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public string Country { get; set; }

		public Cars Cars { get; set; }
	}
}
