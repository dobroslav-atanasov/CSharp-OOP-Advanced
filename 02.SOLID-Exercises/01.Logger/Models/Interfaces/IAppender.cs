namespace Logger.Models.Interfaces
{
    using Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string time, string reportLevel, string message);
    }
}