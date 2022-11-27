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

       public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }

        public IActionResult ChooseMap(HomeViewModel model,int index)
        {
            model.SelectedIndex = index;
            model.ModelService?.ExecuteCommand("ChooseMap");

            model.Image = CreateUploadedImage(model.SelectedMap.Image);
            return View("Index",model);
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