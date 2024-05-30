namespace Edfa3ly_TakeHomeTestSample;

[TestFixture]
public class InvoiceTests
{
    [SetUp]
    public void Setup()
    {

    }


    [Test]
    public void ChooseProduct_ReturnTshirt()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Tshirt );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Tshirt ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 30.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 0.2 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.US ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 2 ) );
        });
    }
}
