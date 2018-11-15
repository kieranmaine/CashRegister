using System;
using System.Collections.Generic;
using GroceryStore;
using GroceryStore.Coupons;
using GroceryStore.Offers;
using GroceryStore.Products;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GroceryStoreTests
{
    [TestFixture]
    public class CashRegisterTests
    {
        private CashRegister _cashRegister;


        [SetUp]
        public void SetUp()
        {
            _cashRegister = new CashRegister();
        }

        [Test]
        public void GivenProductNotAddedWhenAddingQuantityProductThenProductShouldBeAdded()
        {
            var product = new QuantityProduct { Name = "Lucky Stars 500g" };

            _cashRegister.AddProduct(product, 2);

            Assert.That(_cashRegister.Products[product.Name].Quantity, Is.EqualTo(2));
        }

        [Test]
        public void GivenProductNotAddedWhenAddingWeightProductThenProductShouldBeAdded()
        {
            var product = new WeightProduct { Name = "Gala Apple"};

            _cashRegister.AddProduct(product, 500);

            Assert.That(_cashRegister.Products[product.Name].Quantity, Is.EqualTo(500));
        }

        [Test]
        public void GivenProductAddedWhenAddingProductThenQuantityShouldIncrease()
        {
            var product = new WeightProduct { Name = "Gala Apple" };

            _cashRegister.AddProduct(product, 1000);

            _cashRegister.AddProduct(product, 1000);

            Assert.That(_cashRegister.Products.Count, Is.EqualTo(1));
            Assert.That(_cashRegister.Products[product.Name].Quantity, Is.EqualTo(2000));
        }

        [Test]
        public void GivenProductsAddedWhenCalculatingTotalThenTotalReturned()
        {
            var weightProduct = new WeightProduct { Name = "Gala Apple", Price = 49};
            var quantityProduct = new QuantityProduct { Name = "Lucky Stars 500g", Price = 399 };

            _cashRegister.AddProduct(weightProduct, 100);
            _cashRegister.AddProduct(quantityProduct, 2);
            
            var total = _cashRegister.CalculateTotal(null, null);

            Assert.That(total, Is.EqualTo(5698));
        }

        [Test]
        public void GivenProductsAddedWhenCalculatingTotalWithCouponThenDiscountAppliedToTotal()
        {
            var weightProduct = new WeightProduct { Name = "Gala Apple", Price = 10 };
            var quantityProduct = new QuantityProduct { Name = "Lucky Stars 500g", Price = 3 };

            _cashRegister.AddProduct(weightProduct, 9);
            _cashRegister.AddProduct(quantityProduct, 3);

            var coupon = Substitute.For<ICoupon>();
            coupon.ApplyDiscount(99).Returns(50);

            var total = _cashRegister.CalculateTotal(coupon, null);

            Assert.That(total, Is.EqualTo(50));
        }

        [Test]
        public void GivenProductsAddedWhenCalculatingTotalWithOffersThenOfferAppliedToTotal()
        {
            var weightProduct = new WeightProduct { Name = "Gala Apple", Price = 10 };
            var quantityProduct = new QuantityProduct { Name = "Lucky Stars 500g", Price = 399 };
            var quantityProduct2 = new WeightProduct { Name = "Chocolate", Price = 50 };        

            var offer1 = Substitute.For<IOffer>();
            offer1.ApplyOffer(quantityProduct, 2).Returns(399);

            var offer2 = Substitute.For<IOffer>();
            offer2.ApplyOffer(weightProduct, 9).Returns(67.5m);

            var currentOffers = new Dictionary<string, IOffer>
            {
                { quantityProduct.Name, offer1 },
                { weightProduct.Name, offer2 }                
            };

            _cashRegister.AddProduct(weightProduct, 9);
            _cashRegister.AddProduct(quantityProduct, 2);
            _cashRegister.AddProduct(quantityProduct2, 5);
            

            var total = _cashRegister.CalculateTotal(null, currentOffers);

            Assert.That(total, Is.EqualTo(716.5m));
        }
    }
}
