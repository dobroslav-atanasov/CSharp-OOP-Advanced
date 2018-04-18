public class Helmet : Ammunition
{
    public const double SpecificWeight = 2.3;

    public Helmet(string name)
        : base(name, SpecificWeight)
    {
    }
}