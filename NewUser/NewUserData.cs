using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewUser
{
	public class NewUserData : INewUser
	{

		private List<UserCars> Users;
		public NewUserData()
		{
			Users = new List<UserCars>
			{
				new UserCars
				{
					Id = 1,
					Name = "Bojan",
					LastName = "Kovacevski",
					City = City.Beograd,
					Country = Country.Srbija
				},
				new UserCars
				{
					Id = 2,
					Name = "Nikola",
					LastName = "Petrovski",
					City = City.Kumanovo,
					Country = Country.Makedonija
				},
				new UserCars
				{
					Id = 3,
					Name = "Filip",
					LastName = "Dojcinovski",
					City = City.Zagreb,
					Country = Country.Hrtvatska
				}
			};
		}
		IEnumerable<UserCars> INewUser.GetUsers(string name)
		{
			return Users.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Name);

		}

		UserCars INewUser.GetUsers(int userId)
		{
			return Users.SingleOrDefault(r => r.Id == userId);
		}
	}
}
