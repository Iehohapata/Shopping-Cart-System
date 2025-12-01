using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_System.Domain
{
    public class ShoppingCart
    {
        private readonly Dictionary<string, CartItem> _items = new();

        public IReadOnlyCollection<CartItem> Items => _items.Values;

        public void Add(Product product, int quantity)
        {
            if (_items.ContainsKey(product.Id))
                _items[product.Id].Increase(quantity);
            else
                _items[product.Id] = new CartItem(product, quantity);
        }

        public void Remove(string productId)
        {
            if (!_items.ContainsKey(productId))
                throw new InvalidOperationException("Product not in cart");

            _items.Remove(productId);
        }

        public void Decrease(string productId, int amount)
        {
            if (!_items.ContainsKey(productId))
                throw new InvalidOperationException("Product not found");

            _items[productId].Decrease(amount);
        }

        public decimal TotalPrice()
            => _items.Values.Sum(i => i.Product.Price * i.Quantity);
    }

}
