namespace EventImplementation.Core
{
    using System;
    using Models;

    public class Engine
    {
        public void Run()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name = Console.ReadLine();
            while (name != "End")
            {
                dispatcher.Name = name;
                name = Console.ReadLine();
            }
        }
    }
}