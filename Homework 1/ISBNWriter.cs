namespace Homework_1
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
                checkDigit += (i + 1) * (Convert.ToInt32(input[i]) - 48);
            }
            checkDigit = checkDigit % 11;
            if (checkDigit != 10)
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
