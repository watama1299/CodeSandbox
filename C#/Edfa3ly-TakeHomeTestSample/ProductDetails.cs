public class ProductDetails
{
    public ItemType Type { get; set; }
    public decimal ItemPrice { get; set; }
    public double Weight { get; set; }
    public CountryInitials ShippedFrom { get; set; }
    
    public decimal ShippingRate
    {
        get
        {
            int _shippingRate;
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
                default:
                    _shippingRate = 0;
                    break;
            }
            return _shippingRate;
        }
    }

    public ProductDetails( ItemType type, decimal price, double weight, CountryInitials shippingCountry ) 
    {
        this.Type = type;
        ItemPrice = price;
        this.Weight = weight;
        ShippedFrom = shippingCountry;
    }
}
