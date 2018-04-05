namespace BubbleSort.Models
{
    public class Bubble
    {
        public void Sort(int[] numbers)
        {
            //bool swapped = true;

            //while (swapped)
            //{
            //    swapped = false;
            //    for (int i = 1; i < numbers.Length; i++)
            //    {
            //        int leftNumber = numbers[i - 1];
            //        int rightNumber = numbers[i];
            //        if (leftNumber > rightNumber)
            //        {
            //            numbers[i - 1] = rightNumber;
            //            numbers[i] = leftNumber;
            //            swapped = true;
            //        }
            //    }
            //}

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < numbers.Length; i++)
                {
                    int leftNumber = numbers[i - 1];
                    int rightNumber = numbers[i];
                    if (leftNumber > rightNumber)
                    {
                        numbers[i - 1] = rightNumber;
                        numbers[i] = leftNumber;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}