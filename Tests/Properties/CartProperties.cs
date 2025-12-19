using FsCheck.Xunit;
using Shopping_Cart_System.Domain;
using Shopping_Cart_System.Tests.Arbitraries;


namespace Shopping_Cart_System.Tests.Properties
{
    public class CartProperties
    {
        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Adding_a_product_makes_it_appear_in_cart(Product product, int quantity)
        {
            quantity = Math.Abs(quantity) + 1;
            var cart = new ShoppingCart();

            cart.Add(product, quantity);

            Assert.Contains(cart.Items, i => i.Product.Id == product.Id);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Same_product_cannot_exist_twice(Product product, int q1, int q2)
        {
            q1 = Math.Abs(q1) + 1;
            q2 = Math.Abs(q2) + 1;

            var cart = new ShoppingCart();
            cart.Add(product, q1);
            cart.Add(product, q2);

            Assert.Single(cart.Items);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Adding_same_product_accumulates_quantity(Product product, int q1, int q2)
        {
            q1 = Math.Abs(q1) + 1;
            q2 = Math.Abs(q2) + 1;

            var cart = new ShoppingCart();
            cart.Add(product, q1);
            cart.Add(product, q2);

            var item = cart.Items.Single();
            Assert.Equal(q1 + q2, item.Quantity);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Removing_existing_product_removes_it(ShoppingCart cart)
        {
            if (!cart.Items.Any()) return;

            var productId = cart.Items.First().Product.Id;

            cart.Remove(productId);

            Assert.DoesNotContain(cart.Items, i => i.Product.Id == productId);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Removing_non_existing_product_throws(ShoppingCart cart)
        {
            Assert.Throws<InvalidOperationException>(() =>
                cart.Remove("non-existing-id"));
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Total_price_is_sum_of_items(ShoppingCart cart)
        {
            var expected =
                cart.Items.Sum(i => i.Product.Price * i.Quantity);

            Assert.Equal(expected, cart.TotalPrice());
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Decreasing_quantity_updates_state_correctly(Product product, int quantity)
        {
            quantity = Math.Max(quantity, 2);
            var cart = new ShoppingCart();
            cart.Add(product, quantity);

            cart.Decrease(product.Id, 1);

            var item = cart.Items.Single();
            Assert.Equal(quantity - 1, item.Quantity);
        }
    }
}
