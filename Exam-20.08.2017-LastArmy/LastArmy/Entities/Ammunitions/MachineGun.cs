public class MachineGun : Ammunition
{
    public const double SpecificWeight = 10.6;

    public MachineGun(string name)
        : base(name, SpecificWeight)
    {
    }
}