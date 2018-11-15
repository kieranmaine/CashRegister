using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Products;

namespace GroceryStore.Offers
{
    public class Seventy5PercentOff : IOffer
    {
        public decimal ApplyOffer(Product product, int quantity)
        {
            return (product.Price * quantity) * 0.25m;
        }
    }
}
