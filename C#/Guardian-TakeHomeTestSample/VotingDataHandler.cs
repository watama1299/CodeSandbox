using System.Collections.ObjectModel;

public class VotingDataHandler
{
    public ICollection<Constituency> Constituencies { get; } = new Collection<Constituency>();
    public ICollection<IParty> Parties { get; } = new Collection<IParty>();

    public VotingDataHandler()
    {
        Parties.Add( ConservativeParty.GetInstance() );
        Parties.Add( LabourParty.GetInstance() );
        Parties.Add( UKIP.GetInstance() );
        Parties.Add( LiberalDemocrats.GetInstance() );
        Parties.Add( GreenParty.GetInstance() );
        Parties.Add( Independent.GetInstance() );
        Parties.Add( SNP.GetInstance() );
    }

    public void Handle( string[] input )
    {
        // var dataRows = input.Split( ',' );
        foreach( var row in input )
        {
            var dataColumns = row.Split( ", " );
            var tempConstituency = new Constituency( dataColumns[0] );
            for( int i = 1; i < dataColumns.Length; i+=2 )
            {
                var votes = int.Parse( dataColumns[i] );
                var code = dataColumns[i+1];

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

            Constituencies.Add( tempConstituency );
            tempConstituency.PartyVotes.MaxBy( kv => kv.Value ).Key.AddConstituencyWon( tempConstituency );
        }
    }

    public IParty? ConstituencyWinner( string constituencyName )
    {
        var constituency = Constituencies.Where( c => c.Name == constituencyName ).FirstOrDefault();
        IParty? party = null;
        if ( constituency != null ) party = constituency.PartyVotes.MaxBy( kv => kv.Value ).Key;
        return party;
    }

    public decimal PartyVotePercentage( IParty party )
    {
        var totalVotes = Parties.Sum( p => p.TotalVoteCount );
        var partyVotes = party.TotalVoteCount;

        return Math.Round( ( decimal ) partyVotes / totalVotes, 4 ) * 100;
    }
}
