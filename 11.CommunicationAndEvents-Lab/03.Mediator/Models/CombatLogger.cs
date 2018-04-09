using System;

public class CombatLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ATTACK:
                Console.WriteLine(logType.ToString() + ":" + message);
                break;
            case LogType.MAGIC:
                Console.WriteLine(logType.ToString() + ":" + message);
                break;
        }

        this.PassToSuccessor(logType, message);
    }
}