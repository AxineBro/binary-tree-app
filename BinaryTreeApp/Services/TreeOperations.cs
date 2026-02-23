using BinaryTreeApp.Models;
using BinaryTreeApp.Strategies;
using System;
using System.Collections.Generic;

namespace BinaryTreeApp.Services
{
    /// <summary>
    /// Класс для выполнения различных операций над деревом, включая обходы и запросы по глубине.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева. Должен поддерживать сравнение.</typeparam>
    public class TreeOperations<T> where T : IComparable<T>
    {
        /// <summary>
        /// Возвращает значения на указанной глубине дерева (BFS-подход).
        /// </summary>
        /// <param name="root">Корень дерева. Может быть null.</param>
        /// <param name="depth">Глубина (0 – корень). Должна быть >= 0.</param>
        /// <returns>Список значений на заданной глубине. Пустой список, если глубина невалидна или дерево пусто.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если depth < 0.</exception>
        public List<T> GetValuesAtDepth(ITreeNode<T> root, int depth)
        {
            if (depth < 0) throw new ArgumentOutOfRangeException(nameof(depth), "Глубина не может быть отрицательной.");
            var result = new List<T>();
            if (root == null) return result;

            var queue = new Queue<(ITreeNode<T> node, int level)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (node, level) = queue.Dequeue();
                if (level == depth)
                    result.Add(node.Value);
                else if (level < depth)
                {
                    if (node.Left != null) queue.Enqueue((node.Left, level + 1));
                    if (node.Right != null) queue.Enqueue((node.Right, level + 1));
                }
            }

            return result;
        }

        /// <summary>
        /// Выполняет обход дерева с использованием заданной стратегии.
        /// </summary>
        /// <param name="root">Корень дерева.</param>
        /// <param name="strategy">Стратегия обхода.</param>
        /// <returns>Последовательность значений в порядке обхода.</returns>
        /// <exception cref="ArgumentNullException">Если strategy null.</exception>
        public IEnumerable<T> Traverse(ITreeNode<T> root, ITraversalStrategy<T> strategy)
        {
            if (strategy == null) throw new ArgumentNullException(nameof(strategy));
            return strategy.Traverse(root);
        }
    }
}