namespace InfernoInfinity.Contracts
{
    using Enums;

    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        Clarity Clarity { get; }

        void AddClarityBonus();
    }
}