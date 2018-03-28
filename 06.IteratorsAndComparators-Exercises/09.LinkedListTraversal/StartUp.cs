using System;

public class StartUp
{
    public static void Main()
    {
        CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            switch (command)
            {
                case "Add":
                    customLinkedList.Add(int.Parse(parts[1]));
                    break;
                case "Remove":
                    customLinkedList.Remove(int.Parse(parts[1]));
                    break;
            }
        }

        Console.WriteLine(customLinkedList.Count);
        Console.WriteLine(string.Join(" ", customLinkedList));
    }
}