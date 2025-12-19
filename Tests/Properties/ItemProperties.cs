using FsCheck.Xunit;
using Shopping_Cart_System.Domain;
using Shopping_Cart_System.Tests.Arbitraries;

namespace Shopping_Cart_System.Tests.Properties
{


    public class ItemProperties
    {
        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void CartItem_quantity_is_always_positive(Product product, int quantity)
        {
            quantity = Math.Abs(quantity) + 1;

            var item = new CartItem(product, quantity);

            Assert.True(item.Quantity > 0);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Increasing_quantity_always_increases(Product product, int quantity, int amount)
        {
            quantity = Math.Abs(quantity) + 1;
            amount = Math.Abs(amount) + 1;

            var item = new CartItem(product, quantity);
            var before = item.Quantity;

            item.Increase(amount);

            Assert.Equal(before + amount, item.Quantity);
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Decreasing_quantity_never_goes_below_one(Product product, int quantity)
        {
            quantity = Math.Max(quantity, 2);

            var item = new CartItem(product, quantity);

            Assert.Throws<InvalidOperationException>(() =>
                item.Decrease(quantity));
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Increase_with_non_positive_amount_throws(Product product, int quantity)
        {
            quantity = Math.Abs(quantity) + 1;
            var item = new CartItem(product, quantity);

            Assert.Throws<InvalidOperationException>(() => item.Increase(0));
        }

        [Property(Arbitrary = new[] { typeof(ShopArbitraries) })]
        public void Decrease_with_non_positive_amount_throws(Product product, int quantity)
        {
            quantity = Math.Abs(quantity) + 1;
            var item = new CartItem(product, quantity);

            Assert.Throws<InvalidOperationException>(() => item.Decrease(0));
        }
    }

}
