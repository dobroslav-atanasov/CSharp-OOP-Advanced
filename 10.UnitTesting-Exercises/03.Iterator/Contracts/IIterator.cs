namespace Iterator.Contracts
{
    public interface IIterator
    {
        bool Move();

        bool HasNext();

        string Print();
    }
}