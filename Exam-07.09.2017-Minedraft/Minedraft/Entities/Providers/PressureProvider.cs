public class PressureProvider : Provider
{
    private const double EnergyOutputMultiplier = 2;
    private const double DurabilityLoss = 300;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput *= EnergyOutputMultiplier;
        this.Durability -= DurabilityLoss;
    }
}