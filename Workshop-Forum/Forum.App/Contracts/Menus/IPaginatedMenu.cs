namespace Forum.App.Contracts
{
    public interface IPaginatedMenu : IMenu
    {
        void ChangePage(bool forward = true);
    }
}