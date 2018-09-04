using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using example.Models;

namespace example.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        // GET
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return HttpContext.Response.Headers.Select(h => h.ToString()).ToArray();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
