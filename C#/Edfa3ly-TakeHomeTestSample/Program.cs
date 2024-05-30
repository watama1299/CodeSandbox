var tshirt = ProductDetails.ChooseProduct( ItemType.Tshirt );
var blouse = ProductDetails.ChooseProduct( ItemType.Blouse );
var pants = ProductDetails.ChooseProduct( ItemType.Pants );
var sweatpants = ProductDetails.ChooseProduct( ItemType.Sweatpants );
var jacket = ProductDetails.ChooseProduct( ItemType.Jacket );
var shoes = ProductDetails.ChooseProduct( ItemType.Shoes );


var userCart = new Cart();
userCart.AddProduct( tshirt );
userCart.AddProduct( blouse );
userCart.AddProduct( pants );
userCart.AddProduct( shoes );
userCart.AddProduct( jacket );


var invoice = Invoice.GenerateInvoice( userCart );
Console.WriteLine( invoice.PrintInvoice() );