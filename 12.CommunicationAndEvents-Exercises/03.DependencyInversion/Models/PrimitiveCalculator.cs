namespace DependencyInversion.Models
{
    using Interfaces;
    using Strategies;

    public class PrimitiveCalculator : IPrimitiveCalculator
    {
        private IStrategy calculatorStrategy;

        public PrimitiveCalculator()
            : this(new AddStrategy())
        {
            
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.calculatorStrategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.calculatorStrategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculatorStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}