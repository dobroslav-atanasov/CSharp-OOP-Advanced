using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IDictionary<string, int> weapons;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
    }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.weapons = new Dictionary<string, int>();
        this.ammunitionFactory = ammunitionFactory;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.CheckSoldierAmmunitions(soldier);
        }
    }

    public void AddAmmunitions(string name, int count)
    {
        if (!this.weapons.ContainsKey(name))
        {
            this.weapons[name] = 0;
        }
        this.weapons[name] += count;
    }

    public bool CheckSoldierAmmunitions(ISoldier soldier)
    {
        IList<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        foreach (string weapon in missingWeapons)
        {
            if (this.weapons.ContainsKey(weapon) && this.weapons[weapon] >= 1)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.weapons[weapon]--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}