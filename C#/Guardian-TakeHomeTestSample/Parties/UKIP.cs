public class UKIP : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static UKIP _ukip;
    private UKIP()
    {
        Code = PartyCodes.UKIP;
        Name = "UKIP";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public static IParty GetInstance()
    {
        if ( _ukip == null ) _ukip = new UKIP();
        return _ukip;
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
