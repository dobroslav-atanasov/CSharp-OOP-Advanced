namespace ExtendedDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Database : IDatabase
    {
        private readonly IList<IPerson> people;

        public Database()
        {
            this.people = new List<IPerson>();
        }

        public Database(IEnumerable<IPerson> people)
            :this()
        {
            foreach (Person person in people)
            {
                this.people.Add(person);
            }
        }

        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p => p.Username.ToLower() == person.Username.ToLower()))
            {
                throw new InvalidOperationException();
            }
            if (this.people.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException();
            }
            this.people.Add(person);
        }

        public void Remove(IPerson person)
        {
            if (!this.people.Contains(person))
            {
                throw new InvalidOperationException();
            }
            
            this.people.Remove(person);
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!this.people.Any(p => p.Id == id))
            {
                throw new InvalidOperationException();
            }

            IPerson searchedPerson = this.people.FirstOrDefault(p => p.Id == id);
            return searchedPerson;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }
            if (!this.people.Any(p => p.Username.ToLower() == username.ToLower()))
            {
                throw new InvalidOperationException();
            }

            IPerson searchedPerson = this.people.FirstOrDefault(p => p.Username.ToLower() == username.ToLower());
            return searchedPerson;
        }
    }
}