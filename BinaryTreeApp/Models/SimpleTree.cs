using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Простое бинарное дерево, не являющееся деревом поиска.
    /// Вставка производится в первый свободный узел (обход в ширину), 
    /// удаление не поддерживается (можно расширить при необходимости).
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    public class SimpleTree<T> : ITree<T> where T : IComparable<T>
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
            var newNode = new TreeNode<T>(value);
            _count++;

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            Queue<ITreeNode<T>> queue = new Queue<ITreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    newNode.Parent = current;
                    return;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    newNode.Parent = current;
                    return;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        /// <inheritdoc />
        public bool Remove(T value) => throw new NotSupportedException("Простое дерево не поддерживает удаление.");

        /// <inheritdoc />
        public bool Contains(T value) => Find(value) != null;

        /// <inheritdoc />
        public ITreeNode<T> Find(T value)
        {
            if (_root == null) return null;
            var queue = new Queue<ITreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (cur.Value.CompareTo(value) == 0) return cur;
                if (cur.Left != null) queue.Enqueue(cur.Left);
                if (cur.Right != null) queue.Enqueue(cur.Right);
            }
            return null;
        }

        /// <inheritdoc />
        public ITreeNode<T> FindMin() => throw new NotSupportedException("Простое дерево не упорядочено, минимум не определён.");

        /// <inheritdoc />
        public ITreeNode<T> FindMax() => throw new NotSupportedException("Простое дерево не упорядочено, максимум не определён.");

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