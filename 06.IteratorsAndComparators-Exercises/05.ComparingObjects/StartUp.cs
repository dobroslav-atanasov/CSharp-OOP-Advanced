using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(parts[0], int.Parse(parts[1]), parts[2]);
            people.Add(person);
            input = Console.ReadLine();
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        ComparePeople(people, index);
    }

    private static void ComparePeople(IList<Person> people, int index)
    {
        Person searchedPerson = people[index];
        int equalPeople = 0;
        int notEqulaPeople = 0;
        foreach (Person person in people)
        {
            if (searchedPerson.CompareTo(person) == 0)
            {
                equalPeople++;
            }
            else
            {
                notEqulaPeople++;
            }
        }

        if (equalPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople} {notEqulaPeople} {people.Count}");
        }
    }
}