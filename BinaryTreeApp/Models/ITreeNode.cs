using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Представляет интерфейс узла бинарного дерева.
    /// </summary>
    /// <typeparam name="T">Тип значения, хранящегося в узле. Должен поддерживать сравнение.</typeparam>
    public interface ITreeNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Получает или задает значение узла.
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// Получает или задает левый дочерний узел.
        /// </summary>
        ITreeNode<T> Left { get; set; }

        /// <summary>
        /// Получает или задает правый дочерний узел.
        /// </summary>
        ITreeNode<T> Right { get; set; }

        /// <summary>
        /// Получает или задает родительский узел.
        /// </summary>
        ITreeNode<T> Parent { get; set; }

        /// <summary>
        /// Получает значение, указывающее, является ли узел листом (не имеет детей).
        /// </summary>
        bool IsLeaf { get; }
    }
}