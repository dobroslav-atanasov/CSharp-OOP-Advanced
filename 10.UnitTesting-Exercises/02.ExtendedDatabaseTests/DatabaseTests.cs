namespace ExtendedDatabaseTests
{
    using System;
    using System.Collections.Generic;
    using ExtendedDatabase.Contracts;
    using ExtendedDatabase.Models;
    using NUnit.Framework;

    public class DatabaseTests
    {
        private IDatabase database;
        private IPerson firstPerson = new Person(1, "Ivan");
        private IPerson secondPerson = new Person(2, "Petar");
        private const string Username = "Pesho";
        private const long Id = 100;

        [SetUp]
        public void SetUp()
        {
            IList<IPerson> people = new List<IPerson>() { this.firstPerson, this.secondPerson };
            this.database = new Database(people);
        }

        [Test]
        public void InitializeDatabaseWithEmptyConstructor()
        {
            Assert.DoesNotThrow(() => this.database = new Database());
        }

        [Test]
        public void InitializeDatabaseConstructorWithParameter()
        {
            Assert.That(this.database.Count, Is.EqualTo(2));
        }

        [Test]
        public void ThrowExceptionIfAddPersonWithExistingUsername()
        {
            Assert.That(() => this.database.Add(new Person(4, "Ivan")), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionIfAddPersonWithExistingId()
        {
            Assert.That(() => this.database.Add(new Person(1, "Gosho")), Throws.InvalidOperationException);
        }

        [Test]
        public void AddPersonToDatabase()
        {
            IPerson peson = new Person(3, "Gosho");
            
            this.database.Add(peson);

            Assert.That(this.database.Count, Is.EqualTo(3));
        }

        [Test]
        public void ThrowExceptionIfDatabaseDoesNotContainPerson()
        {
            IPerson peson = new Person(3, "Gosho");

            Assert.That(() => this.database.Remove(peson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            this.database.Remove(this.firstPerson);

            Assert.That(this.database.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThrowExceptionIfDatabaseDoesNotContainUsername()
        {
            Assert.That(() => this.database.FindByUsername(Username), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionIfArgumentIsNull()
        {
            Assert.That(() => this.database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ShouldFindPersonByUsername()
        {
            Assert.That(()=> this.database.FindByUsername("Ivan"), Is.EqualTo(this.firstPerson));
        }

        [Test]
        public void ThrowExceptionIfDatabaseDoesNotContainId()
        {
            Assert.That(() => this.database.FindById(Id), Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowExceptionIfGivenIdIsNegative()
        {
            Assert.That(() => this.database.FindById(-1), Throws.Exception);
        }

        [Test]
        public void ShouldFindPersonById()
        {
            Assert.That(()=>this.database.FindById(1), Is.EqualTo(this.firstPerson));
        }
    }
}