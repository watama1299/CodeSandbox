using System.Net;

public class Invoice
{
    private decimal _subtotal;
    private decimal _shippingCost;
    private decimal _taxAmount;
    private IDictionary<IDiscount, decimal> _discounts = new Dictionary<IDiscount, decimal>();
}
