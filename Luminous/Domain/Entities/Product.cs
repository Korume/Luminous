namespace Luminous.Domain.Entities
{
    public class Product
    {
        public string? Id { get; }
        public string Title { get; }
        public decimal Price { get; }
        public string CurrencySymbol { get; } = "₴";

        public List<Uri> Photos { get; } = new List<Uri>();

        public Product(string? id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
