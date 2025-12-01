using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_System.Domain
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            Product = product;
            Quantity = quantity;
        }

        public void Increase(int amount)
        {
            if (amount <= 0) throw new InvalidOperationException();
            Quantity += amount;
        }

        public void Decrease(int amount)
        {
            if (amount <= 0) throw new InvalidOperationException();

            if (Quantity - amount <= 0)
                throw new InvalidOperationException("Cannot go below 1");

            Quantity -= amount;
        }
    }
}
