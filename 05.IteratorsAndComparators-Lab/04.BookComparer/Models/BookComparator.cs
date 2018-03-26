using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book first, Book second)
    {
        int result = first.Title.CompareTo(second.Title);
        if (result == 0)
        {
            result = second.Year.CompareTo(first.Year);
        }
        return result;
    }
}