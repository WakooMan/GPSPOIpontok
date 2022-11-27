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
            return View(new ErrorMessages());
        }
        [HttpPost]
        public IActionResult CreateMap(CreateMapViewModel map)
        {
            ErrorMessages errors = map.GetErrorMessages();
            if (!errors.HasError())
            {
                map.ModelService?.ExecuteCommand("CreateMap");
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View("Create",errors);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
