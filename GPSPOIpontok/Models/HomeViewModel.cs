using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace GPSPOIpontok.Models
{
    public class HomeViewModel : ViewModelBase
    {
        public Map? SelectedMap { get; set; } = null;
        public string? Image { get; set; } = null;
        public int? SelectedIndex { get; set; } = null;
        public IReadOnlyList<Map> Maps => ModelService is not null?((HomeService)ModelService).GetMaps():new List<Map>();
        public HomeViewModel() 
        {
            ModelService = new HomeService(this);
        }
    }
}
