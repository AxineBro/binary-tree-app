using System;
using System.Windows.Forms;

namespace BinaryTreeApp
{
    /// <summary>
    /// Точка входа приложения.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Основная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}