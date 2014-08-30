namespace _12.Stack_Implementation
{
    public interface IStack<T>
    {
        void Push(T value);

        T Pop();

        T Peek();

        int Count();

        void Clear();

        T[] ToArray();

        void TrimExcess();
    }
}