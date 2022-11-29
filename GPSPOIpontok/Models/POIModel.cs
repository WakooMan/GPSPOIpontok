using GPSPOIpontok.Models.ValidationAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace GPSPOIpontok.Models
{
    public class POIModel
    {
        #region FormData
        [Required(ErrorMessage = "Please give me the interesting point's name.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Description should be between 5 and 20 characters long.")]
        public string? Name { get; set; } = null;
        [Required(ErrorMessage = "Please give me the interesting point's description.")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Description should be between 10 and 60 characters long.")]
        public string? Description { get; set; } = null;
        public string? Category { get; set; } = null;
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; } = null;
        [Required(ErrorMessage = "Latitude should be given.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,3})$", ErrorMessage = "Valid Decimal number with maximum 3 decimal places.")]
        [DecimalRange(-90, 90, ErrorMessage = "Longitude should be between -90 and 90 number.")]
        public string? Latitude { get; set; } = null;
        [Required(ErrorMessage = "Longitude should be given.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,3})$", ErrorMessage = "Should be a valid decimal number with maximum 3 decimal places.")]
        [DecimalRange(-180,180,ErrorMessage ="Longitude should be between -180 and 180 number.")]
        public string? Longitude { get; set; } = null;
        #endregion

        public string ImageString 
        {
            get 
            {
                if (Image is null)
                {
                    return "null";
                }
                else
                {
                    var stream = new MemoryStream();
                    Image.CopyTo(stream);
                    return System.Text.Encoding.Default.GetString(stream.ToArray());
                }
            }
        }
    }
}
