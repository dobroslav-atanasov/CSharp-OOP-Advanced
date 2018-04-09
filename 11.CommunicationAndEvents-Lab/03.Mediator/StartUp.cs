public class StartUp
{
    public static void Main()
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        Warrior firstWarrior = new Warrior("Torsten", 10, combatLogger);
        Warrior secondWarrior = new Warrior("Rolo", 20, combatLogger);
        Dragon dragon = new Dragon("Transylvanian White", 200, 25, combatLogger);

        IAttackGroup group = new Group();
        group.AddMember(firstWarrior);
        group.AddMember(secondWarrior);
        
        IExecutor executor = new CommandExecutor();

        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand groupAttack = new GroupAttackCommand(group);
    }
}