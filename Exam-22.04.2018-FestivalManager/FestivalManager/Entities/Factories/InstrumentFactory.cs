namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
            IInstrument instrument = (IInstrument) Activator.CreateInstance(classType);
            return instrument;
        }
    }
}