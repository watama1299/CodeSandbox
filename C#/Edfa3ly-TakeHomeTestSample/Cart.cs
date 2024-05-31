public class Cart
{
    public IDictionary<ProductDetails, int> ProductsInCart { get; }
    public Cart()
    {
        ProductsInCart = new Dictionary<ProductDetails, int>();
    }

    public bool AddProduct( ProductDetails product )
    {
        if ( product == null ) return false;
        if ( ProductsInCart.ContainsKey( product ) ) ProductsInCart[product] += 1;
        else ProductsInCart.Add( product, 1 );
        return true;
    }

    public bool AddProducts( IEnumerable<ProductDetails> products )
    {
        if ( products == null ) return false;
        foreach ( var product in products )
        {
            AddProduct( product );
        }
        return true;
    }

    public bool RemoveProduct( ProductDetails product )
    {
        if ( !ProductsInCart.ContainsKey(product) ) return false;
        
        ProductsInCart[product] -= 1;
        if ( ProductsInCart[product] == 0 ) ProductsInCart.Remove( product );
        return true;
    }

    public bool RemoveProducts( IEnumerable<ProductDetails> products )
    {
        if ( products == null ) return false;
        foreach ( var product in products )
        {
                RemoveProduct( product );
        }
        return true;
    }
}
