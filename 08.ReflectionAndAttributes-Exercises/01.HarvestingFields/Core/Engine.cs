using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
        Type classType = typeof(HarvestingFields);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic |
                                                 BindingFlags.Public);

        string command = this.reader.ReadLine();
        while (command != "HARVEST")
        {
            switch (command)
            {
                case "private":
                    this.PrintFields(fields.Where(f => f.IsPrivate));
                    break;
                case "protected":
                    this.PrintFields(fields.Where(f => f.IsFamily));
                    break;
                case "public":
                    this.PrintFields(fields.Where(f => f.IsPublic));
                    break;
                case "all":
                    this.PrintFields(fields);
                    break;
            }
            command = this.reader.ReadLine();
        }
    }

    private void PrintFields(IEnumerable<FieldInfo> fields)
    {
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
        }
        sb.Replace("family", "protected");
        this.writer.WriteLine(sb.ToString().Trim());
    }
}