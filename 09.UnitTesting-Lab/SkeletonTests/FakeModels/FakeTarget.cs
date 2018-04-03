namespace SkeletonTests.FakeModels
{
    using Skeleton.Contracts;

    public class FakeTarget : ITarget
    {
        private const int DefaultHealth = 0;
        private const int DefaultExperience = 20;

        public int Health => DefaultHealth;

        public int GiveExperience()
        {
            return DefaultExperience;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
        }
    }
}