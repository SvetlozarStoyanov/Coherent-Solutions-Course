using System.Text;

namespace Homework_1
{
    internal class DuodecimalFinder
    {
        public DuodecimalFinder()
        {

        }

        public string GetNumbersWhichContainSubstring(int num01,
            int num02)
        {
            var sb = new StringBuilder();
            var max = Math.Max(num01, num02);
            var min = Math.Min(num01, num02);
            for (int i = min; i <= max; i++)
            {
                if (ContainsTwoAs(i))
                {
                    sb.Append($"{i}, ");
                }
            }
            return sb.Remove(sb.Length - 2, 2).ToString();
        }

        private bool ContainsTwoAs(int number)
        {
            var remainderCount = 0;
            while (number > 0)
            {
                var remainder = number % 12;
                number = number / 12;
                if (remainder == 10)
                {
                    remainderCount++;
                }
            }
            if (remainderCount == 2)
            {
                return true;
            }
            return false;
        }
    }
}
