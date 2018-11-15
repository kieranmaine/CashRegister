using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Products;

namespace GroceryStore.Offers
{
    public class BuyOneGetOneFreeOffer : IOffer
    {
        public decimal ApplyOffer(Product product, int quantity)
        {
            return (quantity / 2 + quantity % 2) * product.Price;
        }
    }
}
