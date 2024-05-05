namespace Homework_2.Task_2._2
{
    public static class DiagonalMatrixExtentions
    {
        public static DiagonalMatrix AddMatrix(this DiagonalMatrix matrixOne, DiagonalMatrix matrixTwo)
        {
            var minSize = Math.Min(matrixOne.Size, matrixTwo.Size);
            var newSize = matrixOne.Size < matrixTwo.Size ? matrixTwo.Size : matrixOne.Size;
            var biggerMatrix = matrixOne.Size < matrixTwo.Size ? matrixTwo.DiagonalItems : matrixOne.DiagonalItems;
            var resultMatrixDiagonalArray = new int[newSize];
            for (int i = 0; i < minSize; i++)
            {
                resultMatrixDiagonalArray[i] = matrixOne[i, i] + matrixTwo[i, i];
            }
            for (int i = minSize; i < biggerMatrix.Length; i++)
            {
                resultMatrixDiagonalArray[i] = biggerMatrix[i];
            }
            var resultMatrix = new DiagonalMatrix(resultMatrixDiagonalArray);
            return resultMatrix;
        }
    }
}
