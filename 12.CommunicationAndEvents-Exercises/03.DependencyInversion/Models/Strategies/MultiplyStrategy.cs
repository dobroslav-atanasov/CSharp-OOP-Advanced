namespace DependencyInversion.Models.Strategies
{
    using Interfaces;

    public class MultiplyStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}