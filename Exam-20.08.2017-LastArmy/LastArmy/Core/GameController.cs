using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private const string Suffix = "Command";
    private const string Regenerate = "Regenerate";

    private IWriter writer;
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(IWriter writer, IArmy army, IWareHouse wareHouse, MissionController missionController,
        ISoldierFactory soldierFactory, IMissionFactory missionFactory)
    {
        this.writer = writer;
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
    }

    public void ParseCommand(string input)
    {
        IList<string> parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
        string command = parts[0];
        parts.RemoveAt(0);

        switch (command)
        {
            case "Soldier":
                this.SoldierCommand(parts);
                break;
            case "WareHouse":
                this.WareHouseCommand(parts);
                break;
            case "Mission":
                this.MissionCommand(parts);
                break;
        }
    }

    private void SoldierCommand(IList<string> parts)
    {
        if (parts[0] == Regenerate)
        {
            string soldierType = parts[1];
            this.army.RegenerateTeam(soldierType);
        }
        else
        {
            this.AddSoldiersInArmy(parts);
        }
    }

    private void AddSoldiersInArmy(IList<string> parts)
    {
        string type = parts[0];
        string name = parts[1];
        int age = int.Parse(parts[2]);
        double experience = double.Parse(parts[3]);
        double endurance = double.Parse(parts[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
        if (!this.wareHouse.CheckSoldierAmmunitions(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponForSoldier, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void WareHouseCommand(IList<string> parts)
    {
        string ammunitionName = parts[0];
        int count = int.Parse(parts[1]);

        this.wareHouse.AddAmmunitions(ammunitionName, count);
    }

    private void MissionCommand(IList<string> parts)
    {
        string missionType = parts[0];
        double scoreToComplete = double.Parse(parts[1]);

        IMission mission = this.missionFactory.CreateMission(missionType, scoreToComplete);
        this.writer.WriteLine(this.missionController.PerformMission(mission).Trim());
    }

    public void PrintSummary()
    {
        this.missionController.FailMissionsOnHold();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(OutputMessages.Result)
            .AppendLine(string.Format(OutputMessages.NumberOfSuccessfulMissions,
                this.missionController.SuccessMissionCounter))
            .AppendLine(string.Format(OutputMessages.NumberOfFailedMissions,
                this.missionController.FailedMissionCounter))
            .AppendLine(OutputMessages.Soldiers);

        IList<ISoldier> orderSoldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        foreach (ISoldier soldier in orderSoldiers)
        {
            sb.AppendLine(string.Format(OutputMessages.SoldierToString, soldier.Name, soldier.OverallSkill));
        }

        this.writer.WriteLine(sb.ToString().Trim());
    }
}