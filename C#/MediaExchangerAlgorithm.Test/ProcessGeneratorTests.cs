namespace MediaExchangerAlgorithm.Test;

[TestFixture]
public class ProcessGeneratorTest
{
    private const int nTimes = 4;
    private const int nPrePost = 4;
    private const int rowCount = 8;

    private List<List<MachineAction>> simProcExpected;
    private List<List<MachineAction>> nonSimProcExpected;

    [OneTimeSetUp]
    public void Setup()
    {
        simProcExpected = new();
        nonSimProcExpected = new();

        for ( int i = nTimes; i > 0; i-- )
        {
            var disp = TaskGenerator.GetDispenseActions( i + nPrePost, rowCount );
            var asp = TaskGenerator.GetAspirateActions( i, rowCount );

            simProcExpected.Add( asp.Concat( disp ).ToList() );

            nonSimProcExpected.Add( disp.ToList() );
            nonSimProcExpected.Add( asp.ToList() );
        }
    }

    [Test]
    public void GetAspirateActions_ReturnCorrectActions()
    {
        // Arrange
        var generatedActions = MediaExchangeGenerator.SimultaneousProcess( nTimes, nPrePost, rowCount );

        // Assert
        Assert.That( generatedActions, Is.EqualTo( simProcExpected ) );
    }

    [Test]
    public void GetDispenseActions_ReturnCorrectActions()
    {
        // Arrange
        var generatedActions = MediaExchangeGenerator.NonSimultaneousProcess( nTimes, nPrePost, rowCount );

        // Assert
        Assert.That( generatedActions, Is.EqualTo( nonSimProcExpected ) );
    }
}