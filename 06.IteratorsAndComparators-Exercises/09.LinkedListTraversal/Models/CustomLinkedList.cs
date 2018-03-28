using System.Collections;
using System.Collections.Generic;

public class CustomLinkedList<T> : IEnumerable<T>
{
    private IList<T> data;

    public CustomLinkedList()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public void Remove(T item)
    {
        this.data.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}