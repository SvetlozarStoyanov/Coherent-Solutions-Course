using Homework_2.Task_4._1.Extentions;
using Homework_4.Task_4._1;

namespace Homework_4_Unit_Tests.DiagonalMatrix
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        private DiagonalMatrix<string> matrixOne;
        private DiagonalMatrix<string> matrixTwo;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            matrixOne = new DiagonalMatrix<string>(5);
            matrixOne[0, 0] = "Bob";
            matrixOne[1, 1] = "Michael";
            matrixOne[2, 2] = "Maria";
            matrixOne[3, 3] = "Joe";
            matrixOne[4, 4] = "Roy";
            matrixTwo = new DiagonalMatrix<string>(4);
            matrixTwo[0, 0] = "Johnson";
            matrixTwo[1, 1] = "Patrick";
            matrixTwo[2, 2] = "Rodriguez";
            matrixTwo[3, 3] = "Rogan";
        }


        [Test]
        public void GettingItemsInTheDiagonalWorksCorrectly()
        {
            Assert.That(matrixOne[0, 0].Equals("Bob"));
        }

        [Test]
        public void ChangingItemsInTheDiagonalWorksCorrectly()
        {
            matrixOne[0, 0] = "Ivan";
            Assert.That(matrixOne[0, 0] == "Ivan");
        }

        [Test]
        public void GettingItemsOutsideTheDiagonalWorksCorrectly()
        {
            var actual = matrixOne[0, 1];
            Assert.That(actual == default);
        }

        [Test]
        public void GettingItemsOutsideTheMatrixThrowsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var result = matrixOne[1, -1];
            });
        }

        [Test]
        public void SettingItemsOutsideTheDiagonalOrOutsideTheMatrixDoesNotThrowException()
        {
            Assert.DoesNotThrow(() =>
            {
                matrixOne[1, -1] = "Ian";
                matrixOne[1, 2] = "Ian";
            });
        }

        [Test]
        public void CreatingAMatrixWithLessThanNegativeSizeThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var matrix = new DiagonalMatrix<string>(-2);
            });
        }

        [Test]
        public void AdditionExtentionMethodWorksCorrectly()
        {
            Func<int, int, int> additionOfElements = (argOne, argTwo) =>
            {
                return argOne + argTwo;
            };
            var smallerMatrix = new DiagonalMatrix<int>(2);
            smallerMatrix[0, 0] = 1;
            smallerMatrix[1, 1] = 2;
            var biggerMatrix = new DiagonalMatrix<int>(3);
            biggerMatrix[0, 0] = 2;
            biggerMatrix[1, 1] = 4;
            biggerMatrix[2, 2] = 5;
            var resultMatrix = smallerMatrix.AddMatrix(biggerMatrix, additionOfElements);
            for (int i = 0; i < smallerMatrix.Size; i++)
            {
                Assert.That(resultMatrix[i, i] == smallerMatrix[i, i] + biggerMatrix[i, i]);
            }
            for (int i = smallerMatrix.Size; i < biggerMatrix.Size; i++)
            {
                Assert.That(resultMatrix[i, i] == biggerMatrix[i, i]);
            }
        }


        [TearDown]
        public void TearDown()
        {
            matrixOne[0, 0] = "Bob";
            matrixOne[1, 1] = "Michael";
            matrixOne[2, 2] = "Maria";
            matrixOne[3, 3] = "Joe";
            matrixOne[4, 4] = "Roy";
            matrixTwo[0, 0] = "Johnson";
            matrixTwo[1, 1] = "Patrick";
            matrixTwo[2, 2] = "Rodriguez";
            matrixTwo[3, 3] = "Rogan";
        }
    }
}