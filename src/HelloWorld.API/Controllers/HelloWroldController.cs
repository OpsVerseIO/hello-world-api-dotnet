using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
	public class HelloWorldController : BaseApiController
	{
		public HelloWorldController() {}

		[HttpGet("/hello")]
		public async Task<string> HelloWorld()
		{
            return "Hello World";
		}
    }
}		