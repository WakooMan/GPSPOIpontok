using GPSPOIpontok.Domain;
using GPSPOIpontok.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static GPSPOIpontok.Models.CreateMapViewModel;

namespace GPSPOIpontok.Controllers
{
    public class CreateMapController: Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CreateMapController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View(new CreateMapViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMap(CreateMapViewModel map)
        {
            if (ModelState.IsValid)
            {
                map.ModelService?.ExecuteCommand("CreateMap");
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("Create",map);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
