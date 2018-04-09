public class GroupTargetCommand : ICommand
{
    private IAttackGroup attackGroup;
    private ITarget target;

    public GroupTargetCommand(IAttackGroup attackGroup, ITarget target)
    {
        this.attackGroup = attackGroup;
        this.target = target;
    }

    public void Execute()
    {
        this.attackGroup.GroupTarget(this.target);
    }
}