using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.ViewMap
{
    public class SearchPOICommand : Command
    {
        public override string Name => "SearchPOI";
        public SearchPOICommand()
        {
        }

        public override void Execute()
        {
            if (ViewMapData.Instance.SelectedMap is not null)
            {
                ViewMapData.Instance.POISearchResult = Data.SearchPOI(ViewMapData.Instance.SelectedMap, ViewMapData.Instance.SearchInputText);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}