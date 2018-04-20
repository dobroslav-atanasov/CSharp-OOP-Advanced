using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";

    public CommandInterpreter(IProviderController providerController, IHarvesterController harvesterController)
    {
        this.ProviderController = providerController;
        this.HarvesterController = harvesterController;
    }

    public IProviderController ProviderController { get; }

    public IHarvesterController HarvesterController { get; }
    
    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.ExecuteCommand(args);
        string message = command.Execute();

        return message;
    }

    private ICommand ExecuteCommand(IList<string> args)
    {
        string commandName = args[0] + Suffix;

        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName);

        if (type == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }
        if (!typeof(ICommand).IsAssignableFrom(type))
        {
            throw new ArgumentException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo constructor = type.GetConstructors().First();
        ParameterInfo[] parameterInfos = constructor.GetParameters();
        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameterInfos.Length; i++)
        {
            Type parameterType = parameterInfos[i].ParameterType;

            if (parameterType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo propertyInfo = this.GetType().GetProperties().FirstOrDefault(p => p.PropertyType == parameterType);
                parameters[i] = propertyInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand) Activator.CreateInstance(type, parameters);
        return command;
    }
}