public class LiberalDemocrats : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static LiberalDemocrats _liberalDemocrats;
    private LiberalDemocrats()
    {
        Code = PartyCodes.C;
        Name = "Conservative Party";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public override IParty GetInstance()
    {
        if ( _liberalDemocrats == null ) _liberalDemocrats = new LiberalDemocrats();
        return _liberalDemocrats;
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
