public interface IAttackGroup
{
    void AddMember(IAttacker attacker);

    void GroupTarget(ITarget target);

    void GroupAttack();
}