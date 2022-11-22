using GPSPOIpontok.Models.Domain;
using GPSPOIpontok.Models.Service;

namespace GPSPOIpontok.Models
{
    public class CreateMapViewModel
    {
        private readonly CreateMapService Service;
        public Direction Direction { get; set; }
        public Ratio Ratio { get; set; }
        public Coordinate MinCoordinate { get; set; }
        public Coordinate MaxCoordinate { get; set; }
        public string MapName { get; set; }
        public CreateMapViewModel()
        {
            Service = new CreateMapService(this);
        }




    }
}
