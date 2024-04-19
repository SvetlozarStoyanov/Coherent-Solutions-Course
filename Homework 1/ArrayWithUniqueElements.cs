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
            var array = new int[1] { inputArray[0] };
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (!ContainsElement(inputArray[i], array))
                {
                    array = AppendElementToArray(inputArray[i], array);
                }
            }
            return array;
        }

        private int[] AppendElementToArray(int newElement, int[] array)
        {
            var temp = array;
            array = new int[array.Length + 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = temp[i];
            }
            array[array.Length - 1] = newElement;
            return array;
        }

        private bool ContainsElement(int element, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
