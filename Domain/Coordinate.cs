using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Domain
{
    public class Coordinate
    {
        private double latitude,longitude;
        public double Latitude 
        { 
            get 
            { 
                return latitude; 
            }
            set 
            { 
                latitude = Math.Round(value,3);
            }
        }
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = Math.Round(value, 3);
            }
        }
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Coordinate() { }

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

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
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