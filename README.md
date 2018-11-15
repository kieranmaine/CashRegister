# GroceryStore

This library replicates the basic functions of a Cash Register.

Functionality Includes:

* Adding products to the cash register.
* Calculating a total for all the products.
* Applying a discount coupon to the total.
* Applying special offers when calculating the total (eg. Buy One Get One Free, etc)

Design notes:

* Only one `Coupon` can be used when calculating the total.
* Only one `Offer` will be applied to each product.
* Even though the product classses `QuantityProduct` and `WeightProduct` exist (to represent items that are purchased individually or items that are weighed before purchase), the cash register simple treats the number of items or weight of items as a quantity as the total price can still be calculated without the cash register being aware of the units of each item. However the two classes provide a starting point for future changes, if, for example, a UI is added and product units become relevant.
