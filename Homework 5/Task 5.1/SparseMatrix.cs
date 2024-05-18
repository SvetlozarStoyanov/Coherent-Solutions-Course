using System.Collections;
using System.Text;

namespace Homework_5.Task_5._1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private class SparseMatrixEnumerator : IEnumerator<long>
        {
            private readonly SparseMatrix sparseMatrix;
            private int rowIndex;
            private int columnIndex;
            public SparseMatrixEnumerator(SparseMatrix sparseMatrix)
            {
                this.sparseMatrix = sparseMatrix;
                rowIndex = 0;
                columnIndex = -1;
            }
            public long Current => sparseMatrix[rowIndex, columnIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                columnIndex++;
                if (columnIndex == sparseMatrix.GetLength(1))
                {
                    columnIndex = 0;
                    rowIndex++;
                }
                return rowIndex < sparseMatrix.GetLength(0)
                    && columnIndex < sparseMatrix.GetLength(1);
            }

            public void Reset()
            {
                rowIndex = 0;
                columnIndex = -1;
            }
        }


        private readonly int rows;
        private readonly int columns;
        private long[] cornerElements;

        public SparseMatrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Dimensions must be greater than zero!");
            }
            this.rows = rows;
            this.columns = columns;
            cornerElements = new long[4];
        }

        public long this[int row, int column]
        {
            get
            {
                if (IsCornerElement(row, column))
                {
                    var cornerIndex = GetCornerIndex(row, column);

                    return cornerElements[cornerIndex];
                }
                return 0L;
            }
            set
            {
                if (IsCornerElement(row, column))
                {
                    var cornerIndex = GetCornerIndex(row, column);

                    cornerElements[cornerIndex] = value;
                }
            }
        }


        public int GetLength(int dimension)
        {
            if (dimension == 0)
            {
                return rows;
            }
            else if (dimension == 1)
            {
                return columns;
            }
            throw new ArgumentException("Invalid dimension!");
        }

        public IEnumerator<long> GetEnumerator()
        {
            return new SparseMatrixEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int, int, long)> GetNonZeroElements()
        {
            var resultList = new List<(int, int, long)>();
            for (int col = 0; col < this.GetLength(1); col++)
            {
                for (int row = 0; row < this.GetLength(0); row++)
                {
                    if (this[row,col] != 0)
                    {
                        resultList.Add(new(row, col, this[row, col]));
                    }
                }
            }
            return resultList;
        }

        public int GetCount(long element)
        {
            var count = 0;
            if (element == 0)
            {
                return GetLength(0) * GetLength(1) - 4;
            }
            else
            {
                for (int i = 0; i < cornerElements.Length; i++)
                {
                    if (cornerElements[i] == element)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        private bool IsCornerElement(int row, int column)
        {
            if ((row == 0 || row == rows - 1) && (column == 0 || column == columns - 1))
            {
                return true;
            }
            return false;
        }

        private int GetCornerIndex(int row, int column)
        {
            if (row == 0 && column == 0)
            {
                return 0;
            }
            if (row == 0 && column == columns - 1)
            {
                return 1;
            }
            if (row == rows - 1 && column == 0)
            {
                return 2;
            }
            return 3;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < this.GetLength(0); row++)
            {
                for (int col = 0; col < this.GetLength(1); col++)
                {
                    sb.Append($"{this[row, col]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }

    }
}
