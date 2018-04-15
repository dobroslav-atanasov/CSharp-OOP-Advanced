namespace Forum.App.Commands
{
    using Contracts;

    public class ViewPostMenuCommand : ICommand
    {
        private const string Suffix = "Command";

        private IMenuFactory menuFactory;
        private ISession session;

        public ViewPostMenuCommand(IMenuFactory menuFactory, ISession session)
        {
            this.menuFactory = menuFactory;
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - Suffix.Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}