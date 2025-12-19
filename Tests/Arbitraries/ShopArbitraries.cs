using FsCheck;
using FsCheck.Fluent;
using Shopping_Cart_System.Domain;

namespace Shopping_Cart_System.Tests.Arbitraries
{
    public static class ShopArbitraries
    {
        private const string alphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static Arbitrary<Product> Product()
        {
            var gen =
                from id in NonEmptyAlphaString()
                from name in NonEmptyAlphaString()
                from price in Gen.Choose(1, int.MaxValue).Select(p => (decimal)p / 100m)
                select new Product(id, name, price);

            return Arb.From(gen);
        }

        public static Arbitrary<int> Quantity()
        {
            return Arb.From(Gen.Choose(1, int.MaxValue));
        }

        public static Arbitrary<ShoppingCart> Cart()
        {
            var gen =
                from products in Product().Generator.ListOf()
                from quantities in Quantity().Generator.ListOf(products.Count)
                select BuildCart(products, quantities);

            return Arb.From(gen);
        }

        private static ShoppingCart BuildCart(List<Product> products, List<int> quantities)
        {
            var cart = new ShoppingCart();

            foreach (var pair in products
                .Zip(quantities, (p, q) => (p, q))
                .GroupBy(x => x.p.Id)
                .Select(g => g.First()))
            {
                cart.Add(pair.p, pair.q);
            }

            return cart;
        }

        private static Gen<string> NonEmptyAlphaString()
        {
            return Gen.NonEmptyListOf(Gen.Elements(alphaChars.ToCharArray()))
                    .Select(chars => new string(chars.ToArray()));
        }
    }

}
