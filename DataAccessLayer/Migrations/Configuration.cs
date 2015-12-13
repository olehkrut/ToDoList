using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataAccess.Entities;

namespace DataAccessLayer.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ToDoListDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ToDoListDbContext context)
        {
			
        }
    }
}
