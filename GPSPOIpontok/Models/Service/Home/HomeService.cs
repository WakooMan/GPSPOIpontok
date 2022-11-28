using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Home
{
    public class HomeService : Domain.Service
    {
        public IReadOnlyList<Map> GetMaps() => Data.Maps;
        public Map? SelectedMap => HomeData.Instance.SelectedMap;
        public int? SelectedIndex { get => HomeData.Instance.SelectedIndex; set => HomeData.Instance.SelectedIndex = value; }
        public HomeService()
        {
            commands.Add(new ChooseMapCommand());
        }
    }
}
