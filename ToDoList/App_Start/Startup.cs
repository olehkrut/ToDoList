using System.Web.Http;
using Microsoft.Owin;
using Owin;
using ToDoList;

[assembly: OwinStartup(typeof(Startup))]
namespace ToDoList
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
			app.UseWebApi(config);
		}
	}
}