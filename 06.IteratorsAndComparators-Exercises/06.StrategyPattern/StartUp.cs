using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = ParsePeople();
        SortedSet<Person> sortedByName = new SortedSet<Person>(people, new NameComparator());
        SortedSet<Person> sortedByAge = new SortedSet<Person>(people, new AgeComparator());

        PrintCollection(sortedByName);
        PrintCollection(sortedByAge);
    }

    private static void PrintCollection(IEnumerable<Person> collection)
    {
        foreach (Person person in collection)
        {
            Console.WriteLine(person);
        }
    }

    private static List<Person> ParsePeople()
    {
        int number = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < number; i++)
        {
            string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(parts[0], int.Parse(parts[1]));
            people.Add(person);
        }
        return people;
    }
}