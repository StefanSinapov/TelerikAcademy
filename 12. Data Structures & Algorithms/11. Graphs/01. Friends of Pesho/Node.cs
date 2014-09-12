namespace _01.Friends_of_Pesho
{
    using System;

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int Id { get; private set; }

        public double DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Node))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}