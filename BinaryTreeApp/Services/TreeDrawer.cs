using BinaryTreeApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BinaryTreeApp.Services
{
    /// <summary>
    /// Класс для отрисовки дерева на поверхности Graphics с адаптивным масштабированием.
    /// Поддерживает автоматическое центрирование и масштаб по ширине.
    /// </summary>
    /// <typeparam name="T">Тип элементов дерева. Должен поддерживать сравнение.</typeparam>
    public class TreeDrawer<T> where T : IComparable<T>
    {
        private const int NodeRadius = 20;
        private const int MinHorizontalSpacing = 10;
        private const int VerticalSpacing = 60;
        private Dictionary<ITreeNode<T>, PointF> _positions;
        private const int leftShift = 200;

        /// <summary>
        /// Отрисовывает дерево.
        /// </summary>
        /// <param name="root">Корень дерева. Может быть null (пустое дерево).</param>
        /// <param name="g">Объект Graphics для рисования. Не может быть null.</param>
        /// <param name="bounds">Область рисования.</param>
        /// <exception cref="ArgumentNullException">Если g null.</exception>
        public void Draw(ITreeNode<T> root, Graphics g, Rectangle bounds)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));
            if (root == null) return;

            _positions = new Dictionary<ITreeNode<T>, PointF>();

            int height = GetHeight(root);
            float initialOffset = (float)(bounds.Width- leftShift) / (float)Math.Pow(2, height) / 2f;
            initialOffset = Math.Max(initialOffset, MinHorizontalSpacing + 2 * NodeRadius);

            CalculatePositions(root, (bounds.Width - leftShift) / 2f, NodeRadius + 10f, initialOffset);

            float minX = float.MaxValue, maxX = float.MinValue;
            foreach (var pos in _positions.Values)
            {
                minX = Math.Min(minX, pos.X);
                maxX = Math.Max(maxX, pos.X);
            }

            float logicalWidth = maxX - minX;
            float scaleX = logicalWidth > 0 ? ((bounds.Width - leftShift) - 2 * NodeRadius) / logicalWidth : 1f;
            float offsetX = ((bounds.Width - leftShift) - logicalWidth * scaleX) / 2f - minX * scaleX;

            foreach (var key in _positions.Keys.ToArray())
            {
                var pos = _positions[key];
                _positions[key] = new PointF(pos.X * scaleX + offsetX, pos.Y);
            }

            DrawNode(root, g);
        }

        /// <summary>
        /// Рассчитывает позиции узлов рекурсивно.
        /// </summary>
        /// <param name="node">Текущий узел.</param>
        /// <param name="x">X-координата.</param>
        /// <param name="y">Y-координата.</param>
        /// <param name="offset">Смещение для детей.</param>
        private void CalculatePositions(ITreeNode<T> node, float x, float y, float offset)
        {
            if (node == null) return;
            _positions[node] = new PointF(x, y);
            CalculatePositions(node.Left, x - offset, y + VerticalSpacing, offset / 2f);
            CalculatePositions(node.Right, x + offset, y + VerticalSpacing, offset / 2f);
        }

        /// <summary>
        /// Отрисовывает узел и его детей рекурсивно.
        /// </summary>
        /// <param name="node">Текущий узел.</param>
        /// <param name="g">Graphics для рисования.</param>
        private void DrawNode(ITreeNode<T> node, Graphics g)
        {
            if (node == null) return;

            var pt = _positions[node];

            // Отрисовка связей с детьми (улучшено: от края к краю)
            if (node.Left != null)
            {
                var leftPt = _positions[node.Left];
                g.DrawLine(Pens.Black, pt.X, pt.Y + NodeRadius, leftPt.X, leftPt.Y - NodeRadius);
                DrawNode(node.Left, g);
            }
            if (node.Right != null)
            {
                var rightPt = _positions[node.Right];
                g.DrawLine(Pens.Black, pt.X, pt.Y + NodeRadius, rightPt.X, rightPt.Y - NodeRadius);
                DrawNode(node.Right, g);
            }

            // Отрисовка узла
            g.FillEllipse(Brushes.LightBlue, pt.X - NodeRadius, pt.Y - NodeRadius, 2 * NodeRadius, 2 * NodeRadius);
            g.DrawEllipse(Pens.Black, pt.X - NodeRadius, pt.Y - NodeRadius, 2 * NodeRadius, 2 * NodeRadius);
            using var font = new Font("Arial", 10);
            var text = node.Value.ToString() ?? string.Empty;
            var textSize = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.Black, pt.X - textSize.Width / 2f, pt.Y - textSize.Height / 2f);
        }

        /// <summary>
        /// Получает высоту дерева.
        /// </summary>
        /// <param name="node">Корень дерева.</param>
        /// <returns>Высота дерева (0 для null).</returns>
        private int GetHeight(ITreeNode<T> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
    }
}