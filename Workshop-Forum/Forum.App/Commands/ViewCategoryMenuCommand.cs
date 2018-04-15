namespace Forum.App.Commands
{
    using Contracts;

    public class ViewCategoryMenuCommand : ICommand
    {
        private const string Suffix = "Command";

        private IMenuFactory menuFactory;

        public ViewCategoryMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - Suffix.Length);

            IIdHoldingMenu menu = (IIdHoldingMenu) this.menuFactory.CreateMenu(menuName);
            menu.SetId(categoryId);

            return menu;
        }
    }
}