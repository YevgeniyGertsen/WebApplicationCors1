using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCors1.Models;

namespace WebApplicationCors1.Controllers
{
    public class User
    {
        public User(string FullName, int Age, DateTime DoB)
        {
            this.FullName = FullName;
            this.Age = Age;
            this.DoB = DoB;
        }
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime DoB { get; set; }
    }

    //[EnableCors("Policy_1")]
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

        //[EnableCors("Policy_1")]
        [AllowCors()]
        public JsonResult GetUser()
        {
            User user = new User("Yevgeniy Gertsen", 25, new DateTime(1988, 01, 11));
            return Json(user);
        }

        [DisableCors]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}