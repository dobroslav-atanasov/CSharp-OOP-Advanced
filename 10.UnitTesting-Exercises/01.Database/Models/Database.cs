namespace Database.Models
{
    using System;
    using System.Linq;
    using Contracts;

    public class Database : IDatabase
    {
        private const int DefaultCapacity = 16;

        private int[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new int[DefaultCapacity];
            this.currentIndex = 0;
        }

        public Database(params int[] numbers)
        {
            this.data = new int[DefaultCapacity];
            this.currentIndex = 0;

            if (numbers.Length > DefaultCapacity)
            {
                throw new InvalidOperationException();
            }

            foreach (int number in numbers)
            {
                this.data[this.currentIndex] = number;
                this.currentIndex++;
            }
        }

        public int this[int index] => this.data[index];

        public int Capacity => this.data.Length;

        public void Add(int number)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException();
            }

            this.data[this.currentIndex] = number;
            this.currentIndex++;
        }

        public int Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException();
            }

            int number = this.data[this.currentIndex - 1];
            this.data[this.currentIndex - 1] = 0;
            this.currentIndex--;
            return number;
        }

        public int[] Fetch()
        {
            int[] array = this.data.Take(this.currentIndex).ToArray();
            return array;
        }
    }
}