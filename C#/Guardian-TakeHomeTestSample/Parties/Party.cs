
public abstract class Party : IParty
{
    public virtual PartyCodes Code { get; }
    public virtual string Name { get; }
    private int _totalVoteCount;
    public virtual int TotalVoteCount { get { return _totalVoteCount; } }
    public virtual ICollection<Constituency> ConstituenciesWon { get; }


    // public abstract IParty GetInstance();
    public abstract bool AddConstituencyWon(Constituency constituency);
    public abstract bool UpdateVoteCount(int voteCount);

}
