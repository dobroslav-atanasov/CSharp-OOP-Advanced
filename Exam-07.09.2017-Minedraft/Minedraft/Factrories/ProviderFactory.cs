using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string Suffix = "Provider";

    public IProvider GenerateProvider(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);
        
        Assembly assembly = Assembly.GetCallingAssembly();
        Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name == type + Suffix);
        IProvider provider = (IProvider) Activator.CreateInstance(classType, id, energyOutput);
        return provider;
    }
}