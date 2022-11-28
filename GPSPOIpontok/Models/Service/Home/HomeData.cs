using GPSPOIpontok.Domain;

namespace GPSPOIpontok.Models.Service.Home
{
    public class HomeData
    {
        public Map? SelectedMap { get; set; } = null;
        public int? SelectedIndex { get; set; } = null;

        private HomeData() { }
        private static HomeData? instance = null;

        public static HomeData Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new HomeData();
                }
                return instance;
            }
        }

        public void Reset()
        {
            SelectedMap = null;
            SelectedIndex = null;
        }
    }

}
