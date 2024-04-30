using System.Text;

namespace Homework_2
{
    public class DiagonalMatrix
    {
        private int[] diagonalItems;
        public DiagonalMatrix(params int[] items)
        {
            DiagonalItems = items;
            Size = items != null ? items.Length : 0;
        }
        public int Size { get; private set; }
        public int[] DiagonalItems { get => diagonalItems; private set => diagonalItems = value; }

        public int this[int i, int j]
        {
            get
            {
                if (i != j)
                {
                    return 0;
                }
                if (!IsInBounds(i, j))
                {
                    return 0;
                }
                return DiagonalItems[i];
            }
            set
            {
                if (i == j && IsInBounds(i, j))
                {
                    DiagonalItems[i] = value;
                }
            }
        }

        public int Track()
        {
            var sum = 0;
            if (DiagonalItems != null)
            {
                for (int i = 0; i < DiagonalItems.Length; i++)
                {
                    sum += DiagonalItems[i];
                }
            }
            return sum;
        }

        private bool IsInBounds(int row, int column)
        {
            return row >= 0 && row < Size && column >= 0 && column < Size;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DiagonalMatrix)
            {
                var other = obj as DiagonalMatrix;
                if (this.Size != other?.Size)
                {
                    return false;
                }
                for (int i = 0; i < Size; i++)
                {
                    if (this.DiagonalItems[i] != other.DiagonalItems[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    sb.Append(this[row, column]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
