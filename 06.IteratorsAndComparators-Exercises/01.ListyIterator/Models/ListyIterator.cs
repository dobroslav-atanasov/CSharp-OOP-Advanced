using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private readonly IList<T> data;
    private int index;

    public ListyIterator()
    {
        this.data = new List<T>();
        this.index = 0;
    }

    public void Create(ICollection<T> collection)
    {
        foreach (T item in collection)
        {
            this.data.Add(item);
        }
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (this.index + 1 < this.data.Count)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (this.data.Count == 0)
        {
            Console.WriteLine($"Invalid Operation!");
        }
        else
        {
            Console.WriteLine($"{this.data[this.index]}");
        }
    }
}