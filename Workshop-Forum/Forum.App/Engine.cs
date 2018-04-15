namespace Forum.App
{
    using System;
    using Contracts;

    public class Engine
    {
        private IMainController menu;

        public Engine(IMainController menuController)
        {
            this.menu = menuController;
        }

        internal void Run()
        {
            while (true)
            {
                this.menu.MarkOption();

                var keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

                this.menu.UnmarkOption();

                switch (key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Escape:
                        this.menu.Back();
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        this.menu.PreviousOption();
                        break;
                    case ConsoleKey.Tab:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        this.menu.NextOption();
                        break;
                    case ConsoleKey.Enter:
                        this.menu.Execute();
                        break;
                }
            }
        }
    }
}