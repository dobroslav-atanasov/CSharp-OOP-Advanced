namespace StreamProgressInfo
{
    using System;
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            File file = new File("ABBA", 125, 10);
            Music music = new Music("Queen", "The Game", 1000, 220);

            StreamProgressInfo firstStreamProgressInfo = new StreamProgressInfo(file);
            StreamProgressInfo secondStreamProgressInfo = new StreamProgressInfo(music);

            Console.WriteLine(firstStreamProgressInfo.CalculateCurrentPercent());
            Console.WriteLine(secondStreamProgressInfo.CalculateCurrentPercent());
        }
    }
}