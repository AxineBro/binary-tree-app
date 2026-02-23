using BinaryTreeApp.Models;
using System;

namespace BinaryTreeApp.Factories
{
    /// <summary>
    /// Фабрика для создания экземпляров деревьев.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева. Должен поддерживать сравнение.</typeparam>
    public class TreeFactory<T> where T : IComparable<T>
    {
        /// <summary>
        /// Создаёт дерево указанного типа.
        /// </summary>
        /// <param name="type">Тип дерева.</param>
        /// <returns>Экземпляр дерева с элементами заданного типа.</returns>
        /// <exception cref="ArgumentException">Если тип неизвестен.</exception>
        public ITree<T> CreateTree(TreeType type)
        {
            return type switch
            {
                TreeType.BinarySearch => new BinarySearchTree<T>(),
                TreeType.Balanced => new BalancedTree<T>(),
                TreeType.Simple => new SimpleTree<T>(),
                _ => throw new ArgumentException($"Неизвестный тип дерева: {type}", nameof(type))
            };
        }
    }
}