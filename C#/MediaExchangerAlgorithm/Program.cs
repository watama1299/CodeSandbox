Console.WriteLine( "Inserting plate all the way...\n" );
Task.Delay( 2000 ).Wait();

Plate plate = new Plate96();
await MediaExchangeExecutor.ExecuteRoutine(
    plate,
    Dispenser.Primary,
    0.0,
    0.0
    );