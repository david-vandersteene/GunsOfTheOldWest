using GunsOfTheOldWest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GunsOfTheOldWest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GunsFromTheOldWestModel gunModel = new GunsFromTheOldWestModel(12);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WinnaarScherm()
        {
            return View();
        }

        public IActionResult Shoot([FromRoute] int bullets)
        {
            if (bullets <= 0)
            {
                return WinnaarScherm();
            }
            else
            {
                
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}