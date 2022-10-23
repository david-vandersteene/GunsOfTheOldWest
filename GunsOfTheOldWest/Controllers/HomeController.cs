using GunsOfTheOldWest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GunsOfTheOldWest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GunsFromTheOldWestModel _gunModel;

        public HomeController(ILogger<HomeController> logger, GunsFromTheOldWestModel gunModel)
        {
            _logger = logger;
            _gunModel = gunModel;
        }
        public IActionResult Index()
        {
            Debug.WriteLine(_gunModel.Bullets);
            return View(_gunModel);
        }

        public IActionResult WinnaarScherm()
        {
            return View();
        }

        public IActionResult Shoot(GunsFromTheOldWestModel gunModel)
        {

            if (_gunModel.Bullets <= 0)
            {
                return RedirectToAction("VerkoopScherm");
            }

            Random random = new Random();
            int randomNumber = random.Next(0, 10);
            if (randomNumber <= 3)
            {
                return RedirectToAction("WinnaarScherm");
            }

            _gunModel.Bullets -= 1;

            return RedirectToAction("index");



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VerkoopScherm()
        {
            return View();
        }

        public IActionResult Samenvatting([FromForm] FormCollection form)
        {
            return View(form);
        }
    }
}