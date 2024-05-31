public interface IParty
{
    public PartyCodes Code { get; }
    public string Name { get; }
    public int TotalVoteCount { get; }
    public ICollection<Constituency> ConstituenciesWon { get; }


    // public IParty GetInstance();
    public bool UpdateVoteCount( int voteCount );
    public bool AddConstituencyWon( Constituency constituency );
}
