using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Users;

namespace FirstProject.Pages
{
    public class UsersModel : PageModel
    {
		private readonly IUsers users;
		public IEnumerable<User> Users { get; set; }
		public UsersModel(IUsers _user)
		{
			users = _user;
		}

		[BindProperty(SupportsGet =true)]
		public string SearchTerm { get; set; }
		public void OnGet()
        {
			Users = users.GetAll(SearchTerm);
        }
    }
}