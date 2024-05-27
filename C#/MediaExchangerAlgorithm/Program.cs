Console.WriteLine( "Inserting plate all the way...\n" );
Task.Delay( 2000 ).Wait();

Plate plate = new Plate384();
await MediaExchangeExecutor.ExecuteRoutine(
    plate,
    Dispenser.Secondary,
    0.0,
    0.0
    );