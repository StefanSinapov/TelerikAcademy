namespace _03.Friends_in_Need
{
    using System;

    public class Edge<T> : IComparable
    {


        public Edge(Node<T> begining, Node<T> target, double distance)
        {
            this.Beginning = begining;
            this.Target = target;
            this.Distance = distance;
        }

        public Node<T> Beginning { get; private set; }
        public Node<T> Target { get; private set; }
        public double Distance { get; private set; }

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