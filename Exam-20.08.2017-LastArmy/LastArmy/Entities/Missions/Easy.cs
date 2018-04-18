public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";
    private const double EnduranceRequiredConst = 20;
    private const double WearLevelConst = 30;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete)
    {
        this.Name = MissionName;
        this.EnduranceRequired = EnduranceRequiredConst;
        this.WearLevelDecrement = WearLevelConst;
    }
}