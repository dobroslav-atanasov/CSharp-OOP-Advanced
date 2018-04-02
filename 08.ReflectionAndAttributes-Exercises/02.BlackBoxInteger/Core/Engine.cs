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
        FieldInfo field = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);

        string input = this.reader.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            string methodName = parts[0];
            int number = int.Parse(parts[1]);

            MethodInfo method = methods.First(m => m.Name == methodName);
            method.Invoke(instance, new object[] {number});
            this.writer.WriteLine(field.GetValue(instance).ToString());

            input = this.reader.ReadLine();
        }
    }
}