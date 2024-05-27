class Program
{
    static async Task Main(string[] args)
    {
        Plate plate = new Plate384();
        await MediaExchangeExecutor.ExecuteRoutine(
            plate,
            Dispenser.Primary,
            0.5,
            0.0
            );
    }
}

