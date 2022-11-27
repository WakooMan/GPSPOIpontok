using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service;
namespace GPSPOIpontok.Models
{
    public class ViewMapViewModel: ViewModelBase
    {
        public Map? SelectedMap { get; set; } = null;
        public POI? SelectedPOI { get; set; } = null;
        public POI? NewPOI { get; set; } = null;
        public IReadOnlyList<POI>? POISearchResult { get; set; } = null;
        public string SearchInputText { get; set; } = "";
        public int SelectedIndex { get; set; } = -1;
        public ViewMapViewModel()
        {
            ModelService = new ViewMapService(this);
        }
    }
}
