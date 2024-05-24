using Homework_4.Task_4._1;

namespace Homework_4_Unit_Tests.MatrixTracer
{
    [TestFixture]
    public class MatrixTrackerTests
    {
        private DiagonalMatrix<int> matrix;
        private MatrixTracker<int> tracker;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            matrix = new DiagonalMatrix<int>(4);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            matrix[2, 2] = 3;
            matrix[3, 3] = 4;
            tracker = new MatrixTracker<int>(matrix);
        }

        [Test]
        [Order(1)]
        public void ChangingMatrixElementAddsToChangeStack()
        {
            var stackCountPreChange = tracker.ChangeStack.Count;
            matrix[0, 0] = 0;
            var stackCountPostChange = tracker.ChangeStack.Count;
            Assert.That(stackCountPostChange - stackCountPreChange == 1);
        }

        [Test]
        [Order(2)]

        public void UndoingElementChangeWorksCorrectly()
        {
            matrix[0, 0] = 2;
            tracker.Undo();
            Assert.That(matrix[0, 0] == 1);
        }

        [Test]
        [Order(3)]

        public void UndoingElementChangeWhenChangeStackIsEmptyThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                {
                    while (tracker.ChangeStack.Count > 0)
                    {
                        tracker.Undo();
                    }
                    tracker.Undo();
                });
        }

        [TearDown]
        public void TearDown()
        {
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            matrix[2, 2] = 3;
            matrix[3, 3] = 4;
        }
    }
}
