using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        double totalEnergy = this.providerController.TotalEnergyProduced;
        double totalOreOutput = this.harvesterController.OreProduced;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutdown)
            .AppendLine(string.Format(Constants.TotalEnergyProduced, totalEnergy))
            .AppendLine(string.Format(Constants.TotalMinedOre, totalOreOutput));

        return sb.ToString().Trim();
    }
}