namespace Logger.Models.Loggers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogOut
    {
        private const string FilaPath = "log.txt";

        private StringBuilder stringBuilder;

        public LogOut()
        {
            this.stringBuilder = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string formatMessage)
        {
            this.stringBuilder.AppendLine(formatMessage);
            File.AppendAllText(FilaPath, formatMessage + Environment.NewLine);
            this.Size = this.GetMessageSum(formatMessage);
        }

        private int GetMessageSum(string formatMessage)
        {
            int sum = formatMessage.Where(c => char.IsDigit(c)).Sum(c => c);
            return sum;
        }
    }
}