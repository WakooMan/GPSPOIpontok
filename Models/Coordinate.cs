namespace GPSPOIpontok.Models
{
    public class Coordinate
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Coordinate(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Coordinate)
            {
                Coordinate othercoord = (Coordinate)obj;
                return Latitude.Equals(othercoord.Latitude) && Longitude.Equals(othercoord.Longitude);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() + Longitude.GetHashCode();
        }
    }
}