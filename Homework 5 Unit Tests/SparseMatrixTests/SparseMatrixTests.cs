using Homework_5.Task_5._1;

namespace Homework_5_Unit_Tests.SparseMatrixTests
{
    public class SparseMatrixTests
    {
        private SparseMatrix sparseMatrix;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            sparseMatrix = new SparseMatrix(10, 10);
            sparseMatrix[0, 0] = 1;
            sparseMatrix[0, 9] = 2;
            sparseMatrix[9, 0] = 3;
            sparseMatrix[9, 9] = 4;
        }

        [Test]
        public void GettingNonCornerElementReturnsZero()
        {
            Assert.That(sparseMatrix[0, 1] == 0);
        }

        [Test]
        public void GettingCornerElementReturnsCorrectValue()
        {
            Assert.That(sparseMatrix[0, 0] == 1);
        }

        [Test]
        public void GetNonZeroElementsReturnsCorrectValues()
        {
            var nonZeroElements = sparseMatrix.GetNonZeroElements();
            foreach (var element in nonZeroElements)
            {
                Assert.That(element.Item3 != 0);
            }
        }

        [Test]
        public void GetCountReturnsCorrectCount()
        {
            Assert.That(sparseMatrix.GetCount(1) == 1);
            Assert.That(sparseMatrix.GetCount(2) == 1);
            Assert.That(sparseMatrix.GetCount(3) == 1);
            Assert.That(sparseMatrix.GetCount(4) == 1);
            Assert.That(sparseMatrix.GetCount(0) == 96);
        }
    }
}