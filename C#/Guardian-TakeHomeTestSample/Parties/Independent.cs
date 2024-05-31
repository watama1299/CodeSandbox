public class Independent : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static Independent _independent;
    private Independent()
    {
        Code = PartyCodes.C;
        Name = "Conservative Party";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public static IParty GetInstance()
    {
        if ( _independent == null ) _independent = new Independent();
        return _independent;
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
