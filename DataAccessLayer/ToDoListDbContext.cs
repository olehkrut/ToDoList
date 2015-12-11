using System;
using System.Configuration;
using System.Data.Entity;
using DataAccess.Entities;
using DataAccessLayer.Migrations;

namespace DataAccessLayer
{
	public class ToDoListDbContext: DbContext
	{
		public ToDoListDbContext(): 
			base("ToDoListDbContext")
		{
			Database.SetInitializer(new DbInitializer());
		}

		public DbSet<ToDoItem> ToDoItems { get; set; }
	}
}
