using System;
using System.Collections.Generic;
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
				context.ToDoItems.Add(new ToDoItem());
				return context.ToDoItems;
			}
			
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
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