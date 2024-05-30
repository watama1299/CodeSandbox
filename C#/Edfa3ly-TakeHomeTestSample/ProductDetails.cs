public class ProductDetails
{
    public ItemType Type { get; }
    public decimal ItemPrice { get; }
    public double Weight { get; }
    public CountryInitials ShippedFrom { get; }
    
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

    private ProductDetails( ItemType type, decimal price, double weight, CountryInitials shippingCountry ) 
    {
        this.Type = type;
        ItemPrice = price;
        this.Weight = weight;
        ShippedFrom = shippingCountry;
    }

    public static ProductDetails ProductFactory( ItemType type )
    {
        return type switch
        {
            ItemType.Tshirt => new ProductDetails(ItemType.Tshirt, 30.99m, 0.2, CountryInitials.US),
            ItemType.Blouse => new ProductDetails(ItemType.Blouse, 10.99m, 0.3, CountryInitials.UK),
            ItemType.Pants => new ProductDetails(ItemType.Pants, 64.99m, 0.9, CountryInitials.UK),
            ItemType.Sweatpants => new ProductDetails(ItemType.Sweatpants, 84.99m, 1.1, CountryInitials.CN),
            ItemType.Jacket => new ProductDetails(ItemType.Jacket, 199.99m, 2.2, CountryInitials.US),
            ItemType.Shoes => new ProductDetails(ItemType.Shoes, 79.99m, 1.3, CountryInitials.CN),
            _ => throw new Exception("Product factory did not generate any products."),
        };

    }
}
