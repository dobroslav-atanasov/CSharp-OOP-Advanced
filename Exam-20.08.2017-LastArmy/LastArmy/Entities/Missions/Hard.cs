public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double EnduranceRequiredConst = 80;
    private const double WearLevelConst = 70;

    public Hard(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = MissionName;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelConst;
    }
}