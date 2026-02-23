using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Сбалансированное AVL-дерево. Автоматически балансируется после вставки и удаления.
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    public class BalancedTree<T> : ITree<T> where T : IComparable<T>
    {
        private ITreeNode<T> _root;
        private int _count;

        private class AvlNode : ITreeNode<T>
        {
            public T Value { get; set; }
            public ITreeNode<T> Left { get; set; }
            public ITreeNode<T> Right { get; set; }
            public ITreeNode<T> Parent { get; set; }
            public bool IsLeaf => Left == null && Right == null;

            public int Height { get; set; } = 1;

            public AvlNode(T value)
            {
                Value = value;
            }
        }

        /// <inheritdoc />
        public ITreeNode<T> Root => _root;

        /// <inheritdoc />
        public int Count => _count;

        /// <inheritdoc />
        public bool IsEmpty => _root == null;

        /// <inheritdoc />
        public void Insert(T value)
        {
            _root = InsertRec((AvlNode)_root, value, null);
            _count++;
        }

        private AvlNode InsertRec(AvlNode node, T value, AvlNode parent)
        {
            if (node == null)
            {
                var newNode = new AvlNode(value) { Parent = parent };
                return newNode;
            }

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = InsertRec((AvlNode)node.Left, value, node);
            else if (cmp > 0)
                node.Right = InsertRec((AvlNode)node.Right, value, node);
            else
                throw new InvalidOperationException("Дубликаты не допускаются.");

            node.Height = 1 + Math.Max(GetHeight((AvlNode)node.Left), GetHeight((AvlNode)node.Right));

            return Balance(node);
        }

        /// <inheritdoc />
        public bool Remove(T value)
        {
            if (_root == null) return false;
            if (!Contains(value)) return false;

            _root = RemoveRec((AvlNode)_root, value);
            _count--;
            return true;
        }

        private AvlNode RemoveRec(AvlNode node, T value)
        {
            if (node == null) return null;

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = RemoveRec((AvlNode)node.Left, value);
            else if (cmp > 0)
                node.Right = RemoveRec((AvlNode)node.Right, value);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    AvlNode temp = (AvlNode)(node.Left ?? node.Right);
                    if (temp == null)
                    {
                        return null;
                    }
                    else
                    {
                        temp.Parent = node.Parent;
                        node = temp;
                    }
                }
                else
                {
                    AvlNode minNode = (AvlNode)FindMinRec(node.Right);
                    node.Value = minNode.Value;
                    node.Right = RemoveRec((AvlNode)node.Right, minNode.Value);
                }
            }

            node.Height = 1 + Math.Max(GetHeight((AvlNode)node.Left), GetHeight((AvlNode)node.Right));

            return Balance(node);
        }

        private AvlNode Balance(AvlNode node)
        {
            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance((AvlNode)node.Left) < 0)
                    node.Left = RotateLeft((AvlNode)node.Left);
                return RotateRight(node);
            }
            if (balance < -1)
            {
                if (GetBalance((AvlNode)node.Right) > 0)
                    node.Right = RotateRight((AvlNode)node.Right);
                return RotateLeft(node);
            }
            return node;
        }

        private int GetHeight(AvlNode node) => node?.Height ?? 0;
        private int GetBalance(AvlNode node) => GetHeight((AvlNode)node.Left) - GetHeight((AvlNode)node.Right);

        private AvlNode RotateRight(AvlNode y)
        {
            AvlNode x = (AvlNode)y.Left;
            AvlNode T2 = (AvlNode)x.Right;

            x.Right = y;
            y.Left = T2;

            x.Parent = y.Parent;
            y.Parent = x;
            if (T2 != null) T2.Parent = y;

            y.Height = 1 + Math.Max(GetHeight((AvlNode)y.Left), GetHeight((AvlNode)y.Right));
            x.Height = 1 + Math.Max(GetHeight((AvlNode)x.Left), GetHeight((AvlNode)x.Right));

            return x;
        }

        private AvlNode RotateLeft(AvlNode x)
        {
            AvlNode y = (AvlNode)x.Right;
            AvlNode T2 = (AvlNode)y.Left;

            y.Left = x;
            x.Right = T2;

            y.Parent = x.Parent;
            x.Parent = y;
            if (T2 != null) T2.Parent = x;

            x.Height = 1 + Math.Max(GetHeight((AvlNode)x.Left), GetHeight((AvlNode)x.Right));
            y.Height = 1 + Math.Max(GetHeight((AvlNode)y.Left), GetHeight((AvlNode)y.Right));

            return y;
        }

        /// <inheritdoc />
        public bool Contains(T value) => Find(value) != null;

        /// <inheritdoc />
        public ITreeNode<T> Find(T value) => FindRec(_root, value);

        private ITreeNode<T> FindRec(ITreeNode<T> node, T value)
        {
            if (node == null) return null;
            int cmp = value.CompareTo(node.Value);
            if (cmp == 0) return node;
            if (cmp < 0) return FindRec(node.Left, value);
            return FindRec(node.Right, value);
        }

        /// <inheritdoc />
        public ITreeNode<T> FindMin() => FindMinRec(_root);
        private ITreeNode<T> FindMinRec(ITreeNode<T> node)
        {
            if (node == null) return null;
            while (node.Left != null) node = node.Left;
            return node;
        }

        /// <inheritdoc />
        public ITreeNode<T> FindMax() => FindMaxRec(_root);
        private ITreeNode<T> FindMaxRec(ITreeNode<T> node)
        {
            if (node == null) return null;
            while (node.Right != null) node = node.Right;
            return node;
        }

        /// <inheritdoc />
        public int GetHeight() => GetHeight((AvlNode)_root);

        /// <inheritdoc />
        public int GetHeight(ITreeNode<T> node) => node == null ? -1 : ((AvlNode)node).Height;

        /// <inheritdoc />
        public IEnumerable<T> InOrder() => InOrderRec(_root);
        private IEnumerable<T> InOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var v in InOrderRec(node.Left)) yield return v;
            yield return node.Value;
            foreach (var v in InOrderRec(node.Right)) yield return v;
        }

        /// <inheritdoc />
        public IEnumerable<T> PreOrder() => PreOrderRec(_root);
        private IEnumerable<T> PreOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            yield return node.Value;
            foreach (var v in PreOrderRec(node.Left)) yield return v;
            foreach (var v in PreOrderRec(node.Right)) yield return v;
        }

        /// <inheritdoc />
        public IEnumerable<T> PostOrder() => PostOrderRec(_root);
        private IEnumerable<T> PostOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var v in PostOrderRec(node.Left)) yield return v;
            foreach (var v in PostOrderRec(node.Right)) yield return v;
            yield return node.Value;
        }

        /// <inheritdoc />
        public IEnumerable<T> LevelOrder()
        {
            if (_root == null) yield break;
            var queue = new Queue<ITreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                yield return cur.Value;
                if (cur.Left != null) queue.Enqueue(cur.Left);
                if (cur.Right != null) queue.Enqueue(cur.Right);
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            _root = null;
            _count = 0;
        }
    }
}