namespace GPSPOIpontok.Models
{
    public class DataStore
    {
        private List<Map> _maps = new List<Map>();
        public IReadOnlyList<Map> Maps => _maps;
        public DataStore()
        {
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