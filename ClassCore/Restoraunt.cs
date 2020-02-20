using OdeToFood;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassCore
{
	public class Restoraunt 
	{
		public int Id { get; set; }
		[Required]
		[StringLength(10)]
		public string Name { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public CulsineType Culsine { get; set; }

		
	}
}
