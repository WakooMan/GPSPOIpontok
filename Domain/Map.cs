using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Domain
{
    public class Map
    {
        private List<POI> _pointOfInterests = new List<POI>();
        public byte[] Image { get; set; }
        public int Id { get; internal set; }
        public string Name { get; set; }
        public Direction MapDirection { get; set; }
        public Ratio MapRatio { get; set; }
        public Coordinate MaximumCoordinate { get; set; }
        public Coordinate MinimumCoordinate { get; set; }
        public IReadOnlyList<POI> PointOfInterests => _pointOfInterests;
        public bool AddPOI(POI poi)
        {
            if (!_pointOfInterests.Contains(poi))
            {
                _pointOfInterests.Add(poi);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemovePOI(POI poi)
        {
            if (_pointOfInterests.Contains(poi) && _pointOfInterests.Any(p => p.Id == poi.Id))
            {
                _pointOfInterests.Remove(poi);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReplacePOI(POI oldPOI,POI newPOI)
        {
            if (_pointOfInterests.Contains(oldPOI) && _pointOfInterests.Any(p => p.Id == oldPOI.Id) && ReferenceEquals(oldPOI.Map,newPOI.Map) && oldPOI.Id == newPOI.Id && oldPOI != newPOI)
            {
                _pointOfInterests[ _pointOfInterests.FindIndex(poi => poi == oldPOI)] = newPOI;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Map(string name,Direction mapDirection, Ratio mapRatio, Coordinate minCoord, Coordinate maxCoord,byte[] image)
        {
            Image = image;
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
                return Name == othermap.Name && MapDirection == othermap.MapDirection && MapRatio == othermap.MapRatio && MaximumCoordinate == othermap.MaximumCoordinate && MinimumCoordinate == othermap.MinimumCoordinate && (Image?.SequenceEqual(othermap.Image ?? Array.Empty<byte>())?? Image == othermap.Image) && PointOfInterests.SequenceEqual(othermap.PointOfInterests);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return MapDirection.GetHashCode() + MapRatio.GetHashCode() + MaximumCoordinate.GetHashCode() + MinimumCoordinate.GetHashCode() + Name.GetHashCode() + Id.GetHashCode() + Image?.Sum(b => b.GetHashCode()) ?? 0 + PointOfInterests.Sum(poi => poi.GetHashCode());
        }

        public static bool operator ==(Map a, Map b)
        {
            if (a is null && b is null)
            {
                return true;
            }
            else if (a is not null)
            {
                return a.Equals(b);
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Map a, Map b)
        {
            if (a is null && b is null)
            {
                return false;
            }
            else if (a is not null)
            {
                return !a.Equals(b);
            }
            else
            {
                return true;
            }
        }
    }
}
