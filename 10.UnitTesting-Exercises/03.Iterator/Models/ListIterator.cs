namespace Iterator.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class ListIterator : IIterator
    {
        private IList<string> data;
        private int index;

        public ListIterator(params string[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            this.data = array;
            this.index = 0;
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
            int nextIndex = this.index + 1;
            if (nextIndex > this.data.Count)
            {
                return false;
            }
            return true;
        }

        public string Print()
        {
            if (this.data.Count == 0)
            {
                return "Invalid Operation!";
            }
            else
            {
                return this.data[this.index];
            }
        }
    }
}