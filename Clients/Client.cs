using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clients
{
	public class Client
	{
		public int Id { get; set; }
		[Required, StringLength(10)]
		public string Name { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public City City { get; set; }
		[Required]
		public Country Country { get; set; }
	}
}
