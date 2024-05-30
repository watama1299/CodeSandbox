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
                new DiscountShoes(),
                new DiscountJacket(),
                new DiscountShipping()
            };
        }
    }
}