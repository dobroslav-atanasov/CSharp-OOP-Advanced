namespace Forum.App.Commands
{
    using Contracts;

    public class AddReplyCommand : ICommand
    {
        private const string Suffix = "Command";
        private const string MenuSuffix = "Menu";

        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - Suffix.Length) + MenuSuffix;

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