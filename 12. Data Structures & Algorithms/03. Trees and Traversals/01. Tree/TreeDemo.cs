/*
 * 1. You are given a tree of N nodes represented as a set 
 * of N-1 pairs of nodes (parent node, child node), 
 * each in the range (0..N-1).
 Example:
	7
	2 4
	3 2
	5 0
	3 5
	5 6
	5 1
	![tree-img](tree.png)
	Write a program to read the tree and find:
	- the root node
	- all leaf nodes
	- all middle nodes
	- the longest path in the tree
 */
namespace _01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TreeDemo
    {
        private static void Main()
        {

            var tree = new Tree<int>();
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            ReadInput(tree);

            //Print All Nodes
            //PrintNodes(tree.Nodes);


            // 1. Root Node
            Console.WriteLine("----- Root node -----");
            Console.WriteLine(tree.ParentNode);

            // 2. Middle Nodes
            Console.WriteLine("----- Middle nodes -----");
            PrintNodes(tree.MiddleNodes);

            // 3. Leaf Nodes
            Console.WriteLine("----- Leaf nodes -----");
            PrintNodes(tree.LeafNodes);

            // 4. Longest Path
            Console.WriteLine("----- Longest Path(s) ----");
            var paths = GetLongestPathInTree(tree.ParentNode);
            foreach (var path in paths)
            {
                Console.WriteLine("{0}", string.Join(" -> ", path));
            }
        }

        private static void PrintNodes(IEnumerable<Node<int>> nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
        }

        private static void ReadInput(Tree<int> tree)
        {
            var input = Console.ReadLine();
            if (input != null)
            {
                var numberOfNodes = int.Parse(input);
                for (int i = 0; i < numberOfNodes - 1; i++)
                {
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        var values = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        tree.ConnectNodes(values[0], values[1]);
                    }
                }
            }
        }

        private static IEnumerable<List<int>> GetLongestPathInTree(Node<int> startupNode)
        {
            var allLongestPathsInSubtree = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            var maxLength = 0;
            CalculatePathsInSubtree(startupNode, currentPath, allLongestPathsInSubtree, ref maxLength);

            var longestPaths = allLongestPathsInSubtree.Where(p => p.Count == maxLength).ToList();
            return longestPaths;
        }

        private static void CalculatePathsInSubtree(Node<int> node, LinkedList<int> currentPath, IList<List<int>> allPaths, ref int maxLength)
        {
            currentPath.AddLast(node.Value);

            if (node.Children.Count == 0 && currentPath.Count >= maxLength)
            {
                allPaths.Add(currentPath.ToList());

                if (currentPath.Count > maxLength)
                {
                    maxLength = currentPath.Count;
                }

                return;
            }

            foreach (var childNode in node.Children)
            {
                CalculatePathsInSubtree(childNode, currentPath, allPaths, ref maxLength);
                currentPath.RemoveLast();
            }
        }
    }
}
