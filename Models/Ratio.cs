namespace GPSPOIpontok.Models
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
                return Lesser.Equals(otherratio.Lesser) && Greater.Equals(otherratio.Greater);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Lesser.GetHashCode() + Greater.GetHashCode();
        }
    }
}