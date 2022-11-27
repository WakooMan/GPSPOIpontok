using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service;
namespace GPSPOIpontok.Models
{
    public class ViewMapViewModel: ViewModelBase
    {
        public Map SelectedMap { get; }
        public POI? SelectedPOI { get; set; } = null;
        public POI? NewPOI { get; set; } = null;
        public IReadOnlyList<POI>? POISearchResult { get; set; } = null;
        public string SearchInputText { get; set; } = "";
        public ViewMapViewModel(Map map)
        {
            SelectedMap = map;
            ModelService = new ViewMapService(this);
        }
    }
}
