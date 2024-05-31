using System.Collections.ObjectModel;

namespace Edfa3ly_TakeHomeTestSample;

[TestFixture]
public class CartTests
{
    [SetUp]
    public void Setup()
    {

    }


    [Test]
    public void InstantiateCart_ReturnNonEmptyCart()
    {
        // Arrange
        var actualCart = new Cart();
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart, Is.Not.Null );
            Assert.That( actualCart.ProductsInCart, Is.Not.Null );
        });
    }

    [Test]
    public void AddProduct_ReturnTrue()
    {
        // Arrange
        var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
        var actualCart = new Cart();

        // Act
        var success = actualCart.AddProduct( tshirt );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart, Is.Not.Empty );
            Assert.That( success, Is.True );
            Assert.That( actualCart.ProductsInCart.ContainsKey( tshirt ), Is.True );
        });
    }

    [Test]
    public void AddProduct_ReturnFalse()
    {
        // Arrange
        var actualCart = new Cart();

        // Act
        var success = actualCart.AddProduct( null );

        // Assert
        Assert.That( success, Is.False );
    }

    [Test]
    public void AddProducts_ReturnTrue()
    {
        // Arrange
        var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
        var jacket = ProductDetails.ChooseProduct( ItemType.Jacket );
        var items = new Collection<ProductDetails> { jacket, tshirt };
        var actualCart = new Cart();

        // Act
        var success = actualCart.AddProducts( items );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart, Is.Not.Empty );
            Assert.That( success, Is.True );
            Assert.That( actualCart.ProductsInCart.ContainsKey( tshirt ), Is.True );
            Assert.That( actualCart.ProductsInCart.ContainsKey( jacket ), Is.True );
        });
    }

    [Test]
    public void AddProducts_ReturnFalse()
    {
        // Arrange
        var actualCart = new Cart();

        // Act
        var success = actualCart.AddProducts( null );

        // Assert
        Assert.That( success, Is.False );
    }

    [Test]
    public void RemoveProduct_ReturnTrue()
    {
        // Arrange
        var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
        var actualCart = new Cart();

        // Act
        actualCart.AddProduct( tshirt );
        var success = actualCart.RemoveProduct( tshirt );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart.Count, Is.EqualTo( 0 ) );
            Assert.That( success, Is.True );
            Assert.That( actualCart.ProductsInCart.ContainsKey( tshirt ), Is.False );
        });
    }

    [Test]
    public void RemoveProduct_ReturnFalse()
    {
        // Arrange
        var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
        var actualCart = new Cart();

        // Act
        var success = actualCart.RemoveProduct( tshirt );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart.Count, Is.EqualTo( 0 ) );
            Assert.That( success, Is.False );
            Assert.That( actualCart.ProductsInCart.ContainsKey( tshirt ), Is.False );
        });
    }

    [Test]
    public void RemoveProducts_ReturnTrue()
    {
        // Arrange
        var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
        var jacket = ProductDetails.ChooseProduct( ItemType.Jacket );
        var itemsToAdd = new Collection<ProductDetails> { jacket, tshirt, jacket };
        var itemsToRemove = new Collection<ProductDetails> { jacket, tshirt };
        var actualCart = new Cart();

        // Act
        actualCart.AddProducts( itemsToAdd );
        var success = actualCart.RemoveProducts( itemsToRemove );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart.Count, Is.EqualTo( 1 ) );
            Assert.That( success, Is.True );
            Assert.That( actualCart.ProductsInCart.ContainsKey( tshirt ), Is.False );
            Assert.That( actualCart.ProductsInCart.ContainsKey( jacket ), Is.True );
        });
    }

    [Test]
    public void RemoveProducts_ReturnFalse()
    {
        // Arrange
        var actualCart = new Cart();

        // Act
        var success = actualCart.RemoveProducts( null );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( actualCart.ProductsInCart.Count, Is.EqualTo( 0 ) );
            Assert.That( success, Is.False );
        });
    }
}
