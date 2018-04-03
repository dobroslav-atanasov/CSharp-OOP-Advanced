namespace SkeletonTests.FakeModels
{
    using Skeleton.Contracts;

    public class FakeWeapon : IWeapon
    {
        private const int DefaultAttackPoints = 10;
        private const int DefaultDurabilityPoints = 20;

        public int AttackPoints => DefaultAttackPoints;

        public int DurabilityPoints => DefaultDurabilityPoints;

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }
}