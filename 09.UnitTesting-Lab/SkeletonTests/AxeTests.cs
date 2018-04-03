namespace SkeletonTests
{
    using NUnit.Framework;
    using Skeleton.Models;

    public class AxeTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 1;
        private const int DummyHealth = 20;
        private const int DummyExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void CreateAxeAndDummy()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
            this.axe.Attack(this.dummy);
            
            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(0));
        }

        [Test]
        public void AttackingWithBrokenAxe()
        {
            this.axe.Attack(this.dummy);

            Assert.That(() => this.axe.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}