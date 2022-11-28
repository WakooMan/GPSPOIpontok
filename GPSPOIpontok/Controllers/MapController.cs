using GPSPOIpontok.Domain;
using GPSPOIpontok.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static GPSPOIpontok.Models.CreateMapViewModel;

namespace GPSPOIpontok.Controllers
{
    public class MapController: Controller
    {
        private readonly ILogger<MapController> _logger;
        private ViewMapViewModel ViewMapModel;

        public MapController(ILogger<MapController> logger)
        {
            _logger = logger;
        }
        #region Map Addition
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
        #endregion

        #region Map View
        public IActionResult ViewMap(Map map)
        {
            ViewMapModel = new ViewMapViewModel(map);
            return View(ViewMapModel);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
