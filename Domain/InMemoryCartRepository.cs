using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_System.Domain
{
    public class InMemoryCartRepository
    {
        private readonly List<ShoppingCart> _storage = new();

        public void Save(ShoppingCart cart)
        {
            _storage.Add(cart);
        }

        public IReadOnlyCollection<ShoppingCart> All() => _storage.AsReadOnly();
    }

}
