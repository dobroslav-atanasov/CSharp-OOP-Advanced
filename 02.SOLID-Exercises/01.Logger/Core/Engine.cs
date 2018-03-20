namespace Logger.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Factories;
    using Models;
    using Models.Enums;
    using Models.Interfaces;

    public class Engine
    {
        private List<IAppender> appenders;
        private readonly LayoutFactory layoutFactory;
        private readonly AppenderFactory appenderFactory;

        public Engine()
        {
            this.appenders = new List<IAppender>();
            this.layoutFactory = new LayoutFactory();
            this.appenderFactory = new AppenderFactory();
        }

        public void Run()
        {
            this.ParseInput();
            this.PrintLogger();
        }

        private void PrintLogger()
        {
            Logger logger = new Logger(this.appenders.ToArray());

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] parts = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string methodName = this.GetTitleCase(parts[0]);
                MethodInfo currentMehod = typeof(Logger).GetMethod(methodName);
                currentMehod.Invoke(logger, new object[] {parts[1], parts[2]});
                input = Console.ReadLine();
            }

            Console.WriteLine(logger);
        }

        private void ParseInput()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] inputParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ILayout layout = this.layoutFactory.CreateLayout(inputParts[1]);
                IAppender appender = this.appenderFactory.CreateAppender(inputParts[0], layout);

                if (inputParts.Length > 2)
                {
                    string reportLevel = this.GetTitleCase(inputParts[2]);
                    appender.ReportLevel = Enum.Parse<ReportLevel>(reportLevel);
                }

                this.appenders.Add(appender);
            }
        }

        private string GetTitleCase(string text)
        {
            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return titleCase;
        }
    }
}