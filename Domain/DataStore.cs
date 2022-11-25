using Domain.Database;

namespace GPSPOIpontok.Domain
{
    public class DataStore
    {
        private readonly List<Map> _maps = new List<Map>();
        private readonly Adatok Data = new Adatok();
        public IReadOnlyList<Map> Maps => _maps;
        private DataStore()
        {
            foreach (Dbmap map in Data.Dbmaps)
            {
                Map m = new Map(map.Name, Enum.Parse<Direction>(map.Direction), new Ratio(map.Lesser, map.Greater), new Coordinate(map.MinCoordinateLatitude, map.MinCoordinateLongitude), new Coordinate(map.MaxCoordinateLatitude, map.MaxCoordinateLongitude), map.Image);
                m.Id = map.MapId;
                foreach (Dbpoi poi in map.Dbpois)
                {
                    POI p = new POI(m, new Coordinate(poi.Latitude, poi.Longitude), poi.Name, poi.Description, poi.Category, poi.Image);
                    p.Id = poi.Poiid;
                    m.AddPOI(p);
                }
                _maps.Add(m);
            }
        }
        private static DataStore? instance = null;
        internal static DataStore Instance
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
                Dbmap m = new Dbmap();
                m.Name = map.Name;
                m.Direction = map.MapDirection.ToString();
                m.Lesser = map.MapRatio.Lesser;
                m.Greater = map.MapRatio.Greater;
                m.MinCoordinateLatitude = map.MinimumCoordinate.Latitude;
                m.MinCoordinateLongitude = map.MinimumCoordinate.Longitude;
                m.MaxCoordinateLatitude = map.MaximumCoordinate.Latitude;
                m.MaxCoordinateLongitude = map.MaximumCoordinate.Longitude;
                m.Image = map.Image;
                Data.Dbmaps.Add(m);
                Data.SaveChanges();
                map.Id = m.MapId;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveMap(Map map)
        {
            Dbmap? dbmap = Data.Dbmaps.FirstOrDefault(m => map.Id == m.MapId);
            if (_maps.Contains(map) && _maps.Any(m => m.Id == map.Id) && dbmap is not null)
            {
                _maps.Remove(map);
                Data.Dbmaps.Remove(dbmap);
                Data.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddPOI(Map map, POI poi)
        {
            Dbmap? dbmap = Data.Dbmaps.FirstOrDefault(m => m.MapId == map.Id);
            if (_maps.Contains(map) && dbmap is not null)
            {
                if (map.AddPOI(poi))
                {
                    Dbpoi p = new Dbpoi();
                    p.MapId = map.Id;
                    p.Map = dbmap;
                    p.Name = poi.Name;
                    p.Category = poi.Category;
                    p.Description = poi.Description;
                    p.Image = poi.Image;
                    p.Latitude = poi.Coordinate.Latitude;
                    p.Longitude = poi.Coordinate.Longitude;
                    Data.Dbpois.Add(p);
                    Data.SaveChanges();
                    poi.Id = p.Poiid;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ReplacePOI(Map map, POI oldPOI, POI newPOI)
        {
            Dbmap? dbmap = Data.Dbmaps.FirstOrDefault(m => m.MapId == map.Id);
            Dbpoi? dbpoi = Data.Dbpois.FirstOrDefault(p => p.Poiid == oldPOI.Id);
            if (_maps.Contains(map) && dbmap is not null && dbpoi is not null)
            {
                if (map.ReplacePOI(oldPOI, newPOI))
                {
                    if (dbpoi.Name != newPOI.Name)
                    {
                        dbpoi.Name = newPOI.Name;
                    }
                    if (dbpoi.Category != newPOI.Category)
                    {
                        dbpoi.Category = newPOI.Category;
                    }
                    if (dbpoi.Description != newPOI.Description)
                    {
                        dbpoi.Description = newPOI.Description;
                    }
                    if (dbpoi.Latitude != newPOI.Coordinate.Latitude)
                    {
                        dbpoi.Latitude = newPOI.Coordinate.Latitude;
                    }
                    if (dbpoi.Longitude != newPOI.Coordinate.Longitude)
                    {
                        dbpoi.Longitude = newPOI.Coordinate.Longitude;
                    }
                    if (!dbpoi.Image?.SequenceEqual(newPOI.Image ?? Array.Empty<byte>()) ?? dbpoi.Image != newPOI.Image)
                    {
                        dbpoi.Image = newPOI.Image;
                    }
                    Data.SaveChanges();
                }
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
            Dbmap? dbmap = Data.Dbmaps.FirstOrDefault(m => m.MapId == map.Id);
            Dbpoi? dbpoi = Data.Dbpois.FirstOrDefault(p => p.Poiid == poi.Id);
            if (_maps.Contains(map) && dbmap is not null && dbpoi is not null)
            {
                if (map.RemovePOI(poi))
                {
                    Data.Dbpois.Remove(dbpoi);
                    Data.SaveChanges();
                }
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