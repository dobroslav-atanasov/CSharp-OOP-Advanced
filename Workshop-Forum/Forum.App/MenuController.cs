namespace Forum.App
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Contracts;
    using Menus;

    internal class MenuController : IMainController
    {
        private IServiceProvider serviceProvider;
        private IForumViewEngine viewEngine;
        private ISession session;
        private ICommandFactory commandFactory;

        public MenuController(IServiceProvider serviceProvider, IForumViewEngine viewEngine, ISession session, ICommandFactory commandFactory)
        {
            this.serviceProvider = serviceProvider;
            this.viewEngine = viewEngine;
            this.session = session;
            this.commandFactory = commandFactory;

            this.InitializeSession();
        }

        //This part has to delete!!!!!!!!!!!!!1
        //public MenuController(ILabelFactory labelFactory, IForumViewEngine viewEngine)
        //{
        //    this.viewEngine = viewEngine;

        //    this.CurrentMenu = new MainMenu(null, labelFactory, null);
        //    this.RenderCurrentView();
        //}

        private string Username { get; set; }

        //Replace CurrentMenu with this after implementing Session
        private IMenu CurrentMenu => this.session.CurrentMenu;

        //This part has to delete!!!!!!!!!!!!
        //private IMenu CurrentMenu { get; }

        private void InitializeSession()
        {
            this.session.PushView(new MainMenu(this.session,
                this.serviceProvider.GetService<ILabelFactory>(),
                this.serviceProvider.GetService<ICommandFactory>()));

            this.RenderCurrentView();
        }

        private void RenderCurrentView()
        {
            this.viewEngine.RenderMenu(this.CurrentMenu);
        }

        public void MarkOption()
        {
            this.viewEngine.Mark(this.CurrentMenu.CurrentOption);
        }

        public void UnmarkOption()
        {
            this.viewEngine.Mark(this.CurrentMenu.CurrentOption, false);
        }

        public void NextOption()
        {
            this.CurrentMenu.NextOption();
        }

        public void PreviousOption()
        {
            this.CurrentMenu.PreviousOption();
        }

        public void Back()
        {
            this.session.Back();
            RenderCurrentView();
        }

        public void Execute()
        {
            this.session.PushView(this.CurrentMenu.ExecuteCommand());
            this.RenderCurrentView();
        }
    }
}