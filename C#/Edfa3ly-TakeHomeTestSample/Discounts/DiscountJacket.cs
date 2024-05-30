public class DiscountJacket : IDiscount
{
    public string Description { get { return "50% off jacket"; } }

    public bool CheckValidity( IDictionary<ProductDetails, int> products )
    {
        if ( products == null ) return false;
        var tshirtCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Tshirt)
                                .Value;
        var blouseCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Blouse)
                                .Value;
        var jacketCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Jacket)
                                .Value;
        if ( tshirtCount + blouseCount >= 2 && jacketCount >= 1 ) return true;
        return false;
    }

    public decimal CalculateDiscount( IDictionary<ProductDetails, int> products )
    {
        var tshirtCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Tshirt)
                                .Value;
        var blouseCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Blouse)
                                .Value;
        var jacketCount = products.AsEnumerable()
                                .FirstOrDefault(kv => kv.Key.Type == ItemType.Jacket)
                                .Value;
        
        var jacketDiscounted = ( tshirtCount + blouseCount ) / 2 < jacketCount ? 
                                    ( tshirtCount + blouseCount ) / 2 :
                                    jacketCount;
        var jacketPrice = products.Keys.FirstOrDefault( p => p.Type == ItemType.Jacket )?.ItemPrice!;

        return ( decimal )( jacketDiscounted * jacketPrice * 0.5m );
    }

}
