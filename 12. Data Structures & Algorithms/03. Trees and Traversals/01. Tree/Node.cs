namespace _01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Node<T>
    {
        private ISet<Node<T>> children;
        private const string ChildrenCannotBeNullExceptionText = "Children cannot be null";

        public Node(T value)
            :this(value, new HashSet<Node<T>>())
        { }

        public Node(T value, ISet<Node<T>> children)
        {
            this.Value = value;
            this.Children = children;
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public ISet<Node<T>> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ChildrenCannotBeNullExceptionText);
                }
                this.children = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("Node:  {0}", this.Value));

            if (this.Children.Count > 0)
            {
                var childrenValues = this.Children.Select(c => c.Value);
                result.AppendFormat("   Direct children -> ({0})\n", string.Join(", ", childrenValues));
            }

            return result.ToString();
        }
    }
}