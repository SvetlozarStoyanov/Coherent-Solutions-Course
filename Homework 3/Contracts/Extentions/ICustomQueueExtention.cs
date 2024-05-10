namespace Homework_3.Contracts.Extentions
{
    public static class ICustomQueueExtention
    {
        public static ICustomQueue<T> Tail<T>(this ICustomQueue<T> queue) where T : struct
        {
            var removed = queue.Dequeue();
            var tempQueue = new CustomQueue<T>();
            tempQueue.Enqueue(removed);
            var newQueue = new CustomQueue<T>();
            while (!queue.IsEmpty())
            {
                removed = queue.Dequeue();
                tempQueue.Enqueue(removed);
                newQueue.Enqueue(removed);
            }
            while (!tempQueue.IsEmpty())
            {
                removed = tempQueue.Dequeue();
                queue.Enqueue(removed);
            }
            return newQueue;
        }
    }
}