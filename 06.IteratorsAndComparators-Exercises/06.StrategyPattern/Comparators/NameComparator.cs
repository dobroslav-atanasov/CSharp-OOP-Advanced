using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        int result = first.Name.Length.CompareTo(second.Name.Length);
        if (result == 0)
        {
            result = first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
        }
        return result;
    }
}