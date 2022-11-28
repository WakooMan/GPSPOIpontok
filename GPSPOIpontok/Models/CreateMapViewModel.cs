using GPSPOIpontok.Domain;
using GPSPOIpontok.Models.Service.CreateMap;
using GPSPOIpontok.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Models
{
    public class CreateMapViewModel: ViewModelBase
    {
        [Required(ErrorMessage = "Please select a direction.")]
        public Direction? Direction { get; set; } = null;
        [Required(ErrorMessage = "Please give me the lesser number of ratio.")]
        [Range(1,int.MaxValue,ErrorMessage ="Lesser ratio number should be positive.")]
        [IntegerLowerThan("Greater", ErrorMessage = "Lesser number should be lower than Greater.")]
        public int? Lesser { get; set; } = null;
        [Required(ErrorMessage = "Please give me the greater number of ratio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Greater ratio number should be positive.")]
        [IntegerGreaterThan("Lesser",ErrorMessage ="Greater number should be bigger than Lesser.")]
        public int? Greater { get; set; } = null;
        [Required(ErrorMessage = "Please give me the latitude of minimum coordinate.")]
        [Range(-90,90, ErrorMessage = "Latitude number should be between -90 and 90.")]
        public double? MinCoordinateLatitude { get; set; } = null;
        [Required(ErrorMessage = "Please give me the longitude of minimum coordinate.")]
        [Range(-180, 180, ErrorMessage = "Longitude number should be between -180 and 180.")]
        public double? MinCoordinateLongitude { get; set; } = null;
        [Required(ErrorMessage = "Please give me the latitude of maximum coordinate.")]
        [Range(-90, 90, ErrorMessage = "Latitude number should be between -90 and 90.")]
        public double? MaxCoordinateLatitude { get; set; } = null;
        [Required(ErrorMessage = "Please give me the longitude of maximum coordinate.")]
        [Range(-180, 180, ErrorMessage = "Longitude number should be between -180 and 180.")]
        public double? MaxCoordinateLongitude { get; set; } = null;
        [Required(ErrorMessage = "Please give me the name of the map.")]
        [StringLength(50,ErrorMessage ="Map name should be between 5 and 50 characters long.",MinimumLength =5)]
        public string? MapName { get; set; } = null;
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] {".jpg",".png" })]
        public IFormFile? Image { get; set; } = null;
        public CreateMapViewModel()
        {
            ModelService = new CreateMapService(this);
        }
    }
}
