using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[0];
        string message = this.harvesterController.ChangeMode(mode);

        return message;
    }
}