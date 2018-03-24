using System;
using System.Collections.Generic;

public class Box<T>
    where T : IComparable<T>
{
    private readonly IList<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public int Compare(T givenItem)
    {
        int count = 0;
        foreach (T item in this.data)
        {
            if (item.CompareTo(givenItem) > 0)
            {
                count++;
            }
        }
        return count;
    }
}