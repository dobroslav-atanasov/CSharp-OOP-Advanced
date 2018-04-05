namespace ExtendedDatabase.Contracts
{
    public interface IDatabase
    {
        int Count { get; }

        void Add(IPerson person);

        void Remove(IPerson person);

        IPerson FindById(long id);

        IPerson FindByUsername(string username);
    }
}