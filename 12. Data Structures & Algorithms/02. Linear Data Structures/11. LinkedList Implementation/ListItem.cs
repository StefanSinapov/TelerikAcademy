namespace _11.LinkedList_Implementation
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }

        public ListItem<T> Previous { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}