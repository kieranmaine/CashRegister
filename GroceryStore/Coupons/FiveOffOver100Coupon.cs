namespace GroceryStore.Coupons
{
    public class FiveOffOver100Coupon : ICoupon
    {
        public decimal ApplyDiscount(decimal totalPrice)
        {
            return totalPrice >= 100 ? totalPrice - 5 : totalPrice;
        }
    }
}