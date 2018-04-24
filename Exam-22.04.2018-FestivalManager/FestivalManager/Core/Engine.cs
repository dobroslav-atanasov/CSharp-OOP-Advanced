using System;
using System.Linq;

namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private const string EndCommand = "END";

        private IReader reader;
        private IWriter writer;
        private ISetController setController;
        private IFestivalController festivalController;

        public Engine(IReader reader, IWriter writer, ISetController setController,
            IFestivalController festivalController)
        {
            this.reader = reader;
            this.writer = writer;
            this.setController = setController;
            this.festivalController = festivalController;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();
            while (input != EndCommand)
            {
                try
                {
                    string message = this.ProcessCommand(input);
                    this.writer.WriteLine(message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }

                input = this.reader.ReadLine();
            }

            string report = this.festivalController.ProduceReport();
            this.writer.WriteLine(report);
        }

        public string ProcessCommand(string input)
        {
            string[] parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string commandName = parts[0];
            string[] args = parts.Skip(1).ToArray();

            //-----------------------------------------
            if (commandName == "LetsRock")
            {
                var setovete = this.setController.PerformSets();
                return setovete;
            }

            var festivalcontrolfunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            string message;
            try
            {
                message = (string) festivalcontrolfunction.Invoke(this.festivalController, new object[] {args});
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            return message;
        }
        //public IReader chetаch;
        //public IWriter pisаch;

        //public IFestivalController festivalCоntroller = new FestivalController();
        //public ISetController setCоntroller = new SetController();

        //// дайгаз
        //public void Запали()
        //{
        //    while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
        //    {
        //        var input = chetach.ReadLine();

        //        if (input == "END")
        //            break;

        //        try
        //        {
        //            string.Intern(input);

        //            var result = this.DoCommand(input);
        //            this.pisach.WriteLine(result);
        //        }
        //        catch (Exception ex) // in case we run out of memory
        //        {
        //            this.pisach.WriteLine("ERROR: " + ex.Message);
        //        }
        //    }

        //    var end = this.festivalController.Report();

        //    this.pisach.WriteLine("Results:");
        //    this.pisach.WriteLine(end);
        //}

        //public string DoCommand(string input)
        //{
        //    var chasti = input.Split(" ".ToCharArray().First());

        //    var purvoto = chasti.First();
        //    var parametri = chasti.Skip(1).ToArray();

        //    if (purvoto == "LetsRock")
        //    {
        //        var setovete = this.setController.PerformSets();
        //        return setovete;
        //    }

        //    var festivalcontrolfunction = this.festivalController.GetType()
        //        .GetMethods()
        //        .FirstOrDefault(x => x.Name == purvoto);

        //    string a;

        //    try
        //    {
        //        a = (string) festivalcontrolfunction.Invoke(this.festivalController, new object[] {parametri});
        //    }
        //    catch (TargetInvocationException up)
        //    {
        //        throw up; // ha ha
        //    }

        //    return a;
        //}
    }
}