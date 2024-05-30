using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

public static class AllDiscounts
{
    public static ICollection<IDiscount> DiscountTypes
    {
        get
        {
            return new Collection<IDiscount>()
            {
                new DiscountJacket(),
                new DiscountShipping(),
                new DiscountShoes()
            };
        }
    }
}