namespace SkeletonTests
{
    using FakeModels;
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;
    using Skeleton.Models;

    public class HeroTests
    {
        private const int ExpectedHeroExperience = 20;
        private const int DefaultHealth = 0;
        private const int DefaultExperience = 20;

        [Test]
        public void HeroShouldGainExperienceWhenTargetDies()
        {
            IWeapon weapon = new FakeWeapon();
            ITarget target = new FakeTarget();
            Hero hero = new Hero("Ivan", weapon);

            hero.Attack(target);

            Assert.That(hero.Experience, Is.EqualTo(ExpectedHeroExperience));
        }

        [Test]
        public void HeroShouldGainExperienceWhenTargetDiesWithMocking()
        {
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(DefaultHealth);
            target.Setup(t => t.GiveExperience()).Returns(DefaultExperience);
            target.Setup(t => t.IsDead()).Returns(true);
            Mock<IWeapon> weapon = new Mock<IWeapon>();
            Hero hero = new Hero("Ivan", weapon.Object);

            hero.Attack(target.Object);

            Assert.That(hero.Experience, Is.EqualTo(ExpectedHeroExperience));
        }
    }
}