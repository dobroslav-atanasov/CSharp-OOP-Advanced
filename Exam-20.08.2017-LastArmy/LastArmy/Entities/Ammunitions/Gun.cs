public class Gun : Ammunition
{
    public const double SpecificWeight = 1.4;

    public Gun(string name)
        : base(name, SpecificWeight)
    {
    }
}