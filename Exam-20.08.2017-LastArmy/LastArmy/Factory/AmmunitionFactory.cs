using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == ammunitionName);
        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(type, new object[] { ammunitionName });
        return ammunition;
    }
}