Console.WriteLine( "Inserting plate all the way...\n" );
Task.Delay( 2000 ).Wait();

Plate plate = new Plate384();
var mediaExchangeExecutor = new MediaExchangerExecutor( plate );
await mediaExchangeExecutor.ExecuteTask( (int) Dispenser.Secondary, 0.5 );