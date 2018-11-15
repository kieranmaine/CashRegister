namespace GroceryStore.Coupons
{
    public interface ICoupon
    {
        decimal ApplyDiscount(decimal totalPrice);
    }
}