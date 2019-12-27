using System;
using System.Collections.Generic;
using System.Text;

namespace NewUser
{
	public	interface INewUser
	{
		IEnumerable<UserCars> GetUsers(string name = null);
		UserCars GetUsers(int userId);
	}
}
