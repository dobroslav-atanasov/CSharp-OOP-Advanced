using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string Suffix = "Harvester";

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        Assembly assembly = Assembly.GetCallingAssembly();
        Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name == type + Suffix);
        IHarvester harvester = (IHarvester) Activator.CreateInstance(classType, id, oreOutput, energyRequirement);
        return harvester;
    }
}