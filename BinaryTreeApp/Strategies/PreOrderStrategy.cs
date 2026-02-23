using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Стратегия прямого (pre-order) обхода дерева: корень → левое поддерево → правое поддерево.
    /// </summary>
    /// <typeparam name="T">Тип значений, хранящихся в узлах дерева. Должен реализовывать IComparable&lt;T&gt;.</typeparam>
    public class PreOrderStrategy<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет pre-order обход дерева, начиная с указанного корневого узла.
        /// </summary>
        /// <param name="root">Корневой узел дерева. Может быть <c>null</c> (пустое дерево).</param>
        /// <returns>Последовательность значений узлов в порядке pre-order обхода.</returns>
        public IEnumerable<T> Traverse(ITreeNode<T> root)
        {
            return TraverseRec(root);
        }

        /// <summary>
        /// Рекурсивная реализация pre-order обхода.
        /// </summary>
        /// <param name="node">Текущий узел для обработки.</param>
        /// <returns>Итератор, возвращающий значения узлов в порядке обхода.</returns>
        private IEnumerable<T> TraverseRec(ITreeNode<T> node)
        {
            if (node == null) yield break;

            yield return node.Value;

            foreach (var v in TraverseRec(node.Left))
                yield return v;

            foreach (var v in TraverseRec(node.Right))
                yield return v;
        }
    }
}