namespace Logger.Models.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string time, string reportLevel, string message);
    }
}