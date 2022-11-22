namespace GPSPOIpontok.Models.Domain
{
    public class Map
    {
        private List<POI> _pointOfInterests = new List<POI>();
        //public Image ImageFile { get; set; }
        public string Name { get; set; }
        public Direction MapDirection { get; set; }
        public Ratio MapRatio { get; set; }
        public Coordinate MaximumCoordinate { get; set; }
        public Coordinate MinimumCoordinate { get; set; }
        public IReadOnlyList<POI> PointOfInterests => _pointOfInterests;
        public void AddPOI(POI poi)
        {
            if (!_pointOfInterests.Contains(poi))
            {
                _pointOfInterests.Add(poi);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemovePOI(POI poi)
        {
            if (_pointOfInterests.Contains(poi))
            {
                _pointOfInterests.Remove(poi);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ReplacePOI(POI oldPOI,POI newPOI)
        {
            if (_pointOfInterests.Contains(oldPOI))
            {
                _pointOfInterests[ _pointOfInterests.FindIndex(poi => poi.Equals(oldPOI))] = newPOI;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ModifyPOI(POI poi, Coordinate coord)
        {
            if (_pointOfInterests.Contains(poi))
            {
                poi.Coordinate = coord;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public Map(string name,Direction mapDirection, Ratio mapRatio, Coordinate minCoord, Coordinate maxCoord)
        {
            //ImageFile = imageFile;
            Name = name;
            MapDirection = mapDirection;
            MapRatio = mapRatio;
            MinimumCoordinate = minCoord;
            MaximumCoordinate = maxCoord;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Map)
            {
                Map othermap = (Map)obj;
                if (othermap._pointOfInterests.Count != _pointOfInterests.Count)
                {
                    return false;
                }
                for (int i = 0; i < _pointOfInterests.Count; i++)
                {
                    if (!_pointOfInterests[i].Equals(othermap._pointOfInterests[i]))
                    {
                        return false;
                    }
                }
                return Name.Equals(othermap.Name) && MapDirection.Equals(othermap.MapDirection) && MapRatio.Equals(othermap.MapRatio) && MaximumCoordinate.Equals(othermap.MaximumCoordinate) && MinimumCoordinate.Equals(othermap.MinimumCoordinate);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = MapDirection.GetHashCode() + MapRatio.GetHashCode() + MaximumCoordinate.GetHashCode() + MinimumCoordinate.GetHashCode() + Name.GetHashCode();
            foreach (POI poi in _pointOfInterests)
            {
                hashcode += poi.GetHashCode();
            }
            return hashcode;
        }
    }
}
