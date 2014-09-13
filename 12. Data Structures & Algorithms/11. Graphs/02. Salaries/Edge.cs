namespace _02.Salaries
{
    using System;

    public class Edge<T> : IComparable
    {
        internal Node<T> Beginning { get; private set; }
        internal Node<T> Target { get; private set; }
        internal double Distance { get; private set; }

        internal Edge(Node<T> begining, Node<T> target, double distance)
        {
            this.Beginning = begining;
            this.Target = target;
            this.Distance = distance;
        }

        public int CompareTo(object obj)
        {
            return this.Distance.CompareTo((obj as Edge<T>).Distance);
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", Beginning, Target, Distance);
        }
    }
}