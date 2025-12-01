using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_System.Domain
{
    public class CartService
    {
        private readonly InMemoryCartRepository _repo;

        public CartService(InMemoryCartRepository repo)
        {
            _repo = repo;
        }

        public void SaveCart(ShoppingCart cart)
        {
            _repo.Save(cart);
        }
    }

}
