namespace Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Models.Interfaces;

    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderType, ILayout layout)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == appenderType);
            return (IAppender) Activator.CreateInstance(type, layout);
        }
    }
}