using Homework_4.Task_4._2;

namespace Homework_4_Unit_Tests.RationalNumberTests
{
    [TestFixture]
    public class RationalNumberTests
    {
        [Test]
        public void CreatingNumberReducesItCorrectly()
        {
            var number = new RationalNumber(400, 800);
            Assert.That(number.Numerator == 1 && number.Denominator == 2);
        }

        [Test]
        public void SummingRationalNumbersWorksCorrectly()
        {
            var numberOne = new RationalNumber(400, 800);
            var numberTwo = new RationalNumber(300, 900);
            var resultNumber = numberOne + numberTwo;
            Assert.That(resultNumber.Numerator == 5 && resultNumber.Denominator == 6);
        }

        [Test]
        public void SubtractingRationalNumbersWorksCorrectly()
        {
            var numberOne = new RationalNumber(400, 800);
            var numberTwo = new RationalNumber(300, 900);
            var resultNumber = numberOne - numberTwo;
            Assert.That(resultNumber.Numerator == 1 && resultNumber.Denominator == 6);
        }

        [Test]
        public void MultiplyingRationalNumbersWorksCorrectly()
        {
            var numberOne = new RationalNumber(400, 800);
            var numberTwo = new RationalNumber(300, 900);
            var resultNumber = numberOne * numberTwo;
            Assert.That(resultNumber.Numerator == 1 && resultNumber.Denominator == 6);
        }

        [Test]
        public void DividingRationalNumbersWorksCorrectly()
        {
            var numberOne = new RationalNumber(400, 800);
            var numberTwo = new RationalNumber(300, 900);
            var resultNumber = numberOne / numberTwo;
            Assert.That(resultNumber.Numerator == 3 && resultNumber.Denominator == 2);
        }

        [Test]
        public void CastingToDoubleWorksCorrectly()
        {
            var number = new RationalNumber(1, 2);
            var resultNumber = (double)number;
            Assert.That(resultNumber == 0.5);
        }

        [Test]
        public void CastingToIntWorksCorrectly()
        {
            var number = new RationalNumber(1, 2);
            var resultNumber = (int)number;
            Assert.That(resultNumber == 0);
        }

        [Test]
        public void EqualsWorksCorrectly()
        {
            var numberOne = new RationalNumber(1, 2);
            var numberTwo = new RationalNumber(600, 1200);
            Assert.That(numberOne.Equals(numberTwo));
        }

        [Test]
        public void ToStringWorksCorrectly()
        {
            var number = new RationalNumber(1, 2);
            Assert.That(number.ToString().Equals("1 / 2"));
        }

        [Test]
        public void CompareToWorksCorrectly()
        {
            var numberOne = new RationalNumber(1, 2);
            var numberTwo = new RationalNumber(1, 2);

            Assert.That(numberOne.CompareTo(numberTwo) == 0);
            numberOne = new RationalNumber(1, 2);
            numberTwo = new RationalNumber(1, 3);

            Assert.That(numberOne.CompareTo(numberTwo) == 1);            
            numberOne = new RationalNumber(1, 3);
            numberTwo = new RationalNumber(1, 2);

            Assert.That(numberOne.CompareTo(numberTwo) == -1);
        }
    }
}
