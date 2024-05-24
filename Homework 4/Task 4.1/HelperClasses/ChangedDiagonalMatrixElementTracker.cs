namespace Homework_4.Task_4._1.HelperClasses
{
    public class ChangedDiagonalMatrixElementTracker<T>
    {
        public ChangedDiagonalMatrixElementTracker(int diagonalIndex, T oldValue, T newValue)
        {
            DiagonalIndex = diagonalIndex;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public int DiagonalIndex { get; init; }
        public T OldValue { get; init; }
        public T NewValue { get; init; }
    }
}
