using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service.ViewMap;

namespace GPSPOIpontok.Models
{
    public class ViewMapViewModel: ViewModelBase
    {
        private readonly ViewMapService viewMapService;
        public Map SelectedMap { get => viewMapService.SelectedMap; }
        public POI? SelectedPOI { get=> viewMapService.SelectedPOI; set=> viewMapService.SelectedPOI = value; }
        public POI? NewPOI { get => viewMapService.NewPOI; set=> viewMapService.NewPOI=value; }
        public IReadOnlyList<POI>? POISearchResult { get=> viewMapService.POISearchResult; }
        public string SearchInputText { get=> viewMapService.SearchInputText; set=> viewMapService.SearchInputText=value; }
        public ViewMapViewModel(Map map)
        {
            viewMapService = new ViewMapService(map);
            ModelService = viewMapService;
        }
    }
}
