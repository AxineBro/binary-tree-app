using BinaryTreeApp.Factories;
using BinaryTreeApp.Models;
using BinaryTreeApp.Services;
using BinaryTreeApp.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BinaryTreeApp.Facades
{
    /// <summary>
    /// Фасад для управления деревом и операциями над ним.
    /// Предоставляет упрощённый интерфейс для UI.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева. Должен быть значимым типом (struct) и поддерживать сравнение. 
    /// Если нужен ссылочный тип (class), используйте отдельный фасад с where T : class.</typeparam>
    public class TreeFacade<T> where T : struct, IComparable<T>
    {
        private ITree<T> _currentTree;
        private readonly TreeFactory<T> _factory;
        private readonly TreeDrawer<T> _drawer;
        private readonly TreeOperations<T> _operations;
        private readonly Func<string, T> _parser;

        /// <summary>
        /// Событие, возникающее при изменении дерева (структура или тип).
        /// </summary>
        public event EventHandler TreeChanged;

        /// <summary>
        /// Инициализирует новый экземпляр фасада.
        /// </summary>
        /// <param name="factory">Фабрика для создания деревьев. Не может быть null.</param>
        /// <param name="parser">Функция для преобразования строки в значение типа T. Не может быть null.</param>
        /// <exception cref="ArgumentNullException">Если factory или parser null.</exception>
        public TreeFacade(TreeFactory<T> factory, Func<string, T> parser)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
            _drawer = new TreeDrawer<T>();
            _operations = new TreeOperations<T>();
            _currentTree = _factory.CreateTree(TreeType.BinarySearch);
        }

        /// <summary>
        /// Устанавливает тип текущего дерева (создаёт новое пустое дерево).
        /// </summary>
        /// <param name="type">Тип дерева.</param>
        public void SetTreeType(TreeType type)
        {
            _currentTree = _factory.CreateTree(type);
            OnTreeChanged();
        }

        /// <summary>
        /// Вставляет значение в дерево.
        /// </summary>
        /// <param name="value">Вставляемое значение.</param>
        public void Insert(T value)
        {
            _currentTree.Insert(value);
            OnTreeChanged();
        }

        /// <summary>
        /// Удаляет значение из дерева.
        /// </summary>
        /// <param name="value">Удаляемое значение.</param>
        /// <returns>true, если элемент был найден и удалён; иначе false.</returns>
        public bool Remove(T value)
        {
            var result = _currentTree.Remove(value);
            if (result) OnTreeChanged();
            return result;
        }

        /// <summary>
        /// Проверяет наличие значения.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <returns>true, если элемент найден; иначе false.</returns>
        public bool Contains(T value) => _currentTree.Contains(value);

        /// <summary>
        /// Находит минимальное значение.
        /// </summary>
        /// <returns>Минимальное значение или null, если дерево пусто.</returns>
        public T? FindMin() => _currentTree.FindMin()?.Value;

        /// <summary>
        /// Находит максимальное значение.
        /// </summary>
        /// <returns>Максимальное значение или null, если дерево пусто.</returns>
        public T? FindMax() => _currentTree.FindMax()?.Value;

        /// <summary>
        /// Получает высоту дерева.
        /// </summary>
        /// <returns>Высота (максимальная глубина). Для пустого дерева возвращает -1.</returns>
        public int GetHeight() => _currentTree?.GetHeight() ?? -1;  // Добавлена проверка на null

        /// <summary>
        /// Получает количество узлов.
        /// </summary>
        public int Count => _currentTree?.Count ?? 0;  // Добавлена проверка на null

        /// <summary>
        /// Возвращает список значений при симметричном обходе (in-order traversal).
        /// </summary>
        /// <returns>Список значений в порядке обхода.</returns>
        public List<T> InOrder() => new List<T>(_currentTree?.InOrder() ?? Enumerable.Empty<T>());

        /// <summary>
        /// Возвращает список значений при прямом обходе (pre-order traversal).
        /// </summary>
        /// <returns>Список значений в порядке обхода.</returns>
        public List<T> PreOrder() => new List<T>(_currentTree?.PreOrder() ?? Enumerable.Empty<T>());

        /// <summary>
        /// Возвращает список значений при обратном обходе (post-order traversal).
        /// </summary>
        /// <returns>Список значений в порядке обхода.</returns>
        public List<T> PostOrder() => new List<T>(_currentTree?.PostOrder() ?? Enumerable.Empty<T>());

        /// <summary>
        /// Возвращает список значений при обходе в ширину (level-order traversal).
        /// </summary>
        /// <returns>Список значений в порядке обхода.</returns>
        public List<T> LevelOrder() => new List<T>(_currentTree?.LevelOrder() ?? Enumerable.Empty<T>());

        /// <summary>
        /// Отрисовывает текущее дерево.
        /// </summary>
        /// <param name="g">Объект Graphics для рисования. Не может быть null.</param>
        /// <param name="bounds">Область рисования.</param>
        /// <exception cref="ArgumentNullException">Если g null.</exception>
        public void Draw(Graphics g, Rectangle bounds)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));
            _drawer.Draw(_currentTree?.Root, g, bounds);
        }

        /// <summary>
        /// Очищает дерево.
        /// </summary>
        public void Clear()
        {
            _currentTree.Clear();
            OnTreeChanged();
        }

        /// <summary>
        /// Возвращает значения на указанной глубине.
        /// </summary>
        /// <param name="depth">Глубина (0 – корень). Должна быть >= 0.</param>
        /// <returns>Список значений на заданной глубине. Пустой список, если глубина невалидна или дерево пусто.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если depth < 0.</exception>
        public List<T> GetValuesAtDepth(int depth)
        {
            if (depth < 0) throw new ArgumentOutOfRangeException(nameof(depth), "Глубина не может быть отрицательной.");
            return _operations.GetValuesAtDepth(_currentTree?.Root, depth);
        }

        /// <summary>
        /// Подсчитывает, сколько листьев имеют максимальное значение в дереве.
        /// Для простого дерева (Simple) максимум ищется среди всех листьев.
        /// </summary>
        /// <returns>Количество листьев с максимальным значением. 0, если дерево пусто.</returns>
        public int CountLeafMaxima()
        {
            if (_currentTree == null || _currentTree.Root == null)
                return 0;

            if (_currentTree is SimpleTree<T>)
            {
                var leafStrategy = new LeafTraversalStrategy<T>();
                var leaves = leafStrategy.Traverse(_currentTree.Root).ToList();

                if (leaves.Count == 0) return 0;

                T maxInLeaves = leaves.Max();
                return leaves.Count(v => v.CompareTo(maxInLeaves) == 0);
            }
            else
            {
                var maxOpt = FindMax();
                if (!maxOpt.HasValue) return 0;

                T globalMax = maxOpt.Value;

                var leafStrategy = new LeafTraversalStrategy<T>();
                var leaves = leafStrategy.Traverse(_currentTree.Root);

                return leaves.Count(v => v.CompareTo(globalMax) == 0);
            }
        }

        /// <summary>
        /// Строит дерево из строки, содержащей значения, разделённые пробелами или запятыми.
        /// </summary>
        /// <param name="input">Входная строка с значениями.</param>
        /// <exception cref="ArgumentException">Если строка содержит невалидные значения для типа T.</exception>
        public void BuildFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Clear();
                return;
            }

            var parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var values = new List<T>();

            foreach (var part in parts)
            {
                try
                {
                    T value = _parser(part.Trim());
                    values.Add(value);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Невозможно преобразовать '{part}' в тип {typeof(T).Name}: {ex.Message}", nameof(input));
                }
            }

            Clear();
            foreach (var value in values)
                Insert(value);
        }

        /// <summary>
        /// Вызывает событие TreeChanged.
        /// </summary>
        private void OnTreeChanged() => TreeChanged?.Invoke(this, EventArgs.Empty);
    }
}