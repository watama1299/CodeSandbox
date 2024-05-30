public interface IDiscount
{
    public string Description { get; }

    public bool CheckValidity( IDictionary<ProductDetails, int> products );
    public decimal CalculateDiscount( IDictionary<ProductDetails, int> products );
}
