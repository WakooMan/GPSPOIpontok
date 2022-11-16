namespace GPSPOIpontok.Models
{
    public class POI
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Coordinate Coordinate { get; set; }
        public string Category { get; set; }
        public Image Image { get; set; }
        public POI(Coordinate coord,string name,string description,string category,Image image)
        {
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
                return Name.Equals(otherpoi.Name) && Coordinate.Equals(otherpoi.Coordinate) && Image.Equals(otherpoi.Image) && Category.Equals(otherpoi.Category) && Description.Equals(otherpoi.Description);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Category.GetHashCode() + Description.GetHashCode() + Image.GetHashCode() + Coordinate.GetHashCode();
        }
    }
}