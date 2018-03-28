using System.Collections.Generic;

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        int result = first.Age.CompareTo(second.Age);
        return result;
    }
}