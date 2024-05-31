public class ConservativeParty : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static ConservativeParty _conservativeParty;
    private ConservativeParty()
    {
        Code = PartyCodes.C;
        Name = "Conservative Party";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public override IParty GetInstance()
    {
        if ( _conservativeParty == null ) _conservativeParty = new ConservativeParty();
        return _conservativeParty;
    }



    public override bool AddConstituencyWon( Constituency constituency )
    {
        ConstituenciesWon.Add( constituency );
        return true;
    }

    public override bool UpdateVoteCount( int voteCount )
    {
        _totalVoteCount += voteCount;
        return true;
    }

}
