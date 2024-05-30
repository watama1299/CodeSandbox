public class DiscountShipping : IDiscount
{
    public string Description { get { return "$10 off shipping"; } }

    public bool CheckValidity( IDictionary<ProductDetails, int> products )
    {
        if ( products == null ) return false;

        int totalProducts = 0;
        foreach ( var product in products )
        {
            totalProducts += product.Value;
        }
        if ( totalProducts < 2 ) return false;
        else return true;
    }

    public decimal CalculateDiscount( IDictionary<ProductDetails, int> products )
    {
        return 10m;
    }

}
