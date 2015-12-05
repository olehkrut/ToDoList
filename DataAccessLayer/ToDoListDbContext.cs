using DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class ToDoListDbContext: IdentityDbContext<ApplicationUser>
	{
		public ToDoListDbContext(): 
			base("ToDoListDbContext")
		{
		}

		public DbSet<ToDoItem> ToDoItems { get; set; }

    }
}
