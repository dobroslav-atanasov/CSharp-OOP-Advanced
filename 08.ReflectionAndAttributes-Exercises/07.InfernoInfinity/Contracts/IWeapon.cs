namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        
        int MinDamage { get; }

        int MaxDamage { get; }

        IGem[] Sockets { get; }

        void AddGem(int socketIndex, IGem gem);

        void RemoveGem(int socketIndex);

        void AddRarityBonus();
    }
}