using Homework_3.Contracts.Extentions;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            Console.WriteLine(queue.IsEmpty());
            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            queue.Enqueue(1);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.IsEmpty());
            queue.Enqueue(2);
            queue.Enqueue(1);
            queue.Enqueue(0);
            Console.WriteLine(queue.IsEmpty());
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var newQueue = queue.Tail();
            while (!newQueue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
