using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeApp.Models
{
    /// <summary>
    /// Интерфейс бинарного дерева.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева. Должен поддерживать сравнение.</typeparam>
    public interface ITree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Получает корневой узел дерева.
        /// </summary>
        ITreeNode<T> Root { get; }

        /// <summary>
        /// Получает количество узлов в дереве.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Получает значение, указывающее, пусто ли дерево.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Вставляет новый элемент в дерево.
        /// </summary>
        /// <param name="value">Вставляемое значение.</param>
        void Insert(T value);

        /// <summary>
        /// Удаляет элемент из дерева.
        /// </summary>
        /// <param name="value">Удаляемое значение.</param>
        /// <returns>true, если элемент был найден и удален; иначе false.</returns>
        bool Remove(T value);

        /// <summary>
        /// Определяет, содержится ли указанный элемент в дереве.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns>true, если элемент найден; иначе false.</returns>
        bool Contains(T value);

        /// <summary>
        /// Находит узел с указанным значением.
        /// </summary>
        /// <param name="value">Искомое значение.</param>
        /// <returns>Узел или null, если не найден.</returns>
        ITreeNode<T> Find(T value);

        /// <summary>
        /// Находит узел с минимальным значением в дереве.
        /// </summary>
        /// <returns>Узел с минимальным значением или null, если дерево пусто.</returns>
        ITreeNode<T>? FindMin();

        /// <summary>
        /// Находит узел с максимальным значением в дереве.
        /// </summary>
        /// <returns>Узел с максимальным значением или null, если дерево пусто.</returns>
        ITreeNode<T>? FindMax();

        /// <summary>
        /// Получает высоту дерева.
        /// </summary>
        /// <returns>Высота (максимальная глубина). Для пустого дерева возвращает -1.</returns>
        int GetHeight();

        /// <summary>
        /// Получает высоту указанного поддерева.
        /// </summary>
        /// <param name="node">Корень поддерева.</param>
        /// <returns>Высота поддерева.</returns>
        int GetHeight(ITreeNode<T> node);

        /// <summary>
        /// Выполняет центрированный (симметричный) обход дерева.
        /// </summary>
        /// <returns>Последовательность значений в порядке возрастания (для BST).</returns>
        IEnumerable<T> InOrder();

        /// <summary>
        /// Выполняет прямой обход дерева (корень, левое, правое).
        /// </summary>
        IEnumerable<T> PreOrder();

        /// <summary>
        /// Выполняет обратный обход дерева (левое, правое, корень).
        /// </summary>
        IEnumerable<T> PostOrder();

        /// <summary>
        /// Выполняет обход дерева в ширину (по уровням).
        /// </summary>
        IEnumerable<T> LevelOrder();

        /// <summary>
        /// Удаляет все узлы из дерева.
        /// </summary>
        void Clear();
    }
}