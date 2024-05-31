public class Constituency
{
    public string Name { get; }
    public IDictionary<IParty, int> PartyVotes { get; }

    public Constituency( string name )
    {
        Name = name;
        PartyVotes = new Dictionary<IParty,int>();
    }

    public bool AddPartyVotes( IParty party, int voteCount )
    {
        if ( !PartyVotes.ContainsKey( party ) )
        {
            PartyVotes.Add( party, voteCount );
            party.UpdateVoteCount( voteCount );
        }
        // PartyVotes.Add( party, voteCount );
        return true;
    }
}
