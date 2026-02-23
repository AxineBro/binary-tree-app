using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Бинарное дерево поиска. Не балансируется автоматически.
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    public class BinarySearchTree<T> : ITree<T> where T : IComparable<T>
    {
        private ITreeNode<T> _root;
        private int _count;

        /// <inheritdoc />
        public ITreeNode<T> Root => _root;

        /// <inheritdoc />
        public int Count => _count;

        /// <inheritdoc />
        public bool IsEmpty => _root == null;

        /// <inheritdoc />
        public void Insert(T value)
        {
            _root = InsertRec(_root, value, null);
            _count++;
        }

        private ITreeNode<T> InsertRec(ITreeNode<T> node, T value, ITreeNode<T> parent)
        {
            if (node == null)
            {
                var newNode = new TreeNode<T>(value) { Parent = parent };
                return newNode;
            }

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = InsertRec(node.Left, value, node);
            else if (cmp > 0)
                node.Right = InsertRec(node.Right, value, node);
            else
                throw new InvalidOperationException("Дерево не содержит дубликатов.");

            return node;
        }

        /// <inheritdoc />
        public bool Remove(T value)
        {
            if (_root == null) return false;

            if (!Contains(value)) return false;

            _root = RemoveRec(_root, value);
            _count--;
            return true;
        }

        private ITreeNode<T> RemoveRec(ITreeNode<T> node, T value)
        {
            if (node == null) return null;

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
                node.Left = RemoveRec(node.Left, value);
            else if (cmp > 0)
                node.Right = RemoveRec(node.Right, value);
            else
            {
                if (node.Left == null)
                {
                    if (node.Right != null) node.Right.Parent = node.Parent;
                    return node.Right;
                }
                if (node.Right == null)
                {
                    node.Left.Parent = node.Parent;
                    return node.Left;
                }

                ITreeNode<T> successor = FindMinRec(node.Right);
                node.Value = successor.Value;
                node.Right = RemoveRec(node.Right, successor.Value);
            }
            return node;
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
        public int GetHeight() => GetHeight(_root);

        /// <inheritdoc />
        public int GetHeight(ITreeNode<T> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        /// <inheritdoc />
        public IEnumerable<T> InOrder() => InOrderRec(_root);

        private IEnumerable<T> InOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var val in InOrderRec(node.Left))
                yield return val;
            yield return node.Value;
            foreach (var val in InOrderRec(node.Right))
                yield return val;
        }

        /// <inheritdoc />
        public IEnumerable<T> PreOrder() => PreOrderRec(_root);

        private IEnumerable<T> PreOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            yield return node.Value;
            foreach (var val in PreOrderRec(node.Left))
                yield return val;
            foreach (var val in PreOrderRec(node.Right))
                yield return val;
        }

        /// <inheritdoc />
        public IEnumerable<T> PostOrder() => PostOrderRec(_root);

        private IEnumerable<T> PostOrderRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var val in PostOrderRec(node.Left))
                yield return val;
            foreach (var val in PostOrderRec(node.Right))
                yield return val;
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
                var current = queue.Dequeue();
                yield return current.Value;
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
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