using System;
using System.Data.Entity;
using DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

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
