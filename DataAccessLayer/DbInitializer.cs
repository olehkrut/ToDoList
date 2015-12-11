using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccessLayer
{
	class DbInitializer: CreateDatabaseIfNotExists<ToDoListDbContext>
	{
		protected override void Seed(ToDoListDbContext context)
		{
			var r = new Random();
			var items = Enumerable.Range(1, 50).Select(o => new ToDoItem
			{
				DueDate = new DateTime(2012, r.Next(1, 12), r.Next(1, 28)),
				Priority = (byte)r.Next(10),
				ToDoContent = o.ToString()
			}).ToArray();
			context.ToDoItems.AddOrUpdate(items);
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}
