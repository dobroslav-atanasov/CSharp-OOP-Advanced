public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name { get; protected set; }

    public double EnduranceRequired { get; protected set; }

    public double ScoreToComplete { get; }

    public double WearLevelDecrement { get; protected set; }
}