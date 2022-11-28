using GPSPOIpontok.Domain;
using GPSPOIpontok.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;

namespace GPSPOIpontok.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly HomeViewModel Model = new HomeViewModel();

       public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(Model);
        }

        public IActionResult ChooseMap(int index)
        {
            Model.SelectedIndex = index;
            Model.ModelService?.ExecuteCommand("ChooseMap");
            Model.Image = CreateUploadedImage(Model.SelectedMap.Image);
            return View("Index",Model);
        }

        private string CreateUploadedImage(byte[] image)
        {
            string filepath = Path.Combine(webHostEnvironment.WebRootPath,"Map.png");
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                fileStream.Write(image);
            }
            return filepath;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}