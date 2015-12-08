using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using DataAccess.Entities;
using DataAccessLayer;

namespace ToDoList.Controllers
{
	public class ToDoItemController : ApiController
	{
		public IEnumerable<ToDoItem> Get()
		{
			using (ToDoListDbContext context = new ToDoListDbContext())
			{
				var pes = context.ToDoItems.First();
				return context.ToDoItems.ToList();
			}
		}


		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}