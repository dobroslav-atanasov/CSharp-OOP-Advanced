using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private IList<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public T Remove(int index)
    {
        T item = this.data[index];
        this.data.RemoveAt(index);
        return item;
    }

    public bool Contains(T item)
    {
        if (this.data.Contains(item))
        {
            return true;
        }
        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T temp = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }

    public int CountGreaterThan(T givenItem)
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

    public T Max()
    {
        T maxItem = this.data.Max();
        return maxItem;
    }

    public T Min()
    {
        T minItem = this.data.Min();
        return minItem;
    }

    public void Sort()
    {
        this.data = this.data.OrderBy(i => i).ToList();
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();
        foreach (T item in this.data)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().Trim();
    }
}