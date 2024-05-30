namespace Edfa3ly_TakeHomeTestSample;

[TestFixture]
public class ProductDetailsTest
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

    [Test]
    public void ChooseProduct_ReturnBlouse()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Blouse );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Blouse ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 10.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 0.3 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.UK ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 3 ) );
        });
    }

    [Test]
    public void ChooseProduct_ReturnPants()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Pants );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Pants ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 64.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 0.9 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.UK ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 3 ) );
        });
    }

    [Test]
    public void ChooseProduct_ReturnSweatpants()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Sweatpants );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Sweatpants ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 84.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 1.1 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.CN ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 2 ) );
        });
    }

    [Test]
    public void ChooseProduct_ReturnJacket()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Jacket );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Jacket ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 199.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 2.2 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.US ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 2 ) );
        });
    }

    [Test]
    public void ChooseProduct_ReturnShoes()
    {
        // Arrange
        var actualProduct = ProductDetails.ChooseProduct( ItemType.Shoes );
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualProduct, Is.Not.Null );
            Assert.That( actualProduct.Type, Is.EqualTo( ItemType.Shoes ) );
            Assert.That( actualProduct.ItemPrice, Is.EqualTo( 79.99m ) );
            Assert.That( actualProduct.Weight, Is.EqualTo( 1.3 ) );
            Assert.That( actualProduct.ShippedFrom, Is.EqualTo( CountryInitials.CN ) );
            Assert.That( actualProduct.ShippingRate, Is.EqualTo( 2 ) );
        });
    }
}