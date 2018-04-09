public interface IHandler
{
    void Handle(LogType logType, string message);

    void SetSuccessor(IHandler handler);
}