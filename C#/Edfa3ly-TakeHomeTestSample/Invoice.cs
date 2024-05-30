public class Invoice
{
    private decimal _subtotal;
    private decimal _shippingCost;
    private decimal _taxAmount;
    private decimal _total;
    private IDictionary<IDiscount, decimal> _discounts;

    private Invoice( 
        decimal subtotal,
        decimal shippingCost,
        decimal taxAmount,
        decimal total,
        IDictionary<IDiscount, decimal> discounts
        )
    {
        _subtotal = subtotal;
        _shippingCost = shippingCost;
        _taxAmount = taxAmount;
        _total = total;
        _discounts = discounts;
    }

    private decimal CalculateSubtotal( IDictionary<ProductDetails, int> products )
    {
        decimal subtotal = 0;
        foreach( var product in products )
        {
            var price = product.Key.ItemPrice;
            var amount = product.Value;

            subtotal +=  price * amount;
        }
        return subtotal;
    }

    private decimal CalculateShippingCost( IDictionary<ProductDetails, int> products )
    {
        decimal shippingCost = 0;
        foreach( var product in products )
        {
            var weight = ( decimal ) product.Key.Weight;
            var shippingRate = product.Key.ShippingRate;
            var amount = product.Value;

            shippingCost += weight / 0.1m * shippingRate * amount;
        }
        return shippingCost;
    }

    private decimal CalculateTax( IDictionary<ProductDetails, int> products )
    {
        decimal tax = 0;
        foreach( var product in products )
        {
            var price = product.Key.ItemPrice;
            var amount = product.Value;

            tax +=  price * 0.14m * amount;
        }
        return tax;  
    }

    private IDictionary<IDiscount, decimal> CalculateDiscounts( IDictionary<ProductDetails, int> products )
    {
        var discounts = new Dictionary<IDiscount,decimal>();
        foreach( var discount in AllDiscounts.DiscountTypes )
        {
            if ( discount.CheckValidity( products ) )
            {
                discounts.Add( discount, discount.CalculateDiscount(products) );
            }
        }
        return discounts;
    }

    public Invoice GenerateInvoice( Cart userCart )
    {
        var userProducts = userCart.ProductsInCart;
        var subtotal = CalculateSubtotal( userProducts );
        var shippingCost = CalculateShippingCost( userProducts );
        var taxAmount = CalculateTax( userProducts );
        var discounts = CalculateDiscounts( userProducts );
        var total = _subtotal + _shippingCost + _taxAmount - _discounts.Values.Sum();

        return new Invoice(
            subtotal,
            shippingCost,
            taxAmount,
            total,
            discounts
        );
    }
}
