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
            Type type = Type.GetType($"BarracksFactory.Models.Units.{unitType}");
            IUnit instance = (IUnit)Activator.CreateInstance(type);

            return instance;
        }
    }
}