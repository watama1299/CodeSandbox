namespace MediaExchangerAlgorithm.Test;

[TestFixture]
public class TaskGeneratorTest
{
    // private const int colNum = 12;
    // private const int rowCount = 8;

    // private List<Coordinate> coordinates;
    // private List<MachineAction> aspirateActions;
    // private List<MachineAction> dispenseActions;

    // [OneTimeSetUp]
    // public void Setup()
    // {
    //     coordinates = new();
    //     aspirateActions = new();
    //     dispenseActions = new();

    //     for( int i = 1; i <= rowCount; i++ )
    //     {
    //         var tempCoordinate = new Coordinate( colNum, i );

    //         coordinates.Add( tempCoordinate );
    //         aspirateActions.Add( new MachineAction( ActionType.Aspirate, tempCoordinate ) );
    //         dispenseActions.Add( new MachineAction( ActionType.Dispense, tempCoordinate ) );
    //     }
    // }

    // [Test]
    // public void GetAspirateActions_ReturnCorrectActions()
    // {
    //     // Arrange
    //     var generatedActions = TaskGenerator.GetAspirateActions( colNum, rowCount );

    //     // Assert
    //     Assert.That( generatedActions.SequenceEqual( aspirateActions ), Is.True );
    // }

    // [Test]
    // public void GetDispenseActions_ReturnCorrectActions()
    // {
    //     // Arrange
    //     var generatedActions = TaskGenerator.GetDispenseActions( colNum, rowCount );

    //     // Assert
    //     Assert.That( generatedActions.SequenceEqual( dispenseActions ), Is.True );
    // }

    // [Test]
    // public void GetRowCoordinates_ReturnCorrectCoordinates()
    // {
    //     // Arrange
    //     var generatedCoordinates = TaskGenerator.GetRowCoordinates( colNum, rowCount );

    //     // Assert
    //     Assert.That( generatedCoordinates.SequenceEqual( coordinates ), Is.True );
    // }
}