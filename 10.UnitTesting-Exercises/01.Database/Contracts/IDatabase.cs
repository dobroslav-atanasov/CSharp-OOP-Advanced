namespace Database.Contracts
{
    public interface IDatabase
    {
        int Capacity { get; }

        int this[int index] { get; }

        void Add(int number);

        int Remove();

        int[] Fetch();
    }
}