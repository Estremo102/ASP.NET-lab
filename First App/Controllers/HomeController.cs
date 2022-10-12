using First_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace First_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Hello()
        {
            //var accept = Request.Headers["Accept"];
            //return $"Hello with header [Accept] = {accept}";
            string name = Request.Query["name"];
            string age = Request.Query["age"];
            //Stream body = Request.Body;
            if (int.TryParse(age, out var intAge))
            {
                int currentYear = DateTime.Now.Year;
                return $"Hello {name}, your birth year is {currentYear - intAge}.";
            }
            else
            {
                Response.StatusCode = 400;
                return "";
            }

        }

        public string Calc([FromQuery] int? age, [FromQuery] string name)
        {
            if (age != null)
            {
                int currentYear = DateTime.Now.Year;
                return $"Hello {name}, your birth year is {currentYear - age}.";
            }
            else
            {
                Response.StatusCode = 400;
                return "";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}