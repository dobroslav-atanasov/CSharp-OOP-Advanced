namespace DatabaseTests
{
    using Database.Contracts;
    using Database.Models;
    using NUnit.Framework;

    public class DatabaseTests
    {
        private const int DefaultCapacity = 16;
        private IDatabase database;
        private const int Number = 4;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
        }

        [Test]
        public void ShouldConstructorTakeMoreParameters()
        {
            Assert.That(() => this.AddNumbers(17), Throws.InvalidOperationException);
        }

        [Test]
        public void AfterInitializedDatabaseShouldHaveDefaultCapacity()
        {
            Assert.That(this.database.Capacity, Is.EqualTo(DefaultCapacity));
        }

        [Test]
        public void AddNumberAtNextFreePosition()
        {
            this.database.Add(Number);

            Assert.That(this.database[0], Is.EqualTo(Number));
        }

        [Test]
        public void AddNumbersWhenDatabaseCountIsFull()
        {
            this.AddNumbers(16);

            Assert.That(() => this.database.Add(Number), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldSupportOnlyRemovingElementAtTheLastIndex()
        {
            this.database.Add(Number);
            this.database.Remove();

            Assert.That(this.database[0], Is.EqualTo(0));
        }

        [Test]
        public void ShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldReturnTheNumberOfDatabase()
        {
            int[] expectedArray = new[] { 0, 1, 2 };
            this.AddNumbers(3);

            CollectionAssert.AreEqual(expectedArray, this.database.Fetch());
        }

        private void AddNumbers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.database.Add(i);
            }
        }
    }
}