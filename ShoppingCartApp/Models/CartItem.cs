using ShoppingCartApp.ExtensionMethod;

namespace ShoppingCartApp.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; } = decimal.Zero;
        
    }
}
