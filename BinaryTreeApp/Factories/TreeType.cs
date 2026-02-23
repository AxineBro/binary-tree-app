namespace BinaryTreeApp.Factories
{
    /// <summary>
    /// Перечисление типов деревьев, поддерживаемых фабрикой.
    /// </summary>
    public enum TreeType
    {
        /// <summary>
        /// Бинарное дерево поиска (BST).
        /// </summary>
        BinarySearch,

        /// <summary>
        /// Сбалансированное дерево (например, AVL или Red-Black).
        /// </summary>
        Balanced,

        /// <summary>
        /// Простое бинарное дерево (без балансировки или поиска).
        /// </summary>
        Simple
    }
}