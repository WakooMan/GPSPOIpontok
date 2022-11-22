using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service;

namespace GPSPOIpontok.Models
{
    public class ViewMapViewModel
    {
        private readonly ViewMapService Service;
        public Map? SelectedMap { get; set; } = null;
        public POI? SelectedPOI { get; set; } = null;
        public POI? NewPOI { get; set; } = null;
        public IReadOnlyList<POI>? POISearchResult { get; set; } = null;
        public string SearchInputText { get; set; } = "";
        public int SelectedIndex { get; set; } = -1;
        public ViewMapViewModel()
        {
            Service = new ViewMapService(this);
        }
    }
}
