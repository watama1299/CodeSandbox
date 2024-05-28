namespace MediaExchangerAlgorithm.Test;

[TestFixture]
public class MediaExchangeGeneratorTest
{
    List<MachineAction> simultaneousExchangeExpected;

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
    }

    [Test]
    public void GenerateTasks_Simple_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.Generate(
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
    public void GenerateTasks_Simple_NonSimultaneous_ReturnCorrectActions()
    {
        // Arrange
        var expectedActions = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };

        var actualActions = MediaExchangeGenerator.Generate(
            4.4,
            0,
            0,
            4.5,
            3
        );
        
        // Assert
        Assert.That( actualActions, Is.EqualTo( expectedActions ) );
    }

    [Test]
    public void GenerateTasks_Complex_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.Generate(
            4.5,
            0,
            0,
            4.4,
            3,
            0.5
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( simultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateTasks_AspiratorOffset_WithTolerance_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.Generate(
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
    public void GenerateTasks_AspiratorOffset_WithoutTolerance_NonSimultaneous_ReturnCorrectActions()
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

        var actualActions = MediaExchangeGenerator.Generate(
            4.5,
            0.3,
            0,
            4.5,
            3
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( expectedActions ) );
    }

    [Test]
    public void GenerateTasks_DispenserOffset_WithTolerance_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.Generate(
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
    public void GenerateTasks_DispenserOffset_WithoutTolerance_NonSimultaneous_ReturnCorrectActions()
    {
        // Arrange
        var expectedActions = new List<MachineAction>()
        {
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 3 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 3 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 2 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 2 ),
            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, 1 ),

            new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, 1 ),
        };

        var actualActions = MediaExchangeGenerator.Generate(
            4.5,
            0,
            0.3,
            4.5,
            3
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( expectedActions ) );
    }

    [Test]
    public void GenerateTasks_WithTiltAngle_WithTolerance_Simultaneous_ReturnCorrectActions()
    {
        // Arrange
        var actualActions = MediaExchangeGenerator.Generate(
            4.5,
            0,
            0,
            4.5,
            3,
            0.5,
            10
        );

        // Assert
        Assert.That( actualActions, Is.EqualTo( simultaneousExchangeExpected ) );
    }

    [Test]
    public void GenerateTasks_WithTiltAngle_WithoutTolerance_NonSimultaneous_ReturnCorrectActions()
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

        var actualActions = MediaExchangeGenerator.Generate(
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
}