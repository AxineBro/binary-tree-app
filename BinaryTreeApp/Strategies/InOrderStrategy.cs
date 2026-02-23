using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Стратегия симметричного обхода дерева (in-order: left-root-right).
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева.</typeparam>
    public class InOrderStrategy<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет обход дерева.
        /// </summary>
        /// <param name="root">Корень дерева.</param>
        /// <returns>Значения в порядке обхода.</returns>
        public IEnumerable<T> Traverse(ITreeNode<T> root)
        {
            return TraverseRec(root);
        }

        private IEnumerable<T> TraverseRec(ITreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var v in TraverseRec(node.Left)) yield return v;
            yield return node.Value;
            foreach (var v in TraverseRec(node.Right)) yield return v;
        }
    }
}