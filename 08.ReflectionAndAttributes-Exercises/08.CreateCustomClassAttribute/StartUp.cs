namespace CreateCustomClassAttribute
{
    using System;
    using System.Linq;
    using Attributes;

    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class StartUp
    {
        public static void Main()
        {
            CustomAttribute attribute = (CustomAttribute)typeof(StartUp).GetCustomAttributes(true).First();
            string command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}