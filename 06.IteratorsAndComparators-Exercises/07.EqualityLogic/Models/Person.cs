using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        Person other = obj as Person;
        return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
    }

    public override int GetHashCode()
    {
        int sum = 0;
        foreach (char symbol in this.Name)
        {
            sum += symbol * this.Age;
        }
        return sum;
    }
}