using NUnit.Framework;

public class Tests
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void SetUp()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }

    [Test]
    public void TestCorrectAddInMissionQueue()
    {
        IMission mission = new Easy(10);

        this.missionController.PerformMission(mission);

        Assert.That(this.missionController.Missions.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestMissionQueueWithMoreThanThreeMissions()
    {
        IMission firstMission = new Easy(10);
        IMission secondMission = new Easy(20);
        IMission thirdMission = new Easy(30);
        IMission fourthMission = new Easy(40);

        this.missionController.PerformMission(firstMission);
        this.missionController.PerformMission(secondMission);
        this.missionController.PerformMission(thirdMission);
        this.missionController.PerformMission(fourthMission);

        Assert.That(this.missionController.Missions.Count, Is.EqualTo(3));
    }

    [Test]
    public void TestMissionCompleteMessage()
    {
        IMission mission = new Easy(20);
        this.wareHouse.AddAmmunitions("Gun", 2);
        this.wareHouse.AddAmmunitions("AutomaticMachine", 2);
        this.wareHouse.AddAmmunitions("Helmet", 2);

        ISoldier soldier = new Ranker("Ivan", 20, 50, 50);
        this.army.AddSoldier(soldier);
        this.wareHouse.EquipArmy(this.army);

        string message = this.missionController.PerformMission(mission).Trim();

        Assert.That(message, Is.EqualTo($"Mission completed - {mission.Name}"));
    }
}