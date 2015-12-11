using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
		public ApplicationUser()
		{
			Items = new List<ToDoItem>();
		}

		public string Login { get; set; }
		public string Password { get; set; }
		public virtual ICollection<ToDoItem> Items { get; set; }
    }
}
