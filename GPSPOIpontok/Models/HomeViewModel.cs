using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service.Home;

namespace GPSPOIpontok.Models
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly HomeService homeService;
        public Map? SelectedMap { get => homeService.SelectedMap; }
        public string? Image { get; set; } = null;
        public int? SelectedIndex { get => homeService.SelectedIndex; set =>homeService.SelectedIndex = value; }
        public IReadOnlyList<Map> Maps => ModelService is not null?((HomeService)ModelService).GetMaps():new List<Map>();
        public HomeViewModel() 
        {
            homeService = new HomeService();
            ModelService = homeService;
        }
    }
}
