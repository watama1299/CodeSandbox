public static class VotingData
{
    public static ICollection<Constituency> Constituencies { get; } = new List<Constituency>();
    public static ICollection<IParty> Parties { get; } = new List<IParty>()
    {
        ConservativeParty.GetInstance(),
        LabourParty.GetInstance(),
        UKIP.GetInstance(),
        LiberalDemocrats.GetInstance(),
        GreenParty.GetInstance(),
        Independent.GetInstance(),
        SNP.GetInstance()
    };


    public static IParty? ConstituencyWinner( string constituencyName )
    {
        var constituency = Constituencies.Where( c => c.Name == constituencyName ).FirstOrDefault();
        IParty? party = null;
        if ( constituency != null ) party = constituency.PartyVotes.MaxBy( kv => kv.Value ).Key;
        return party;
    }

    public static decimal PartyVotePercentage( IParty party )
    {
        var totalVotes = Parties.Sum( p => p.TotalVoteCount );
        var partyVotes = party.TotalVoteCount;

        return Math.Round( ( decimal ) partyVotes / totalVotes * 100m, 4 );
    }
}