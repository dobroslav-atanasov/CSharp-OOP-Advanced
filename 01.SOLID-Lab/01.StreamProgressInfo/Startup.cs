namespace StreamProgressInfo
{
    using System;
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            StreamProgressInfo firstStreamProgressInfo = new StreamProgressInfo(new File("ABBA", 125, 10));
            StreamProgressInfo secondStreamProgressInfo =
                new StreamProgressInfo(new Music("Queen", "The Game", 1000, 220));
            Console.WriteLine(firstStreamProgressInfo.CalculateCurrentPercent());
            Console.WriteLine(secondStreamProgressInfo.CalculateCurrentPercent());
        }
    }
}