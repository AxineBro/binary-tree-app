using BinaryTreeApp.Facades;
using BinaryTreeApp.Factories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BinaryTreeApp
{
    /// <summary>
    /// Главная форма приложения для работы с бинарными деревьями.
    /// </summary>
    public partial class MainForm : Form
    {
        private TreeFacade<int> _facade;

        /// <summary>
        /// Инициализирует новый экземпляр главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeFacade();
            UpdateInfoPanel();
            this.Resize += OnResize;  // Добавлено для перерисовки при ресайзе
        }

        private void OnResize(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void InitializeFacade()
        {
            var factory = new TreeFactory<int>();
            _facade = new TreeFacade<int>(factory, int.Parse);
            _facade.TreeChanged += OnTreeChanged;

            radioOption1.CheckedChanged += RadioOption_CheckedChanged;
            radioOption2.CheckedChanged += RadioOption_CheckedChanged;
            radioOption3.CheckedChanged += RadioOption_CheckedChanged;

            executeButton.Click += ExecuteButton_Click;

            clearButton.Click += ClearButton_Click;

            SetTreeTypeFromRadio();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _facade.Clear();
        }

        private void RadioOption_CheckedChanged(object sender, EventArgs e)
        {
            SetTreeTypeFromRadio();
        }

        private void SetTreeTypeFromRadio()
        {
            TreeType type = radioOption1.Checked ? TreeType.BinarySearch :
                            radioOption2.Checked ? TreeType.Balanced : TreeType.Simple;
            _facade.SetTreeType(type);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _facade.BuildFromString(inputTextBox.Text);
                //inputTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnTreeChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
            UpdateInfoPanel();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            _facade?.Draw(e.Graphics, drawingPanel.ClientRectangle);
        }

        private void rightPanel_Paint(object sender, PaintEventArgs e)
        {
            // Опционально: кастомная отрисовка
        }

        private void UpdateInfoPanel()
        {
            var info = GetTreeInfo();
            nodesNumberText.Text = info["nodesNumber"];
            heightText.Text = info["height"];
            minText.Text = info["min"];
            maxText.Text = info["max"];
            inOrderText.Text = info["inOrder"];
            preOrderText.Text = info["preOrder"];
            postOrderText.Text = info["postOrder"];
            levelOrderText.Text = info["levelOrder"];
            leafMaximaText.Text = info["leafMaxima"];
        }

        private Dictionary<string, string> GetTreeInfo()
        {
            var info = new Dictionary<string, string>();
            string minStr, maxStr;

            try {
                var min = _facade.FindMin();
                var max = _facade.FindMax();

                minStr = min.HasValue ? min.Value.ToString() : "N/A";
                maxStr = max.HasValue ? max.Value.ToString() : "N/A";
            }catch(Exception e) {
                minStr = "(error)" + e.Message;
                maxStr = minStr;
            }

            info.Add("nodesNumber", _facade.Count.ToString());
            info.Add("height", _facade.GetHeight().ToString());
            info.Add("min", minStr);
            info.Add("max", maxStr);
            info.Add("inOrder", string.Join(", ", _facade.InOrder()));
            info.Add("preOrder", string.Join(", ", _facade.PreOrder()));
            info.Add("postOrder", string.Join(", ", _facade.PostOrder()));
            info.Add("levelOrder", string.Join(", ", _facade.LevelOrder()));
            info.Add("leafMaxima", string.Join(", ", _facade.CountLeafMaxima()));

            return info;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}