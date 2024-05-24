using Homework_4.Task_4._1;

namespace Homework_2.Task_4._1.Extentions
{
    public static class DiagonalMatrixExtentions
    {
        public static DiagonalMatrix<T> AddMatrix<T>(this DiagonalMatrix<T> matrixOne,
            DiagonalMatrix<T> matrixTwo,
            Func<T, T, T> additionFunction
            )
        {
            var minSize = Math.Min(matrixOne.Size, matrixTwo.Size);
            var newSize = matrixOne.Size < matrixTwo.Size ? matrixTwo.Size : matrixOne.Size;
            var biggerMatrix = matrixOne.Size < matrixTwo.Size ? matrixTwo.DiagonalItems : matrixOne.DiagonalItems;
            var resultMatrixDiagonalArray = new T[newSize];
            for (int i = 0; i < minSize; i++)
            {
                resultMatrixDiagonalArray[i] = additionFunction(matrixOne[i, i], matrixTwo[i, i]);
            }
            for (int i = minSize; i < biggerMatrix.Length; i++)
            {
                resultMatrixDiagonalArray[i] = biggerMatrix[i];
            }
            var resultMatrix = new DiagonalMatrix<T>(resultMatrixDiagonalArray);
            return resultMatrix;
        }
    }
}
