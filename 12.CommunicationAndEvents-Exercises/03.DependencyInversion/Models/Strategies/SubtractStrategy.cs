namespace DependencyInversion.Models.Strategies
{
    using Interfaces;

    public class SubtractStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}