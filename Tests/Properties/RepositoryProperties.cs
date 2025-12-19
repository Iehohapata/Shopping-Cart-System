using FsCheck.Xunit;
using Shopping_Cart_System.Domain;
using Shopping_Cart_System.Tests.Arbitraries;

namespace Shopping_Cart_System.Tests.Properties
{


    public class RepositoryProperties
    {
        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Saved_cart_is_not_lost(ShoppingCart cart)
        {
            var repo = new InMemoryCartRepository();

            repo.Save(cart);

            Assert.Contains(cart, repo.All());
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Saving_multiple_carts_preserves_all(ShoppingCart cart1, ShoppingCart cart2)
        {
            var repo = new InMemoryCartRepository();

            repo.Save(cart1);
            repo.Save(cart2);

            Assert.Equal(2, repo.All().Count);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Cart_service_does_not_throw_on_valid_cart(ShoppingCart cart)
        {
            var repo = new InMemoryCartRepository();
            var service = new CartService(repo);

            service.SaveCart(cart);

            Assert.Contains(cart, repo.All());
        }
    }

}
