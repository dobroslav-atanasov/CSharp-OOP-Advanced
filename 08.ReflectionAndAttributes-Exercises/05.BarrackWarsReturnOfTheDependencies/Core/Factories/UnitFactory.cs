namespace BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            string unitsNamespace = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Select(n => n.Namespace)
                .Distinct()
                .Where(n => n != null)
                .FirstOrDefault(u => u.Contains("Models"));

            Type type = Type.GetType($"{unitsNamespace}.{unitType}");
            IUnit instance = (IUnit) Activator.CreateInstance(type);

            return instance;

            //Second Option:
            //Type type = Type.GetType($"BarracksFactory.Models.Units.{unitType}");
            //IUnit instance = (IUnit)Activator.CreateInstance(type);

            //return instance;
        }
    }
}