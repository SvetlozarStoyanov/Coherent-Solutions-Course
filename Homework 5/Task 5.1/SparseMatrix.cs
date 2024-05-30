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
        private Dictionary<(int, int), long> elements;

        public SparseMatrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Dimensions must be greater than zero!");
            }
            this.rows = rows;
            this.columns = columns;
            elements = new Dictionary<(int, int), long>();
        }

        public long this[int row, int column]
        {
            get
            {
                if (elements.ContainsKey((row, column)))
                {
                    return elements[(row, column)];
                }

                return 0L;
            }
            set
            {
                if (value == 0)
                {
                    elements.Remove((row, column));
                }
                else
                {
                    elements[(row, column)] = value;
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
                    if (this[row, col] != 0)
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
                return GetLength(0) * GetLength(1) - elements.Count;
            }
            else
            {
                return elements.Count(e => e.Value == element);
            }
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
