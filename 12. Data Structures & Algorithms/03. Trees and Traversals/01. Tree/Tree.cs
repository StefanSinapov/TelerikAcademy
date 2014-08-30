namespace _01.Tree
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Tree<T>
    {
        private readonly IDictionary<T, Node<T>> nodes = new Dictionary<T, Node<T>>();

        public IReadOnlyCollection<Node<T>> Nodes
        {
            get { return new ReadOnlyCollection<Node<T>>(this.nodes.Values.ToList()); }
        }

        public Node<T> ParentNode
        {
            get { return this.Nodes.First(n => n.Parent == null); }
        }

        public IReadOnlyCollection<Node<T>> MiddleNodes
        {
            get { return this.Nodes.Where(n => n.Parent != null && n.Children.Count != 0).ToList(); }
        }

        public IReadOnlyCollection<Node<T>> LeafNodes
        {
            get { return this.Nodes.Where(n => n.Children.Count == 0).ToList(); }
        }

        public void ConnectNodes(T parrentValue, T childValue)
        {
            var parrentNode = GetNode(parrentValue);
            var childNode = GetNode(childValue);
            parrentNode.Children.Add(childNode);
            childNode.Parent = parrentNode;
        }

        private Node<T> GetNode(T value)
        {
            if (!this.nodes.ContainsKey(value))
            {
                var node = new Node<T>(value);
                this.nodes[value] = node;
                return node;
            }
            return this.nodes[value];
        }
    }
}