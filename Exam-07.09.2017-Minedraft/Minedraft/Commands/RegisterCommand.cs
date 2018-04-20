using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private const string Harvester = "Harvester";
    private const string Provider = "Provider";
    
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public RegisterCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string message = null;
        string type = this.Arguments[0];

        if (type == Harvester)
        {
            message = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (type == Provider)
        {
            message = this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return message;
    }
}