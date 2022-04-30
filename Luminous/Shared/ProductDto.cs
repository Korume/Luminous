using System.ComponentModel.DataAnnotations;

namespace Luminous.Shared
{
    public class ProductDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public List<string> PhotoSources { get; set; } = new List<string>();

        public static string CurrencySymbol => "₴";
    }
}
