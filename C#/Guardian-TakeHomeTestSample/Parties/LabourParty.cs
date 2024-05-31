public class LabourParty : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static LabourParty _labourParty;
    private LabourParty()
    {
        Code = PartyCodes.C;
        Name = "Labour Party";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public override IParty GetInstance()
    {
        if ( _labourParty == null ) _labourParty = new LabourParty();
        return _labourParty;
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
