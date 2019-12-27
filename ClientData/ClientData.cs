using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clients;

namespace ClientData
{
	public class ClientData : IClient
	{
		private List<Client> clients;
		public ClientData()
		{
			clients = new List<Client>
			{
				new Client
				{
					Id = 1,
					Name = "Bojan",
					LastName = "Kovacevski",
					City = City.Beograd,
					Country = Country.Srbija
				},
				new Client
				{
					Id = 2,
					Name = "Stefan",
					LastName = "Krstevski",
					City = City.Kumanovo,
					Country = Country.Makedonija
				},
				new Client
				{
					Id = 3,
					Name = "Nikola",
					LastName = "Petkovski",
					City = City.Zagreb,
					Country = Country.Hrtvatska
				}
			};
		}

	

		IEnumerable<Client> IClient.GetClient(string name)
		{
			return clients.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Id);
		}

		Client IClient.GetClient(int id)
		{
			return clients.SingleOrDefault(r => r.Id == id);
		}

		public Client Update(Client client)
		{
			var tempClient = clients.SingleOrDefault(r => r.Id == client.Id);

			if(tempClient != null)
			{
				tempClient.Id = client.Id;
				tempClient.Name = client.Name;
				tempClient.LastName = client.LastName;
				tempClient.City = client.City;
				tempClient.Country = client.Country;
			}
			return tempClient;
		}

		public int Commit()
		{
			return 0;
		}

		public Client Add(Client client)
		{
			
			clients.Add(client);
			return client;
		}

		
	}
}
