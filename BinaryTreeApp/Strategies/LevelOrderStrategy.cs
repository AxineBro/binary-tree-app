using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Стратегия обхода дерева по уровням (level-order / breadth-first traversal).
    /// Узлы посещаются сверху вниз, слева направо на каждом уровне.
    /// </summary>
    /// <typeparam name="T">Тип значений, хранящихся в узлах дерева. Должен реализовывать IComparable&lt;T&gt;.</typeparam>
    public class LevelOrderStrategy<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет level-order обход дерева, начиная с указанного корневого узла.
        /// </summary>
        /// <param name="root">Корневой узел дерева. Может быть <c>null</c> (пустое дерево).</param>
        /// <returns>Последовательность значений узлов в порядке обхода по уровням.</returns>
        public IEnumerable<T> Traverse(ITreeNode<T> root)
        {
            if (root == null) yield break;

            var queue = new Queue<ITreeNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current.Value;

                if (current.Left != null)
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }
    }
}