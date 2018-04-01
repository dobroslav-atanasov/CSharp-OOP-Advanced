namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            string[] startTrafficColors = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int numberOfChanges = int.Parse(Console.ReadLine());

            List<TrafficLight> trafficLights = new List<TrafficLight>();
            foreach (string color in startTrafficColors)
            {
                TrafficLight trafficLight = new TrafficLight(color);
                trafficLights.Add(trafficLight);
            }

            for (int i = 0; i < numberOfChanges; i++)
            {
                foreach (TrafficLight trafficLight in trafficLights)
                {
                    trafficLight.ChangeColor();
                }
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}