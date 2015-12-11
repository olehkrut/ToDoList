using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
		public virtual ICollection<ToDoItem> Items { get; set; }
    }
}
