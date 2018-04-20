public class SolarProvider : Provider
{
    private const double DurabilityBonus = 500;

    public SolarProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability += DurabilityBonus;
    }
}