using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Стратегия обхода дерева для получения значений только листьев (узлов без детей).
    /// Использует рекурсивный post-order подход для сбора значений листьев.
    /// </summary>
    /// <typeparam name="T">Тип значений, хранящихся в узлах дерева. Должен реализовывать IComparable&lt;T&gt;.</typeparam>
    public class LeafTraversalStrategy<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет обход дерева и возвращает значения только листьев.
        /// </summary>
        /// <param name="root">Корневой узел дерева. Может быть <c>null</c> (пустое дерево).</param>
        /// <returns>Последовательность значений листьев в порядке обхода (left-to-right).</returns>
        public IEnumerable<T> Traverse(ITreeNode<T> root)
        {
            return TraverseRec(root);
        }

        /// <summary>
        /// Рекурсивная реализация сбора значений листьев.
        /// </summary>
        /// <param name="node">Текущий узел для обработки.</param>
        /// <returns>Итератор, возвращающий значения листьев в поддереве.</returns>
        private IEnumerable<T> TraverseRec(ITreeNode<T> node)
        {
            if (node == null) yield break;

            foreach (var v in TraverseRec(node.Left))
                yield return v;

            foreach (var v in TraverseRec(node.Right))
                yield return v;

            if (node.Left == null && node.Right == null)
                yield return node.Value;
        }
    }
}