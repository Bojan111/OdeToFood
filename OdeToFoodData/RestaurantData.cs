using ClassCore;
using OdeToFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
	public class RestaurantDataInMemory : IRestaurantData
		{
			private List<Restoraunt> restoraunts;
			public RestaurantDataInMemory()
			{
				restoraunts = new List<Restoraunt>
			{
				new Restoraunt
				{
					Id = 1,
					Name = "Dominos",
					Location = "Skopje",
					Culsine = CulsineType.Italian
				},
				new Restoraunt
				{
					Id = 2,
					Name = "Dominos",
					Location = "Skopje",
					Culsine = CulsineType.Italian
				},
				new Restoraunt
				{
					Id = 3,
					Name = "Pomodoro",
					Location = "Skopje",
					Culsine = CulsineType.Italian
				}
			};
			}

		public Restoraunt Add(Restoraunt restoraunt)
		{
			restoraunts.Add(restoraunt);
			return restoraunt;
		}

		public int Commit()
		{
			return 0;
		}

		public Restoraunt Delete(int id)
		{
			var temp = restoraunts.SingleOrDefault(r => r.Id == id);
			if(temp != null)
			{
				restoraunts.Remove(temp);
			}
			return temp;
		}

		public IEnumerable<Restoraunt> GetAll(string name = null)
			{
				return restoraunts.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Id);

			}
			public Restoraunt GetRestoraunt(int id)
			{
				return restoraunts.FirstOrDefault(r => r.Id == id);
			}

		public Restoraunt Update(Restoraunt restoraunt)
		{
			var tempRestaurant = restoraunts.SingleOrDefault(r => r.Id == restoraunt.Id);

			if(tempRestaurant != null)
			{
				tempRestaurant.Name = restoraunt.Name;
				tempRestaurant.Location = restoraunt.Location;
				tempRestaurant.Culsine = restoraunt.Culsine;
			}
			return tempRestaurant;
		}
	}
}
