namespace Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Models.Interfaces;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(l => l.Name == layoutType);
            return (ILayout) Activator.CreateInstance(type);
        }
    }
}