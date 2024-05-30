var tshirt = ProductDetails.ProductFactory( ItemType.Tshirt );
var blouse = ProductDetails.ProductFactory( ItemType.Blouse );
var pants = ProductDetails.ProductFactory( ItemType.Pants );
var sweatpants = ProductDetails.ProductFactory( ItemType.Sweatpants );
var jacket = ProductDetails.ProductFactory( ItemType.Jacket );
var shoes = ProductDetails.ProductFactory( ItemType.Shoes );


var userCart = new Cart();
userCart.AddProduct( tshirt );
userCart.AddProduct( blouse );
userCart.AddProduct( pants );
userCart.AddProduct( shoes );
userCart.AddProduct( jacket );


var invoice = Invoice.GenerateInvoice( userCart );
Console.WriteLine( invoice.PrintInvoice() );