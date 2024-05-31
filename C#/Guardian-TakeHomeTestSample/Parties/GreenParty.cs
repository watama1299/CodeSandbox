public class GreenParty : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static GreenParty _greenParty;
    private GreenParty()
    {
        Code = PartyCodes.G;
        Name = "Green Party";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public static IParty GetInstance()
    {
        if ( _greenParty == null ) _greenParty = new GreenParty();
        return _greenParty;
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
