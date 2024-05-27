namespace MediaExchangerAlgorithm.Test;

[TestFixture]
public class MediaExchangeGeneratorTest
{
    List<MachineAction> simultaneousExchangeExpected;
    List<MachineAction> nonSimultaneousExchangeExpected;

    [OneTimeSetUp]
    public void Setup()
    {
        simultaneousExchangeExpected = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),

            new MachineAction( ProcessingType.Simultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.Simultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.Simultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.Simultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };

        nonSimultaneousExchangeExpected = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };
    }

    [Test]
    public void GenerateRoutine_Simple_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0,
            0,
            4.5,
            3
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( simultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateRoutine_Simple_NonSimultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.4,
            0,
            0,
            4.5,
            3
        );
        
        // Assert
        Assert.That( actualActions, Is.EqualTo( nonSimultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateRoutine_AspiratorOffset_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0.3,
            0,
            4.5,
            3,
            0.5
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( simultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateRoutine_DispenserOffset_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0,
            0.3,
            4.5,
            3,
            0.5
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( simultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateRoutine_OffsetWithoutTolerance_NonSimultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0,
            0.3,
            4.5,
            3
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( nonSimultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateRoutine_WithTiltAngle_NonSimultaneous_ReturnCorrectActions()
    {
        // Arrange
        var expectedActions = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };

        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0,
            0,
            4.5,
            3,
            0,
            10
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( expectedActions ) );
    }

    [Test]
    public void GenerateRoutine_Complex_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var expectedActions = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };

        var actualActions = MediaExchangeGenerator.GenerateRoutine(
            4.5,
            0,
            0,
            4.4,
            3,
            0.5
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( expectedActions ) );
    }
}