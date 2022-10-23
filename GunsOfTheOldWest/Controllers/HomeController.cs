using GunsOfTheOldWest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GunsOfTheOldWest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GunsFromTheOldWestModel _gunModel = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            Debug.WriteLine("Index");
            Debug.WriteLine(_gunModel.Bullets);
            return View(_gunModel);
        }

        public IActionResult WinnaarScherm()
        {
            return View();
        }

        public IActionResult Shoot()
        {

            if (_gunModel.Bullets <= 0)
            {
                return RedirectToAction("WinnaarScherm");
            }

            _gunModel.Bullets -= 1;
            Debug.WriteLine(_gunModel.Bullets);

            return View("index", _gunModel);



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}