using DataAccess.Entities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [Route("login")]
        public IHttpActionResult LoginUser(LoginUserModel model)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                ApplicationUser user =
                    context.Users
                    .Where(u => u.UserName == model.UserName && u.Password == model.Password)
                    .FirstOrDefault();
                if (user != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Wrong username or password");
                }
            }
        }

        [Route("register")]
        public IHttpActionResult RegisterUser(RegisterUserModel model)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Some fields are empty");
                }
                ApplicationUser user =
                    context.Users
                    .Where(u => u.UserName == model.UserName && u.Password == model.Password)
                    .FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("Such user already exist, change username or password");
                }
                user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Password = model.Password
                };
                context.Users.Add(user);
                context.SaveChanges();
                return Ok();
            }
        }

        [Route("search")]
        public IHttpActionResult Search(string description)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
		    	{
		    		var items =
		    			context.ToDoItems
		    			.Where(u => u.ToDoContent.Contains(description));
		    			
		    		if (items != null)
		    		{
		    			return Ok(items);
		    		}
		    		else
		    		{
		    			return BadRequest("Nothing");
		    		}
		    	}
          }

    }
}