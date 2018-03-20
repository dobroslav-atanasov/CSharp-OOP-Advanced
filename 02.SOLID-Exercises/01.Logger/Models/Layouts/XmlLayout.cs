namespace Logger.Models.Layouts
{
    using System.Text;
    using Interfaces;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string time, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>")
                .AppendLine($"    <data>{time}</data>")
                .AppendLine($"    <level>{reportLevel}</level>")
                .AppendLine($"    <message>{message}</message>")
                .Append("</log>");

            return sb.ToString();
        }
    }
}