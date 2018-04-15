namespace Forum.App.Views
{
    using System.Collections.Generic;
    using System.Linq;

    public class ContentViewModel
    {
        private const int lineLeigth = 37;

        public ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();
            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+= lineLeigth)
            {
                char[] row = contentChars.Skip(i).Take(lineLeigth).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}