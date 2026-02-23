using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Базовая реализация узла бинарного дерева.
    /// </summary>
    /// <typeparam name="T">Тип значения узла.</typeparam>
    public class TreeNode<T> : ITreeNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Инициализирует новый экземпляр узла с указанным значением.
        /// </summary>
        /// <param name="value">Значение узла.</param>
        public TreeNode(T value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public T Value { get; set; }

        /// <inheritdoc />
        public ITreeNode<T> Left { get; set; }

        /// <inheritdoc />
        public ITreeNode<T> Right { get; set; }

        /// <inheritdoc />
        public ITreeNode<T> Parent { get; set; }

        /// <inheritdoc />
        public bool IsLeaf => Left == null && Right == null;

        /// <summary>
        /// Возвращает строковое представление узла.
        /// </summary>
        public override string ToString() => Value.ToString();
    }
}