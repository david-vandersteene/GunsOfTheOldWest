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
        [HttpGet]
        public IActionResult WinnaarScherm()
        {
            return View();
        }

        public IActionResult Shoot()
        {

            if (_gunModel.Bullets <= 0)
            {
                return RedirectToAction("VerkoopScherm");
            }
            _gunModel.Bullets -= 1;

            Random random = new Random();
            int randomNumber = random.Next(0, 10);
            if (randomNumber <= 3)
            {
                return RedirectToAction("WinnaarScherm");
            }

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

        [HttpPost]
        public IActionResult WinnaarScherm([FromForm] PersonModel form)
        {
            Debug.WriteLine(form.Achternaam);
            form.date = DateTime.UtcNow;
            return RedirectToAction("Samenvatting", form);
        }

        public IActionResult Samenvatting(PersonModel form)
        {
            return View(form);
        }
    }
}