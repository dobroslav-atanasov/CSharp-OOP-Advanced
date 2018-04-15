namespace Forum.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandFactory : ICommandFactory
    {
        private const string Suffix = "Command";

        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + Suffix);

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not found!");
            }
            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType} is not a command!");
            }

            ParameterInfo[] ctorParams = commandType.GetConstructors().First().GetParameters();
            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            ICommand command = (ICommand) Activator.CreateInstance(commandType, args);
            return command;
        }
    }
}