using BinaryTreeApp.Models;
using System.Collections.Generic;

namespace BinaryTreeApp.Strategies
{
    /// <summary>
    /// Интерфейс стратегии обхода дерева.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева.</typeparam>
    public interface ITraversalStrategy<T> where T : IComparable<T>
    {
        /// <summary>
        /// Выполняет обход дерева, начиная с указанного корня.
        /// </summary>
        /// <param name="root">Корневой узел. Может быть null.</param>
        /// <returns>Последовательность значений в порядке обхода.</returns>
        IEnumerable<T> Traverse(ITreeNode<T> root);
    }
}