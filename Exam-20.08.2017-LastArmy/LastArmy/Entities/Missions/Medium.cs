public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const double EnduranceRequiredConst = 50;
    private const double WearLevelConst = 50;

    public Medium(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = MissionName;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelConst;
    }
}