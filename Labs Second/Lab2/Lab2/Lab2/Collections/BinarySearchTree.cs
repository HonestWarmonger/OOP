using System.Collections;
using System.Collections.Generic;

namespace Lab32_Var11.Collections
{
    public class BinarySearchTree<T> : IEnumerable<T> where T : class, System.IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left, Right;
            public Node(T v) { Value = v; }
        }

        private Node _root;

        public void Add(T item) => _root = Insert(_root, item);

        private Node Insert(Node node, T item)
        {
            if (node == null) return new Node(item);
            int cmp = item.CompareTo(node.Value);
            if (cmp < 0) node.Left = Insert(node.Left, item);
            else node.Right = Insert(node.Right, item);
            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root == null) yield break;
            Stack<Node> stack = new();
            HashSet<Node> visited = new();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node.Left != null && !visited.Contains(node.Left))
                    stack.Push(node.Left);
                else if (node.Right != null && !visited.Contains(node.Right))
                    stack.Push(node.Right);
                else
                {
                    yield return node.Value;
                    visited.Add(node);
                    stack.Pop();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
