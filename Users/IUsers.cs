using System;
using System.Collections.Generic;
using System.Text;

namespace Users
{
	public interface IUsers
	{
		IEnumerable<User> GetAll(string name = null);

		User GetUser(int id);
	}
}
