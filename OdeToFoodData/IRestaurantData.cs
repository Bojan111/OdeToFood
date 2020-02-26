using ClassCore;
using OdeToFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFoodData
{
	public interface IRestaurantData
	{
		IEnumerable<Restoraunt> GetAll(string name = null);

		Restoraunt GetRestoraunt(int id);
		Restoraunt Update(Restoraunt restoraunt);
		Restoraunt Add(Restoraunt restoraunt);

		int Commit();

		Restoraunt Delete(int id);
	}
}