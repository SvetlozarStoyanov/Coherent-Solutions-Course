using Homework_2.Task_2._2;
using Homework_2.Task_2._3;

namespace Homework_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Task 2.1
            //Point pointOne = new Point(1, 2, 3, 40);
            //Point pointTwo = new Point(4, 5, 6, 36);
            //Point pointThree = new Point(0, 0, 0, 20);
            //pointOne.Mass = -1;
            //Console.WriteLine(pointOne.Mass);
            //pointOne.Mass = 45;
            //Console.WriteLine(pointOne.Mass);

            //Console.WriteLine(pointOne.Distance(pointTwo));
            //Console.WriteLine(pointTwo.IsZero());
            //Console.WriteLine(pointThree.IsZero());

            //// Task 2.2
            //DiagonalMatrix diagonalMatrixOne = new DiagonalMatrix(new int[] { 1, 2, 3 });
            //DiagonalMatrix diagonalMatrixTwo = new DiagonalMatrix(new int[] { 4, 5, 6 });
            //DiagonalMatrix diagonalMatrixThree = new DiagonalMatrix(new int[] { 4, 5, 6, 7, 8 });
            //DiagonalMatrix diagonalMatrixFour = new DiagonalMatrix(null);
            //Console.WriteLine(diagonalMatrixOne.ToString());
            //Console.WriteLine(diagonalMatrixTwo.ToString());

            //var joinedMatrixOne = diagonalMatrixOne.AddMatrix(diagonalMatrixTwo);
            //Console.WriteLine(joinedMatrixOne.ToString());
            //var joinedMatrixTwo = diagonalMatrixOne.AddMatrix(diagonalMatrixThree);
            //Console.WriteLine(joinedMatrixTwo.ToString());

            //Console.WriteLine(diagonalMatrixFour.ToString());

            ////Task 2.3

            var lectureOne = new Lecture("Short intro to C# language", "C# basics");
            var lectureTwo = new Lecture("Short intro to Java language", "Java basics");
            var lectureThree = new Lecture("Short intro to JavaScript language", "JavaScript basics");

            var practicalLessonOne = new PracticalLesson("Simple task to add two Numbers", "Add 3 and 3", "6");
            var practicalLessonTwo = new PracticalLesson("Simple task to subtract Numbers", "Subtract 5 and 3", "2");
            var practicalLessonThree = new PracticalLesson("Simple task to multiply two Numbers", "Multiply 3 and 3", "9");

            var allClasses = new SchoolOccupationBase[]
            {
                lectureOne,
                lectureTwo,
                lectureThree,
                practicalLessonOne,
                practicalLessonTwo,
                practicalLessonThree
            };
            var allLectures = new SchoolOccupationBase[]
            {
                lectureOne,
                lectureTwo,
                lectureThree,
            };
            var allPracticalLessons = new SchoolOccupationBase[]
            {
                practicalLessonOne,
                practicalLessonTwo,
                practicalLessonThree,
            };

            var trainingOne = new Training("All classes together", allClasses);
            Console.WriteLine(trainingOne.IsPractical());

            var trainingTwo = new Training("All lectures", allLectures);
            var trainingThree = new Training("All practical lessons", allPracticalLessons);

            Console.WriteLine(trainingThree.IsPractical());
            var clonedTraining = trainingThree.Clone();

            trainingThree.Add(lectureOne);

            Console.WriteLine(trainingThree.IsPractical());
            Console.WriteLine(clonedTraining.IsPractical());
        }
    }
}
