using System.Collections.Generic;

public class Box<T>
{
    private readonly IList<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T item)
    {
        this.data.Add(item);
    }

    public T Remove()
    {
        T item = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);
        return item;
    }
}