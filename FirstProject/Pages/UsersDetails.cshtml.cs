using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Users;

namespace FirstProject.Pages
{
    public class UsersDetailsModel : PageModel
    {
		public readonly IUsers users;

		public UsersDetailsModel(IUsers _users)
		{
			users = _users;
		}
		public User User { get; set; }
		[BindProperty(SupportsGet =true)]
		public int Id { get; set; }
        public void OnGet()
        {
			User = users.GetUser(Id);
        }
    }
}