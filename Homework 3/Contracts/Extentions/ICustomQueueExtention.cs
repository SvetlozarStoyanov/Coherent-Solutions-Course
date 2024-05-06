namespace Homework_3.Contracts.Extentions
{
    public static class ICustomQueueExtention
    {
        public static ICustomQueue<T> Tail<T>(this ICustomQueue<T> queue)
        {
            queue.Dequeue();
            return queue;
        }
    }
}
