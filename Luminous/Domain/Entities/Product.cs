namespace Luminous.Domain.Entities
{
    public class Product
    {
        public string? Id { get; }
        public string Title { get; }
        public decimal Price { get; }
        public string CurrencySymbol { get; } = "₴";

        public List<string> PhotoSources { get; }

        public Product(string? id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
            PhotoSources = new List<string>();
        }

        public Product(string? id, string title, decimal price, List<string> photoSources)
        {
            Id = id;
            Title = title;
            Price = price;
            PhotoSources = photoSources;
        }
    }
}
