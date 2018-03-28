using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private readonly IList<int> stones;

    public Lake(params int[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.stones[i];
            }
        }

        for (int i = this.stones.Count - 1; i >= 1; i--)
        {
            if (i % 2 != 0)
            {
                yield return this.stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}