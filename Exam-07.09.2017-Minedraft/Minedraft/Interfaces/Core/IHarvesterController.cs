using System.Collections.Generic;

public interface IHarvesterController : IController
{
    double OreProduced { get; }

    string ChangeMode(string mode);

    IReadOnlyCollection<IEntity> Entities { get; }
}