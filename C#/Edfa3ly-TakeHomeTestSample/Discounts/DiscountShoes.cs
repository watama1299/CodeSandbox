public class DiscountShoes : IDiscount
{
    public string Description { get { return "10% off shoes"; } }

    public bool CheckValidity( IDictionary<ProductDetails, int> products )
    {
        if ( products == null ) return false;
        if ( !products.Keys.Where( p => p.Type == ItemType.Shoes ).Any() ) return false;
        return true;
    }

    public decimal CalculateDiscount( IDictionary<ProductDetails, int> products )
    {
        var shoeProduct = products.Keys.Where( p => p.Type == ItemType.Shoes ).First();
        var shoeCount = products[ shoeProduct ];

        return shoeProduct.ItemPrice * shoeCount * 0.1m;
    }

}
