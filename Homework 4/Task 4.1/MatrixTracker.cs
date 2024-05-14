
using Homework_4.Task_4._1.EventArgs;
using Homework_4.Task_4._1.HelperClasses;

namespace Homework_4.Task_4._1
{
    public class MatrixTracker<T>
    {
        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            this.DiagonalMatrix = diagonalMatrix;
            DiagonalMatrix.ElementChanged += OnElementChanged;
            ChangeStack = new Stack<ChangedDiagonalMatrixElementTracker<T>>();
        }

        public DiagonalMatrix<T> DiagonalMatrix { get; init; }
        public Stack<ChangedDiagonalMatrixElementTracker<T>> ChangeStack { get; init; }

        public void Undo()
        {
            if (ChangeStack.Count == 0)
            {
                throw new InvalidOperationException("There are no changes to undo!");
            }
            var change = ChangeStack.Pop();
            DiagonalMatrix.UndoChange(change.DiagonalIndex, change.OldValue);
        }

        private void OnElementChanged(object? sender, ElementChangedEventArgs<T> args)
        {
            ChangeStack.Push(new ChangedDiagonalMatrixElementTracker<T>(args.Row, args.OldValue, args.NewValue));
        }
    }
}
