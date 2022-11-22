namespace GPSPOIpontok.Models.Domain
{
    public class DataStore
    {
        private List<Map> _maps = new List<Map>();
        public IReadOnlyList<Map> Maps => _maps;
        private DataStore()
        {
        }
        private static DataStore? instance = null;
        public static DataStore Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DataStore();
                }
                return instance;
            }
        }

        public void AddMap(Map map)
        {
            if (!_maps.Contains(map))
            {
                _maps.Add(map);
            }
        }

        public void RemoveMap(Map map)
        {
            if (_maps.Contains(map))
            {
                _maps.Remove(map);
            }
        }
    }
}