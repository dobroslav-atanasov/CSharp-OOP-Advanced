using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        Hacker instance = (Hacker)Activator.CreateInstance(classType, new object[] { });
        foreach (FieldInfo info in fieldInfos)
        {
            foreach (string name in fieldsNames)
            {
                if (info.Name == name)
                {
                    sb.AppendLine($"{info.Name} = {info.GetValue(instance)}");
                }
            }
        }

        return sb.ToString().Trim();
    }
}