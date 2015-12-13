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
using ToDoList.Models;

namespace ToDoList.Controllers
{
	[RoutePrefix("api/toDoItem")]
	public class ToDoItemController : ApiController
	{

		public IEnumerable<ToDoItemModel> Get(int userId)
		{
			using (ToDoListDbContext context = new ToDoListDbContext())
			{
				var listik = context.ToDoItems.Where(td => td.UserId == userId).ToList<ToDoItem>()
					.Select(td => Map(td));
				return listik;
			}
		}

		private ToDoItemModel Map(ToDoItem item)
		{
			return new ToDoItemModel
			{
				ToDoContent = item.ToDoContent,
				ToDoItemId = item.ToDoItemId,
				DueDate = item.DueDate,
				Priority = item.Priority
			};
		}

		public ToDoItem GetToDoItem(int itemId)
		{
			using (ToDoListDbContext context = new ToDoListDbContext())
			{
				return context.ToDoItems.Where(td => td.ToDoItemId == itemId).FirstOrDefault();
			}
		}

		[Route("edit")]
		public IHttpActionResult EditTodoItem(ToDoItem todoitem)
		{
			if (ModelState.IsValid)
			{
				using (ToDoListDbContext db = new ToDoListDbContext())
				{
					db.Entry(todoitem).State = EntityState.Modified;

					try
					{
						db.SaveChanges();
					}
					catch (DbUpdateConcurrencyException)
					{
						return NotFound();
					}

					return Ok();
				}
			}
			else
			{
				return BadRequest();
			}
		}

		[Route("createItem")]
		public IHttpActionResult PostTodoItem(ToDoItem todoitem)
		{

			if (ModelState.IsValid)
			{
				using (ToDoListDbContext db = new ToDoListDbContext())
				{
					db.ToDoItems.Add(todoitem);
					db.SaveChanges();

					return Ok();
				}
			}
			else
			{
				return BadRequest();
			}
		}
	}
}