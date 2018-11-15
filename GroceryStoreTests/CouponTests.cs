using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Coupons;
using NUnit.Framework;

namespace GroceryStoreTests
{
    [TestFixture]
    public class FiveOffOver100CouponCouponTests
    {
        [Test]
        [TestCase(99, 99)]
        [TestCase(100, 95)]
        [TestCase(200, 195)]
        public void GivenTotalWhenDiscountedThenCorrectValueReturned(int total, int expectedTotal)
        {
            var coupon = new FiveOffOver100Coupon();

            Assert.That(coupon.ApplyDiscount(total), Is.EqualTo(expectedTotal));
        }
    }
}
