namespace GPSPOIpontok.Domain
{
    public class Ratio
    {
        public int Lesser { get; set; }
        public int Greater { get; set; }
        public Ratio(int lesser, int greater)
        {
            Lesser = lesser;
            Greater = greater;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ratio)
            {
                Ratio otherratio = (Ratio)obj;
                return Lesser == otherratio.Lesser && Greater == otherratio.Greater;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Lesser.GetHashCode() + Greater.GetHashCode();
        }

        public static bool operator ==(Ratio a, Ratio b)
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
        public static bool operator !=(Ratio a, Ratio b)
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