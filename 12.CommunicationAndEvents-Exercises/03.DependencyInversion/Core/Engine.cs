namespace DependencyInversion.Core
{
    using System;
    using System.Collections.Generic;
    using IO;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;
    using Models.Strategies;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private IDictionary<char, IStrategy> symbols;
        private IPrimitiveCalculator calculator;

        public Engine()
        {
            this.reader = new ConsoleReadLine();
            this.writer = new ConsoleWriteLine();
            this.symbols = new Dictionary<char, IStrategy>();
            this.GetSymbols();
            this.calculator = new PrimitiveCalculator();
        }

        public void Run()
        {
            string command = this.reader.ReadLine();
            while (command != "End")
            {
                string[] commandParts = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (commandParts[0] == "mode")
                {
                    IStrategy newStrategy = this.symbols[commandParts[1][0]];
                    this.calculator.ChangeStrategy(newStrategy);
                }
                else
                {
                    int firstOperand = int.Parse(commandParts[0]);
                    int secondOperand = int.Parse(commandParts[1]);
                    int result = this.calculator.PerformCalculation(firstOperand, secondOperand);
                    this.writer.WriteLine(result.ToString());
                }
                command = this.reader.ReadLine();
            }
        }

        private void GetSymbols()
        {
            this.symbols.Add('+', new AddStrategy());
            this.symbols.Add('-', new SubtractStrategy());
            this.symbols.Add('*', new MultiplyStrategy());
            this.symbols.Add('/', new DivideStrategy());
        }
    }
}