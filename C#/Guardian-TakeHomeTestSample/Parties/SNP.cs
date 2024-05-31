public class SNP : Party
{
    public override PartyCodes Code { get; }
    public override string Name { get; }
    private int _totalVoteCount;
    public override int TotalVoteCount { get { return _totalVoteCount; } }
    public override ICollection<Constituency> ConstituenciesWon { get; }



    private static SNP _snp;
    private SNP()
    {
        Code = PartyCodes.SNP;
        Name = "SNP";
        _totalVoteCount = 0;
        ConstituenciesWon = new List<Constituency>();
    }

    public static IParty GetInstance()
    {
        if ( _snp == null ) _snp = new SNP();
        return _snp;
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
