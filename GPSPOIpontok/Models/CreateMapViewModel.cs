using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service;
using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Models
{
    public class ErrorMessages
    {
        public string MinCoordinateLatitudeError = "";
        public string MinCoordinateLongitudeError = "";
        public string MaxCoordinateLatitudeError = "";
        public string MaxCoordinateLongitudeError = "";
        public string RatioLesserError = "";
        public string RatioGreaterError = "";
        public string DirectionError = "";
        public string MapNameError = "";
        public string ImageError = "";

        public ErrorMessages()
        { }

        private bool CheckLongitude(double longitude)
        {
            return -180.0 <= longitude && longitude <= 180.0;
        }

        private bool CheckLatitude(double latitude)
        {
            return -90.0 <= latitude && latitude <= 90.0;
        }

        public ErrorMessages(int? Lesser, int? Greater, string? MapName, double? MaxCoordLat, double? MaxCoordLong, double? MinCoordLat, double? MinCoordLong, Direction? dir, IFormFile? image)
        {
            if (Lesser is null)
            {
                RatioLesserError = "Lesser Ratio should be given!";
            }
            if (Greater is null)
            {
                RatioGreaterError = "Grater Ratio should be given!";
            }
            if (Lesser is not null && Greater is not null && Lesser > Greater)
            {
                RatioLesserError = "Lesser should be a smaller number, than Greater.";
                RatioGreaterError = "Greater should be a bigger number, than Lesser.";
            }
            if (string.IsNullOrEmpty(MapName))
            {
                MapNameError = "Map Name should be given!";
            }
            if (MaxCoordLat is null)
            {
                MaxCoordinateLatitudeError = "Maximum Coordinate's Latitude should be given!";
            }
            if (MaxCoordLong is null)
            {
                MaxCoordinateLongitudeError = "Maximum Coordinate's Longitude should be given!";
            }
            if (MinCoordLat is null)
            {
                MinCoordinateLatitudeError = "Minimum Coordinate's Latitude should be given!";
            }
            if (MinCoordLong is null)
            {
                MinCoordinateLongitudeError = "Minimum Coordinate's Longitude should be given!";
            }

            if (MaxCoordLat is not null && !CheckLatitude((double)MaxCoordLat))
            {
                MaxCoordinateLatitudeError = "Maximum Coordinate's Latitude should be between -90 and 90!";
            }
            if (MaxCoordLong is not null && !CheckLongitude((double)MaxCoordLong))
            {
                MaxCoordinateLongitudeError = "Maximum Coordinate's Longitude should be between -180 and 180!";
            }
            if (MinCoordLat is not null && !CheckLatitude((double)MinCoordLat))
            {
                MinCoordinateLatitudeError = "Minimum Coordinate's Latitude should be between -90 and 90!";
            }
            if (MinCoordLong is not null && !CheckLongitude((double)MinCoordLong))
            {
                MinCoordinateLongitudeError = "Minimum Coordinate's Longitude should be between -180 and 180!";
            }
            if (dir is null)
            {
                DirectionError = "Direction should be given!";
            }
            if (image is null)
            {
                ImageError = "Map Image should be uploaded!";
            }
        }

        public bool HasError()
        {
            return !string.IsNullOrEmpty(MinCoordinateLatitudeError) || !string.IsNullOrEmpty(MinCoordinateLongitudeError) ||
                !string.IsNullOrEmpty(MaxCoordinateLatitudeError) || !string.IsNullOrEmpty(MaxCoordinateLongitudeError) ||
                !string.IsNullOrEmpty(RatioLesserError) || !string.IsNullOrEmpty(RatioGreaterError) ||
                !string.IsNullOrEmpty(DirectionError) || !string.IsNullOrEmpty(MapNameError) || !string.IsNullOrEmpty(ImageError);
        }

    }

    public class CreateMapViewModel: ViewModelBase
    {
        public Direction? Direction { get; set; }
        public int? Lesser { get; set; }
        public int? Greater { get; set; }
        public double? MinCoordinateLatitude { get; set; }
        public double? MinCoordinateLongitude { get; set; }
        public double? MaxCoordinateLatitude { get; set; }
        public double? MaxCoordinateLongitude { get; set; }
        public string? MapName { get; set; }
        public IFormFile? Image { get; set; }

        public ErrorMessages GetErrorMessages()
        {
            return new ErrorMessages(Lesser,Greater,MapName,MaxCoordinateLatitude,MaxCoordinateLongitude,MinCoordinateLatitude,MinCoordinateLongitude,Direction,Image);
        }
        public CreateMapViewModel()
        {
            ModelService = new CreateMapService(this);
        }




    }
}
