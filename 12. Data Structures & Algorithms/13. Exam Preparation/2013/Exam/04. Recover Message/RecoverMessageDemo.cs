namespace _04.Recover_Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RecoverMessageDemo
    {
        private static Dictionary<char, Node<char>> graph = new Dictionary<char, Node<char>>();


        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var inputLine = Console.ReadLine();
                for (int j = 0; j < inputLine.Length; j++)
                {
                    var ch = inputLine[j];
                    var node = GetOrCreateNode(ch);

                    if (j > 0)
                    {
                        var parrent = GetOrCreateNode(inputLine[j - 1]);
                        node.Parrents.Add(parrent);
                    }
                    if (j < inputLine.Length - 1)
                    {
                        var child = GetOrCreateNode(inputLine[j + 1]);
                        node.Childer.Add(child);
                    }
                }
            }


            var withoutParent = graph.Where(c => c.Value.Parrents.Count == 0).Select(c => c.Value);

            var allNodesWithNoIncoming = new SortedSet<Node<char>>(withoutParent);
            
            string currentResult=string.Empty;

            while (allNodesWithNoIncoming.Count != 0)
            {
                var node = allNodesWithNoIncoming.First();
                allNodesWithNoIncoming.Remove(node);
                currentResult += node.Name;
                var children = node.Childer.ToList();
                foreach (var child in children)
                {
                    node.Childer.Remove(child);
                    if (child.Parrents.Contains(node))
                    {
                        child.Parrents.Remove(node);
                    }
                    if (child.Parrents.Count == 0)
                    {
                        allNodesWithNoIncoming.Add(child);
                    }
                }
            }

            Console.WriteLine(currentResult);
        }

        public static Node<char> GetOrCreateNode(char ch)
        {
            if (!graph.ContainsKey(ch))
            {
                graph.Add(ch, new Node<char>(ch));
            }

            return graph[ch];
        }
    }

    public class Node<T> : IComparable where T: IComparable
    {

        public Node(T name)
        {
            this.Name = name;
            this.Childer = new HashSet<Node<T>>();
            this.Parrents = new HashSet<Node<T>>();
        }

        public ICollection<Node<T>> Parrents { get; set; }

        public T Name { get; set; }

        public ICollection<Node<T>> Childer { get; set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as Node<T>).Name);
        }
    }
}

/*
 * 
L ← Empty list that will contain the sorted elements
S ← Set of all nodes with no incoming edges
while S is non-empty do
    remove a node n from S
    insert n into L
    for each node m with an edge e from n to m do
        remove edge e from the graph
        if m has no other incoming edges then
            insert m into S
if graph has edges then
    return error (graph has at least one cycle)
else 
    return L (a topologically sorted order)

 */
