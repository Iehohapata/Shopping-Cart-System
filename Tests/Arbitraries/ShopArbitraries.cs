using FsCheck;
using FsCheck.Fluent;
using Shopping_Cart_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_System.Tests.Arbitraries
{
    public static class ShopArbitraries
    {
        public static Arbitrary<Product> Product()
        {
            throw new NotImplementedException();
        }

        public static Arbitrary<int> Quantity()
        {
            throw new NotImplementedException();

        }

        public static Arbitrary<ShoppingCart> Cart()
        {
            throw new NotImplementedException();


        }

        private static ShoppingCart BuildCart(List<Product> products, List<int> quantities)
        {
            throw new NotImplementedException();


        }

        private static Gen<string> NonEmptyAlphaString()
        {
            throw new NotImplementedException();
        }
    }

}
