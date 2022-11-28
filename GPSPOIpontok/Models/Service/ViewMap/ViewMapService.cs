using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class ViewMapService : Domain.Service
    {
        public Map SelectedMap { get => ViewMapData.Instance.SelectedMap; private set => ViewMapData.Instance.SelectedMap = value; }
        public POI? SelectedPOI { get => ViewMapData.Instance.SelectedPOI; set => ViewMapData.Instance.SelectedPOI = value; }
        public POI? NewPOI { get => ViewMapData.Instance.NewPOI; set=> ViewMapData.Instance.NewPOI = value; }
        public IReadOnlyList<POI>? POISearchResult { get => ViewMapData.Instance.POISearchResult;}
        public string SearchInputText { get=> ViewMapData.Instance.SearchInputText; set=> ViewMapData.Instance.SearchInputText = value; }
        public ViewMapService(Map map) : base()
        {
            SelectedMap = map;
            commands.Add(new AddPOICommand());
            commands.Add(new ReplacePOICommand());
            commands.Add(new SearchPOICommand());
            commands.Add(new RemovePOICommand());
        }
    }
}
