using System.Collections.Generic;

public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}