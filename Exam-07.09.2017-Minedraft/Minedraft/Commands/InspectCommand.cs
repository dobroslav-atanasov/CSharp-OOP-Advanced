using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public InspectCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        int searchedId = int.Parse(this.Arguments[0]);

        IEntity entity = this.harvesterController.Entities.FirstOrDefault(e => e.ID == searchedId);

        if (entity == null)
        {
            entity = this.providerController.Entities.FirstOrDefault(e => e.ID == searchedId);
        }

        if (entity == null)
        {
            return string.Format(Constants.EntityNotFound, searchedId);
        }

        return entity.GetType().Name + Environment.NewLine + string.Format(Constants.EntityDuraility, entity.Durability);
    }
}