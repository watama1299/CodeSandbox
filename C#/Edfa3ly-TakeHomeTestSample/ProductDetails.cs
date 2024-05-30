public class ProductDetails
{
    public ItemType Type { get; set; }
    public decimal ItemPrice { get; set; }
    public double Weight { get; set; }
    public CountryInitials ShippedFrom { get; set; }
    
    private decimal _shippingRate;
    public decimal ShippingRate
    {
        get { return _shippingRate; }
        set
        {
            switch (ShippedFrom)
            {
                case CountryInitials.US:
                    _shippingRate = 2;
                    break;
                case CountryInitials.UK:
                    _shippingRate = 3;
                    break;
                case CountryInitials.CN:
                    _shippingRate = 2;
                    break;
            }
        }
    }
}
