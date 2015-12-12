using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Entities
{
    public class ApplicationUser
    {
		public ApplicationUser()
		{
			Items = new List<ToDoItem>();
		}

		public int ApplicationUserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public virtual ICollection<ToDoItem> Items { get; set; }
    }
}
