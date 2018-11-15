using GroceryStore.Products;

namespace GroceryStore.Offers
{
    public interface IOffer
    {
        decimal ApplyOffer(Product product, int quantity);
    }
}