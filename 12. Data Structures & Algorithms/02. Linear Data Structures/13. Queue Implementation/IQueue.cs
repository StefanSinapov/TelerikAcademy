namespace _13.Queue_Implementation
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        
        T Dequeue();

        T Peek();

        void Clear();

    }
}