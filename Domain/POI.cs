using System.Data.Common;

namespace GPSPOIpontok.Domain
{
    public class POI
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Coordinate Coordinate { get; set; }
        public string? Category { get; set; }
        public byte[]? Image { get; set; }
        public Map Map { get; }
        public POI(Map map,Coordinate coord, string name, string description, string? category, byte[]? image)
        {
            Map = map;
            Coordinate = coord;
            Name = name;
            Description = description;
            Category = category;
            Image = image;
        }

        public override bool Equals(object? obj)
        {
            if (obj is POI)
            {
                POI otherpoi = (POI)obj;
                return Name == otherpoi.Name && Coordinate == otherpoi.Coordinate  && Category == otherpoi.Category && Description == otherpoi.Description && (Image?.SequenceEqual(otherpoi.Image ?? Array.Empty<byte>()) ?? Image == otherpoi.Image) && ReferenceEquals(Map,otherpoi.Map);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Category?.GetHashCode() ?? 0 + Description.GetHashCode() + Coordinate.GetHashCode() + Id.GetHashCode() + Image?.Sum(b => b.GetHashCode()) ?? 0;
        }

        public static bool operator ==(POI a, POI b)
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
        public static bool operator !=(POI a, POI b)
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