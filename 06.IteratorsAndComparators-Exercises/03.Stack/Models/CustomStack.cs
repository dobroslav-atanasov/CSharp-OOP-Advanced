using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : IEnumerable<T>
{
    private readonly IList<T> data;

    public CustomStack()
    {
        this.data = new List<T>();
    }

    public void Push(params T[] items)
    {
        foreach (T item in items)
        {
            this.data.Add(item);
        }
    }

    public void Pop()
    {
        if (this.data.Count == 0)
        {
           Console.WriteLine($"No elements");
        }
        else
        {
            this.data.RemoveAt(this.data.Count - 1);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = this.data.Count - 1; j >=  0; j--)
            {
                yield return this.data[j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}