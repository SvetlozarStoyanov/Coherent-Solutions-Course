namespace Homework_1
{
    internal class ArrayWithUniqueElements
    {
        private int[] array;

        public ArrayWithUniqueElements(int[] inputArray)
        {
            array = FillArrayWithUniqueElements(inputArray);
        }

        public int[] Array { get => array; }

        private int[] FillArrayWithUniqueElements(int[] inputArray)
        {
            var resultArray = new int[inputArray.Length];
            var reachedIndex = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!ContainsElement(inputArray[i], reachedIndex, resultArray))
                {
                    AppendElementToArray(inputArray[i], reachedIndex++, resultArray);
                }
            }
            resultArray = TruncateArray(reachedIndex, resultArray);
            return resultArray;
        }

        private void AppendElementToArray(int newElement, int index, int[] array)
        {
            array[index] = newElement;
        }

        private bool ContainsElement(int element, int index, int[] array)
        {
            for (int i = 0; i < index; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        private int[] TruncateArray(int endIndex, int[] inputArray)
        {
            var resultArray = new int[endIndex];
            for (int i = 0; i < endIndex; i++)
            {
                resultArray[i] = inputArray[i];
            }
            return resultArray;
        }
    }
}
