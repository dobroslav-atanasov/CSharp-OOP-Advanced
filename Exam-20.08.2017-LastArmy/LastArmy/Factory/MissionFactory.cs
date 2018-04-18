using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);
        IMission mission = (IMission)Activator.CreateInstance(type, new object[] { neededPoints });
        return mission;
    }
}