using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = ParsePeople();
        SortedSet<Person> sortedSet = new SortedSet<Person>(people);
        HashSet<Person> hashSet = new HashSet<Person>(people);

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }

    private static List<Person> ParsePeople()
    {
        List<Person> people = new List<Person>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(parts[0], int.Parse(parts[1]));
            people.Add(person);
        }
        return people;
    }
}