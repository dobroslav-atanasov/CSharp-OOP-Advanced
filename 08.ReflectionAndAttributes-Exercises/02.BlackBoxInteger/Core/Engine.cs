using System;
using System.Linq;
using System.Reflection;

public class Engine
{
    private IReader reader;
    private IWriter writer;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
    }

    public void Run()
    {
        Type classType = typeof(BlackBoxInteger);
        BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

        string input = this.reader.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            string methodName = parts[0];
            int number = int.Parse(parts[1]);

            MethodInfo method = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(instance, new object[] { number });

            string value = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First().GetValue(instance).ToString();
            this.writer.WriteLine(value);

            input = this.reader.ReadLine();
        }
    }
}