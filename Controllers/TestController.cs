using Microsoft.AspNetCore.Mvc;

namespace poc_distributedcache.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [Route("write-session")]
        public IActionResult TestWriteSession()
        {
            var value = $"Session written at {DateTime.UtcNow.ToString()}";
            HttpContext.Session.SetString("Test", value);
            return Content($"Wrote {value}");
        }

        [HttpGet]
        [Route("/read-session")]
        public IActionResult TestReadSession()
        {
            var value = HttpContext.Session.GetString("Test");
            return Content($"Read {value}");
        }
    }
}
