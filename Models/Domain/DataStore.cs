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
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveMap(Map map)
        {
            if (_maps.Contains(map))
            {
                _maps.Remove(map);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddPOI(Map map,POI poi)
        {
            if (_maps.Contains(map))
            {
                map.AddPOI(poi);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ReplacePOI(Map map, POI oldPOI,POI newPOI)
        {
            if (_maps.Contains(map))
            {
                map.ReplacePOI(oldPOI,newPOI);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Map GetMap(int index)
        {
            return _maps[index];
        }

        public void RemovePOI(Map map, POI poi)
        {
            if (_maps.Contains(map))
            {
                map.RemovePOI(poi);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<POI> SearchPOI(Map map,string name)
        {
                if (_maps.Contains(map))
                {
                    return map.PointOfInterests.Where(poi => poi.Name.StartsWith(name)).ToList();
                }
                else
                {
                    throw new ArgumentException();
                }
        }
    }
}