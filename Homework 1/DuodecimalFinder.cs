namespace Homework_1
{
    internal class DuodecimalFinder
    {
        public DuodecimalFinder()
        {

        }

        public string GetNumbersWhichContainSubstring(int num01,
            int num02,
            string substring = "AA")
        {
            return string.Join(", ", FindNumbersWhichContainSubstring(num01,
                num02,
                substring));
        }

        private List<int> FindNumbersWhichContainSubstring(int num01,
            int num02,
            string substring)
        {
            var numbersWhichMatchCondition = new List<int>();
            if (num01 < num02)
            {
                for (int i = num01; i <= num02; i++)
                {
                    if (ConvertToDuodecimal(i).Contains(substring))
                    {
                        numbersWhichMatchCondition.Add(i);
                    }
                }
            }
            return numbersWhichMatchCondition;
        }

        private string ConvertToDuodecimal(int number)
        {
            string duodecimalChars = "0123456789AB";
            string result = string.Empty;

            if (number == 0)
            {
                return "0";
            }

            while (number > 0)
            {
                int remainder = number % 12;

                result = duodecimalChars[remainder] + result;

                number /= 12;
            }
            return result;
        }
    }
}
