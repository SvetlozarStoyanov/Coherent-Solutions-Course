namespace Homework_4.Task_4._2
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero!");
            }
            Numerator = numerator;
            Denominator = denominator;
            Reduce();
        }

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public static RationalNumber operator +(RationalNumber numberOne, RationalNumber numberTwo)
        {
            var commonDenominator = numberOne.Denominator * numberTwo.Denominator;
            var resultNumerator = numberOne.Numerator * numberTwo.Denominator + numberTwo.Numerator * numberOne.Denominator;
            return new RationalNumber(resultNumerator, commonDenominator);
        }

        public static RationalNumber operator -(RationalNumber numberOne, RationalNumber numberTwo)
        {
            var commonDenominator = numberOne.Denominator * numberTwo.Denominator;
            var resultNumerator = numberOne.Numerator * numberTwo.Denominator - numberTwo.Numerator * numberOne.Denominator;
            return new RationalNumber(resultNumerator, commonDenominator);
        }

        public static RationalNumber operator *(RationalNumber numberOne, RationalNumber numberTwo)
        {
            var commonDenominator = numberOne.Denominator * numberTwo.Denominator;
            var resultNumerator = numberOne.Numerator * numberTwo.Numerator;
            return new RationalNumber(resultNumerator, commonDenominator);
        }

        public static RationalNumber operator /(RationalNumber numberOne, RationalNumber numberTwo)
        {
            var commonDenominator = numberOne.Denominator * numberTwo.Numerator;
            var resultNumerator = numberOne.Numerator * numberTwo.Denominator;
            return new RationalNumber(resultNumerator, commonDenominator);
        }

        public static explicit operator int(RationalNumber rationalNumber)
        {
            return (int)(rationalNumber.Numerator / rationalNumber.Denominator);
        }

        public static explicit operator double(RationalNumber rationalNumber)
        {
            return (double)((double)rationalNumber.Numerator / rationalNumber.Denominator);
        }

        public int CompareTo(RationalNumber? other)
        {
            if (other == null)
            {
                return 1;
            }
            var thisAsDouble = (double)this;
            var otherAsDouble = (double)other;
            if (thisAsDouble < otherAsDouble)
            {
                return -1;
            }
            else if (thisAsDouble == otherAsDouble)
            {
                return 0;
            }
            return 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is RationalNumber))
            {
                return false;
            }
            RationalNumber other = (RationalNumber)obj;
            if (this.Numerator != other.Numerator
                || this.Denominator != other.Denominator)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{this.Numerator} / {this.Denominator}";
        }

        private void Reduce()
        {
            var biggestCommonFactor = FindBiggestCommonFactor(Numerator, Denominator);
            while (biggestCommonFactor > 1)
            {
                Numerator /= biggestCommonFactor;
                Denominator /= biggestCommonFactor;
                biggestCommonFactor = FindBiggestCommonFactor(Numerator, Denominator);
            }
        }

        private int FindBiggestCommonFactor(int numOne, int numTwo)
        {
            var min = Math.Min(numOne, numTwo);
            var currFactor = min;
            while (currFactor > 1)
            {
                if (numOne % currFactor == 0 && numTwo % currFactor == 0)
                {
                    return currFactor;
                }
                currFactor--;
            }
            return 1;
        }
    }
}
