namespace SkeletonTests
{
    using NUnit.Framework;
    using Skeleton.Models;

    public class DummyTests
    {
        private const int DummyHeath = 10;
        private const int DummyExperience = 20;
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const string HeroName = "Ivan";

        private Dummy dummy;
        private Axe axe;
        private Hero hero;

        [SetUp]
        public void CreateDummyAndAxe()
        {
            this.dummy = new Dummy(DummyHeath, DummyExperience);
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.hero = new Hero(HeroName, this.axe);
        }

        [Test]
        public void DummyShouldLoseDurabilityAfterAttack()
        {
            this.axe.Attack(this.dummy);

            Assert.That(this.dummy.Health, Is.EqualTo(0));
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            this.axe.Attack(this.dummy);

            Assert.That(() => this.axe.Attack(this.dummy), Throws.InvalidOperationException);
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            this.hero.Attack(this.dummy);

            Assert.That(this.hero.Experience, Is.EqualTo(20));
        }

        [Test]
        public void AliveDummyShoultNotGiveExperience()
        {
            this.dummy = new Dummy(15, 10);

            this.hero.Attack(this.dummy);

            Assert.That(this.hero.Experience, Is.EqualTo(0));
        }
    }
}