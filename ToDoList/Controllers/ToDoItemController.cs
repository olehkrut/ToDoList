using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using DataAccess.Entities;
using DataAccessLayer;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Data.Entity;

namespace ToDoList.Controllers
{
	public class ToDoItemController : ApiController
	{
        private readonly ToDoListDbContext db = new ToDoListDbContext();

		public IEnumerable<ToDoItem> Get()
		{
			using (ToDoListDbContext context = new ToDoListDbContext())
			{
				var pes = context.ToDoItems.First();
				return context.ToDoItems.ToList();
			}
		}


        public HttpResponseMessage PutTodoItem(int id, ToDoItem todoitem)
        {
            if (ModelState.IsValid && id == todoitem.ToDoItemId)
            {
                db.Entry(todoitem).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostTodoItem(ToDoItem todoitem)
        {
            if (ModelState.IsValid)
            {
                db.ToDoItems.Add(todoitem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, todoitem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = todoitem.ToDoItemId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
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