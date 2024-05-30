public class DiscountJacket : IDiscount
{
    public string Description { get { return "10% off shoes"; } }

    public bool CheckValidity( IDictionary<ProductDetails, int> products )
    {
        if ( products == null ) return false;
        var tshirtCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Tshirt)
                                .FirstOrDefault()
                                .Value;
        var blouseCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Blouse)
                                .FirstOrDefault()
                                .Value;
        var jacketCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Jacket)
                                .FirstOrDefault()
                                .Value;
        if ( tshirtCount + blouseCount >= 2 && jacketCount >= 1) return true;
        return false;
    }

    public decimal CalculateDiscount( IDictionary<ProductDetails, int> products )
    {
        var tshirtCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Tshirt)
                                .FirstOrDefault()
                                .Value;
        var blouseCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Blouse)
                                .FirstOrDefault()
                                .Value;
        var jacketCount = products.AsEnumerable()
                                .Where( kv => kv.Key.Type == ItemType.Jacket)
                                .FirstOrDefault()
                                .Value;
        
        var jacketDiscounted = ( tshirtCount + blouseCount ) / jacketCount;
        var jacketPrice = products.Keys.FirstOrDefault( p => p.Type == ItemType.Jacket )?.ItemPrice!;

        return ( decimal )( jacketDiscounted * jacketPrice * 0.5m );
    }

}
