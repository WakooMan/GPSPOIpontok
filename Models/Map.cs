namespace GPSPOIpontok.Models
{
    public class Map
    {
        private List<POI> _pointOfInterests = new List<POI>();
        public Image ImageFile { get; set; }
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
        }

        public void RemovePOI(POI poi)
        {
            if (_pointOfInterests.Contains(poi))
            {
                _pointOfInterests.Remove(poi);
            }
        }

        public void ModifyPOI(POI poi,Coordinate coord)
        {
            if (_pointOfInterests.Contains(poi))
            {
                poi.Coordinate = coord;
            }
        }
        public Map(Image imageFile,Direction mapDirection,Ratio mapRatio,Coordinate minCoord,Coordinate maxCoord)
        {
            ImageFile = imageFile;
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
                return ImageFile.Equals(othermap.ImageFile) && MapDirection.Equals(othermap.MapDirection) && MapRatio.Equals(othermap.MapRatio) && MaximumCoordinate.Equals(othermap.MaximumCoordinate) && MinimumCoordinate.Equals(othermap.MinimumCoordinate);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = ImageFile.GetHashCode() + MapDirection.GetHashCode() + MapRatio.GetHashCode() + MaximumCoordinate.GetHashCode() + MinimumCoordinate.GetHashCode();
            foreach (POI poi in _pointOfInterests)
            {
                hashcode += poi.GetHashCode();
            }
            return hashcode;
        }
    }
}
