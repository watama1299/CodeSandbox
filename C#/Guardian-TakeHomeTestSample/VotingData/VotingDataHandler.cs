using Microsoft.VisualBasic.FileIO;

public class VotingDataHandler
{
    private void HandleOneRow( string[] rowInput )
    {
        var tempConstituency = new Constituency( rowInput[0] );
        for( int i = 1; i < rowInput.Length; i+=2 )
        {
            var votes = int.Parse( rowInput[i] );
            var code = rowInput[i+1];

            switch( code )
            {
                case "C":
                    tempConstituency.AddPartyVotes( ConservativeParty.GetInstance(), votes );
                    break;
                case "L":
                    tempConstituency.AddPartyVotes( LabourParty.GetInstance(), votes );
                    break;
                case "UKIP":
                    tempConstituency.AddPartyVotes( UKIP.GetInstance(), votes );
                    break;
                case "LD":
                    tempConstituency.AddPartyVotes( LiberalDemocrats.GetInstance(), votes );
                    break;
                case "G":
                    tempConstituency.AddPartyVotes( GreenParty.GetInstance(), votes );
                    break;
                case "Ind":
                    tempConstituency.AddPartyVotes( Independent.GetInstance(), votes );
                    break;
                case "SNP":
                    tempConstituency.AddPartyVotes( SNP.GetInstance(), votes );
                    break;
            }
        }

        VotingData.Constituencies.Add( tempConstituency );
        tempConstituency.PartyVotes.MaxBy( kv => kv.Value ).Key.AddConstituencyWon( tempConstituency );
    }

    public void Handle( string[] input )
    {
        foreach( var row in input )
        {
            var dataColumns = row.Split( ", " );
            HandleOneRow( dataColumns );
        }
    }

    public void HandleCSV( string path )
    {
        try
        {
            // https://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
            using ( var csvParser = new TextFieldParser( path ) )
            {
                csvParser.SetDelimiters( "," );
                csvParser.HasFieldsEnclosedInQuotes = true;

                // skip headers
                csvParser.ReadLine();

                while ( !csvParser.EndOfData )
                {
                    var fields = csvParser.ReadFields();
                    HandleOneRow( fields );
                }
            }
        }
        catch ( ArgumentNullException )
        {
            Console.WriteLine( "invalid path" );
        }
    }
}
