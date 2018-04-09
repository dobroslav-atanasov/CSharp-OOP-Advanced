public class TargetCommand : ICommand
{
    private IAttacker attacker;
    private ITarget target;

    public TargetCommand(IAttacker attacker, ITarget target)
    {
        this.attacker = attacker;
        this.target = target;
    }

    public void Execute()
    {
        this.attacker.SetTarget(this.target);
    }
}