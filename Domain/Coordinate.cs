namespace GPSPOIpontok.Domain
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Coordinate)
            {
                Coordinate? othercoord = (Coordinate)obj;
                return Latitude == othercoord.Latitude && Longitude == othercoord.Longitude;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() + Longitude.GetHashCode();
        }

        public static bool operator ==(Coordinate a, Coordinate b)
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
        public static bool operator !=(Coordinate a, Coordinate b)
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