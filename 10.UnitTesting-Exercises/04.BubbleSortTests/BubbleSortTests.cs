namespace BubbleSortTests
{
    using BubbleSort.Models;
    using NUnit.Framework;

    public class BubbleSortTests
    {
        [Test]
        public void ShouldSortNumbersCorrect()
        {
            int[] numbers = new int[] { 4, 2, 3, 1 };
            int[] expectedResult = new int[] { 1, 2, 3, 4 };
            Bubble bubble = new Bubble();

            bubble.Sort(numbers);

            CollectionAssert.AreEqual(expectedResult, numbers);
        }
    }
}