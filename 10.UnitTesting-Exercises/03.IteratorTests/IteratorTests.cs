namespace IteratorTests
{
    using Iterator.Models;
    using NUnit.Framework;

    public class IteratorTests
    {
        private const string Message = "Invalid Operation!";

        private ListIterator listIterator;
        private string[] names;

        [SetUp]
        public void SetUp()
        {
            this.names = new string[] { "Ivan", "Petar", "Georgi" };
            this.listIterator = new ListIterator(this.names);
        }

        [Test]
        public void ThrowExceptionIfContructorTakesNull()
        {
            Assert.That(() => this.listIterator = new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void IfMoveSuccessfulOnNextPosition()
        {
            Assert.That(() => this.listIterator.Move(), Is.EqualTo(true));
            Assert.That(() => this.listIterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void IfDoNotMoveSuccessfulOnNextPosition()
        {
            this.listIterator.Move();
            this.listIterator.Move();
            this.listIterator.Move();
            
            Assert.That(()=> this.listIterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnTrueIfThereIsNextPosition()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.That(() => this.listIterator.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void ShouldReturnFalseIfThereIsNotNextPosition()
        {
            this.listIterator.Move();
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.That(() => this.listIterator.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void ShouldPrintElementAtCurrentPosition()
        {
            this.listIterator.Move();

            Assert.That(()=> this.listIterator.Print(), Is.EqualTo("Petar"));
        }

        [Test]
        public void ShouldPrintMessageIfListIteratorIsEmpty()
        {
            this.listIterator = new ListIterator();

            Assert.That(()=> this.listIterator.Print(), Is.EqualTo(Message));
        }
    }
}