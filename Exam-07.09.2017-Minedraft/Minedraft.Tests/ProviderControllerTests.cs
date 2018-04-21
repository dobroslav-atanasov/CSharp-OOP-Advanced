using System.Collections.Generic;
using NUnit.Framework;

public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void SetUp()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void TestTotalProducedEnergy()
    {
        IList<string> args = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(args);
        this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(100));
    }

    [Test]
    public void TestIsDeletedBrokenProveder()
    {
        IList<string> args = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(args);

        for (int i = 0; i < 11; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}