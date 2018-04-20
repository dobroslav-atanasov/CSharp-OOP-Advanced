using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController) 
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double repairValue = double.Parse(this.Arguments[0]);
        string message = this.providerController.Repair(repairValue);

        return message;
    }
}