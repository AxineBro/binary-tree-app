using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Стратегия обратного (post-order) обхода дерева: левое поддерево → правое поддерево → корень.
    /// </summary>
    /// <typeparam name="T">Тип значений, хранящихся в узлах дерева. Должен реализовывать IComparable&lt;T&gt;.</typeparam>
    public class PostOrderStrategy<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет post-order обход дерева, начиная с указанного корневого узла.
        /// </summary>
        /// <param name="root">Корневой узел дерева. Может быть <c>null</c> (пустое дерево).</param>
        /// <returns>Последовательность значений узлов в порядке post-order обхода.</returns>
        public IEnumerable<T> Traverse(ITreeNode<T> root)
        {
            return TraverseRec(root);
        }

        /// <summary>
        /// Рекурсивная реализация post-order обхода.
        /// </summary>
        /// <param name="node">Текущий узел для обработки.</param>
        /// <returns>Итератор, возвращающий значения узлов в порядке обхода.</returns>
        private IEnumerable<T> TraverseRec(ITreeNode<T> node)
        {
            if (node == null) yield break;

            foreach (var v in TraverseRec(node.Left))
                yield return v;

            foreach (var v in TraverseRec(node.Right))
                yield return v;

            yield return node.Value;
        }
    }
}