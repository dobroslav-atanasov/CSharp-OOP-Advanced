using System.Collections.Generic;

public interface IProviderController : IController
{
    double TotalEnergyProduced { get; }

    string Repair(double val);

    IReadOnlyCollection<IEntity> Entities { get; }
}