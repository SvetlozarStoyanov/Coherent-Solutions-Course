using Homework_4.Task_4._1.EventArgs;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Homework_4.Task_4._1
{
    public class DiagonalMatrix<T>
    {
        private T[] diagonalItems;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size cannot be negative!");
            }
            diagonalItems = new T[size];
        }

        public DiagonalMatrix(T[] items)
        {
            diagonalItems = items;
        }

        public int Size { get => DiagonalItems != null ? DiagonalItems.Length : 0; }
        public T[] DiagonalItems { get => diagonalItems; private set => diagonalItems = value; }

        public T this[int i, int j]
        {
            get
            {
                if (!IsInBounds(i, j))
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the matrix");
                }
                if (i != j)
                {
                    return default(T);
                }
                return DiagonalItems[i];
            }
            set
            {
                if (i == j && IsInBounds(i, j))
                {
                    if (DiagonalItems[i] == null && value != null || DiagonalItems[i] != null && !DiagonalItems[i].Equals(value))
                    {
                        var caller = new StackTrace().GetFrame(1).GetMethod();

                        ElementChanged?.Invoke(this, new ElementChangedEventArgs<T>(i, j, DiagonalItems[i], value));

                        DiagonalItems[i] = value;
                    }
                }
            }
        }

        public delegate void ElementChangedEventHandler(object? sender, ElementChangedEventArgs<T> args);
        public event ElementChangedEventHandler ElementChanged;

        public override bool Equals(object? obj)
        {
            if (obj is DiagonalMatrix<T>)
            {
                var other = obj as DiagonalMatrix<T>;
                if (this.Size != other?.Size)
                {
                    return false;
                }
                for (int i = 0; i < Size; i++)
                {
                    if (!this.DiagonalItems[i].Equals(other.DiagonalItems[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public void UndoChange(int index, T value)
        {
            diagonalItems[index] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    if (EqualityComparer<T>.Default.Equals(this[row, column], default(T)))
                    {
                        sb.Append("-");
                    }
                    else
                    {
                        sb.Append(this[row, column]);
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private bool IsInBounds(int row, int column)
        {
            return row >= 0 && row < Size && column >= 0 && column < Size;
        }


    }
}
