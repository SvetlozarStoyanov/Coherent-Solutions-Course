﻿namespace Homework_1
{
    internal class ISBNWriter
    {
        public ISBNWriter()
        {

        }

        public void AddControlDigitToISBN(ref string input)
        {
            var checkDigit = 0.0;
            for (int i = 0; i < input.Length; i++)
            {
                // input[i] - 48 -> gives us the current digit.
                // Subtracting is necessary because input[i] is a char and that adds an additional 48 to its value
                checkDigit += (10 - i) * (input[i] - 48);
            }
            checkDigit = checkDigit + checkDigit;
            checkDigit = checkDigit % 11;
            if (checkDigit > 0)
            {
                input += "-" + checkDigit;
            }
            else
            {
                input += "-X";
            }
        }
    }
}
