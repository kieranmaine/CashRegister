using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Coupons;
using GroceryStore.Offers;
using GroceryStore.Products;

namespace GroceryStore
{
    public class CashRegister
    {
        public CashRegister()
        {
            Products = new Dictionary<string, CashRegisterProduct>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (Products.ContainsKey(product.Name))
            {
                Products[product.Name].Quantity += quantity;
            }
            else
            {
                Products.Add(product.Name, new CashRegisterProduct(product, quantity));
            }
        }

        public Dictionary<string, CashRegisterProduct> Products { get; }

        public decimal CalculateTotal(ICoupon coupon, Dictionary<string, IOffer> currentOffers)
        {
            var total = Products.Sum(kv =>
            {
                var product = kv.Value.Product;
                var quantity = kv.Value.Quantity;
                if (currentOffers != null && currentOffers.ContainsKey(product.Name))
                    return currentOffers[product.Name].ApplyOffer(product, quantity);
                return product.Price * quantity;
            });

            if (coupon != null)
                return coupon.ApplyDiscount(total);

            return total;
        }

        public class CashRegisterProduct
        {
            public CashRegisterProduct(Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }

            public Product Product { get; }
            public int Quantity { get; set; }
        }
    }
}