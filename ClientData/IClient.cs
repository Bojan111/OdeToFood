using Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientData
{
	public interface IClient
	{
		IEnumerable<Client> GetClient(string name = null);

		Client GetClient(int id);
		Client Update(Client client);
		Client Add(Client client);


		int Commit();
	}
}
