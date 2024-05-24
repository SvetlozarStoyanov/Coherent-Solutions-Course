using Homework_2.Task_4._1.Extentions;
using Homework_4.Task_4._1;
using Homework_4.Task_4._2;

namespace Homework_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Task 4.1
            #region Task 4.1
            //var matrixOne = new DiagonalMatrix<string>(5);
            //var tracker = new MatrixTracker<string>(matrixOne);
            //matrixOne[0, 0] = "Bob";
            //matrixOne[1, 1] = "Michael";
            //matrixOne[2, 2] = "Maria";
            //matrixOne[3, 3] = "Joe";
            //matrixOne[4, 4] = "Roy";
            //Console.WriteLine(matrixOne.ToString());
            //tracker.Undo();
            //Console.WriteLine();
            //Console.WriteLine(matrixOne.ToString());
            //tracker.Undo();
            //tracker.Undo();
            //Console.WriteLine();
            //Console.WriteLine(matrixOne.ToString());
            //matrixOne[3, 3] = "Joe";
            //matrixOne[4, 4] = "Roy";
            //var matrixTwo = new DiagonalMatrix<string>(4);
            //matrixTwo[0, 0] = "Johnson";
            //matrixTwo[1, 1] = "Patrick";
            //matrixTwo[2, 2] = "Rodriguez";
            //matrixTwo[3, 3] = "Rogan";
            //Func<string, string, string> additionOfElements = (argOne, argTwo) =>
            //{
            //    return $"{argOne}{ (argOne != null && argTwo != null ? "|" : string.Empty)}{argTwo}";
            //};
            //var resultMatrix = matrixOne.AddMatrix(matrixTwo, additionOfElements);
            //Console.WriteLine();
            //Console.WriteLine(resultMatrix.ToString());
            #endregion

            ////Task 4.2
            var rationalNumberOne = new RationalNumber(4, 8);
            Console.WriteLine(rationalNumberOne);
            var rationalNumberTwo = new RationalNumber(25, 100);
            Console.WriteLine(rationalNumberOne + rationalNumberTwo);
            Console.WriteLine(rationalNumberOne - rationalNumberTwo);
            Console.WriteLine(rationalNumberOne / rationalNumberTwo);
            Console.WriteLine((double)rationalNumberOne);
            Console.WriteLine((int)rationalNumberOne);
        }
    }
}
