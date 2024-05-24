namespace Homework_4.Task_4._1.EventArgs
{
    public class ElementChangedEventArgs<T>
    {
        public ElementChangedEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public int Row { get; init; }
        public int Column { get; init; }
        public T OldValue { get; init; }
        public T NewValue { get; init; }
    }
}
