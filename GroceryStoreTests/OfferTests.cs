using System.Runtime.Remoting;
using GroceryStore.Offers;
using GroceryStore.Products;
using NUnit.Framework;

namespace GroceryStoreTests
{
    [TestFixture]
    public class OfferTests
    {
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(3, 20)]
        [TestCase(4, 20)]
        public void GivenProductQuantitiesWhenBogogApplyOfferCalledThenTotalPriceReduced(int quantity, int expectedPrice)
        {
            var product = new QuantityProduct { Price = 10 };

            var bogof = new BuyOneGetOneFreeOffer();

            var totalPrice = bogof.ApplyOffer(product, quantity);

            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void When75PercentOffApplyOfferCalledThenTotalPriceReduced()
        {
            var product = new QuantityProduct { Price = 399 };

            var offer = new Seventy5PercentOff();

            var totalPrice = offer.ApplyOffer(product, 1);

            Assert.That(totalPrice, Is.EqualTo(99.75m));
        }
    }
}