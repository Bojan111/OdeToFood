using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Users
{
	public class UserData : IUsers
	{
		private List<User> users;
		public UserData()
		{
			users = new List<User>
			{
				new User
				{
					Id = 1,
					Name = "Bojan",
					LastName = "Kovachevski",
					Location = "Kumanovo",
					Country = "Macedonia",
					Cars = Cars.FERRARI
				},
				new User
				{
					Id = 2,
					Name = "Nikola",
					LastName = "Stojkov",
					Location = "Kumanovo",
					Country = "Macedonia",
					Cars = Cars.RangeRover
				},
				new User
				{
					Id = 3,
					Name = "Stefan",
					LastName = "Petkovski",
					Location = "Skopje",
					Country = "Macedonia",
					Cars = Cars.Mercedes
				},
				new User
				{
					Id = 4,
					Name = "Dimitar",
					LastName = "Arsovski",
					Location = "Skopje",
					Country = "Macedonia",
					Cars = Cars.BMW
				}
			};
		}

		public IEnumerable<User> GetAll(string name = null)
		{
			return users.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Name);
		}

		public User GetUser(int id)
		{
			return users.FirstOrDefault(r => r.Id == id);
		}
	}
}
