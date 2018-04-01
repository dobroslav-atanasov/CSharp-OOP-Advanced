namespace BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Contracts;

    public class CommandIntrepreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandIntrepreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string fullCommandName = char.ToUpper(commandName[0]) + commandName.Substring(1) + "Command";

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == fullCommandName);

            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
            FieldInfo[] commandFields = instance
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes(typeof(InjectAttribute)) != null)
                .ToArray();

            FieldInfo[] interpreterFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in commandFields)
            {
                if (interpreterFields.Any(i => i.FieldType == field.FieldType))
                {
                    field.SetValue(instance, interpreterFields.First(i => i.FieldType == field.FieldType).GetValue(this));
                }
            }

            return instance;
        }
    }
}