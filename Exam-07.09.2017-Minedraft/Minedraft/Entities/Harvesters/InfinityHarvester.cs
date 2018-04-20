using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;
    private const double InitialDurability = 1000;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = InitialDurability;
    }
}