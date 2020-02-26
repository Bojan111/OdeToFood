using ClassCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
	public class RestorauntDataSql : IRestaurantData
	{
		private readonly OdeToFoodDbContext odeToFoodDbContext;

		public RestorauntDataSql(OdeToFoodDbContext odeToFoodDbContext)
		{
			this.odeToFoodDbContext = odeToFoodDbContext;
		}

		public Restoraunt Add(Restoraunt restoraunt)
		{
			var restorauntTemp = odeToFoodDbContext.Restaurants.Add(restoraunt);
			return restorauntTemp.Entity;
		}

		public int Commit()
		{
			return odeToFoodDbContext.SaveChanges();
		}

		public Restoraunt Delete(int id)
		{
			var temp = odeToFoodDbContext.Restaurants.SingleOrDefault(r => r.Id == id);
			if(temp != null)
			{
				odeToFoodDbContext.Restaurants.Remove(temp);
			}
			return temp;
		}

		public IEnumerable<Restoraunt> GetAll(string name = null)
		{
			var param = !string.IsNullOrEmpty(name) ? $"{name}" : name;
			return odeToFoodDbContext.Restaurants.Where(r => string.IsNullOrEmpty(name) || EF.Functions.Like(r.Name, param)).ToList();
		}

		public Restoraunt GetRestoraunt(int id)
		{
			return odeToFoodDbContext.Restaurants.SingleOrDefault(r => r.Id == id);
		}

		public Restoraunt Update(Restoraunt restoraunt)
		{
			odeToFoodDbContext.Entry(restoraunt).State = EntityState.Modified;
			return restoraunt;
		}
	}
}
