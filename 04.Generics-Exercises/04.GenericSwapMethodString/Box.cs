using System.Collections.Generic;
using System.Text;

public class Box<T>
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

    public void Swap(int firstIndex, int secondIndex)
    {
        T temp = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (T item in this.data)
        {
            sb.AppendLine($"{item.GetType().FullName}: {item}");
        }
        return sb.ToString().Trim();
    }
}