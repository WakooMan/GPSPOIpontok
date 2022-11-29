using GPSPOIpontok.Domain;
using GPSPOIpontok.Models;
using GPSPOIpontok.Models.Service.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static GPSPOIpontok.Models.CreateMapViewModel;

namespace GPSPOIpontok.Controllers
{
    public class MapController: Controller
    {
        private readonly ILogger<MapController> _logger;
        private readonly ViewMapViewModel ViewMapModel;

        public MapController(ILogger<MapController> logger)
        {
            _logger = logger;
            ViewMapModel = new ViewMapViewModel(HomeData.Instance.SelectedMap);
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

        private IActionResult GetResult(POIModel? model)
        {
            ViewBag.Model = ViewMapModel;
            return View("ViewMap",model);
        }

        public IActionResult ViewMap()
        {
            return GetResult(new POIModel());
        }
        [HttpPost]
        public IActionResult AddNewPOIForm([FromBody]Coordinate coord)
        {
            ViewMapModel.SelectedPOI = new POI(ViewMapModel.SelectedMap,coord,"","",null,null);
            POIModel model = new POIModel();
            model.Latitude = coord.Latitude.ToString().Replace(',','.');
            model.Longitude = coord.Longitude.ToString().Replace(',', '.');
            return GetResult(model);
        }
        [HttpPost]
        public IActionResult ModifyPOIForm([FromBody] Coordinate coord)
        {
            ViewMapModel.SelectedPOI = ViewMapModel.SelectedMap.PointOfInterests.FirstOrDefault(p=>Math.Abs(p.Coordinate.Latitude-coord.Latitude)<0.0001 && Math.Abs(p.Coordinate.Longitude - coord.Longitude)<0.0001);
            if (ViewMapModel.SelectedPOI is not null)
            {
                POIModel model = new POIModel();
                model.Latitude = ViewMapModel.SelectedPOI.Coordinate.Latitude.ToString().Replace(',', '.');
                model.Longitude = ViewMapModel.SelectedPOI.Coordinate.Longitude.ToString().Replace(',', '.');
                model.Name = ViewMapModel.SelectedPOI.Name;
                model.Category = ViewMapModel.SelectedPOI.Category;
                model.Description = ViewMapModel.SelectedPOI.Description;
                return GetResult(model);
            }
            else
            {
                return GetResult(new POIModel());
            }
        }

        [HttpPost]
        public IActionResult ReplaceSelectedPOI([FromBody]Coordinate coord)
        {
            POIModel model = new POIModel();
            model.Latitude = coord.Latitude.ToString().Replace(',', '.');
            model.Longitude = coord.Longitude.ToString().Replace(',', '.');
            model.Name = ViewMapModel.SelectedPOI.Name;
            model.Category = ViewMapModel.SelectedPOI.Category;
            model.Description = ViewMapModel.SelectedPOI.Description;
            return GetResult(model);
        }

        [HttpPost]
        public IActionResult RemovePOI(POIModel Model)
        {
            ViewMapModel.ModelService.ExecuteCommand("RemovePOI");
            ViewMapModel.SelectedPOI = null;
            return GetResult(new POIModel());
        }

        [HttpPost]
        public IActionResult ModifyPOI(POIModel Model)
        {
            if (ModelState.IsValid)
            {
                byte[]? image = null;
                if (Model.Image is not null)
                {
                    var stream = new MemoryStream();
                    Model.Image.CopyTo(stream);
                    image = stream.ToArray();
                }
                ViewMapModel.NewPOI = new POI(ViewMapModel.SelectedMap,new Coordinate(double.Parse(Model.Latitude.Replace('.',',')),double.Parse(Model.Longitude.Replace('.',','))),Model.Name,Model.Description,Model.Category,image);
                ViewMapModel.NewPOI.Id = ViewMapModel.SelectedPOI.Id;
                ViewMapModel.ModelService.ExecuteCommand("ReplacePOI");
                ViewMapModel.SelectedPOI = null;
                ViewMapModel.NewPOI = null;
                return GetResult(new POIModel());
            }
            else
            {
                return GetResult(Model);
            }
        }

        [HttpPost]
        public IActionResult AddPOI(POIModel Model)
        {
            if (ModelState.IsValid)
            {
                if (Model.Image is not null)
                {
                    var stream = new MemoryStream();
                    Model.Image.CopyTo(stream);
                    ViewMapModel.SelectedPOI.Image = stream.ToArray();
                }
                ViewMapModel.SelectedPOI.Description = Model.Description;
                ViewMapModel.SelectedPOI.Category = Model.Category;
                ViewMapModel.SelectedPOI.Name = Model.Name;
                ViewMapModel.ModelService.ExecuteCommand("AddPOI");
                ViewMapModel.SelectedPOI = null;
                return GetResult(new POIModel());
            }
            else
            {
                return GetResult(Model);
            }
        }
        [HttpPost]
        public IActionResult DeleteSelectedPOI(POIModel Model)
        {
            ViewMapModel.SelectedPOI = null;
            return GetResult(new POIModel());
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
