using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service.Home;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class ViewMapData
    {
        public Map? SelectedMap { get; set; } = null;
        public POI? SelectedPOI { get; set; } = null;
        public POI? NewPOI { get; set; } = null;
        public IReadOnlyList<POI>? POISearchResult { get; set; } = null;
        public string SearchInputText { get; set; } = "";
        private ViewMapData() { }
        private static ViewMapData? instance = null;

        public static ViewMapData Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ViewMapData();
                }
                return instance;
            }
        }

        public void Reset()
        {
        }
    }
}
