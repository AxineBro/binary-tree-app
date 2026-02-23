namespace BinaryTreeApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            rightPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            nodesNumberText = new TextBox();
            nodesNumberLabel = new Label();
            panel2 = new Panel();
            heightText = new TextBox();
            heightLabel = new Label();
            panel3 = new Panel();
            minText = new TextBox();
            minLabel = new Label();
            panel4 = new Panel();
            maxText = new TextBox();
            maxLabel = new Label();
            panel5 = new Panel();
            inOrderText = new TextBox();
            inOrderLabel = new Label();
            panel6 = new Panel();
            preOrderText = new TextBox();
            preOrderLabel = new Label();
            panel7 = new Panel();
            postOrderText = new TextBox();
            postOrderLabel = new Label();
            panel8 = new Panel();
            levelOrderText = new TextBox();
            levelOrderLabel = new Label();
            panel9 = new Panel();
            leafMaximaText = new TextBox();
            leafMaximaLabel = new Label();
            panel10 = new Panel();
            drawingPanel = new Panel();
            groupBox1 = new GroupBox();
            tableLayoutPanel = new TableLayoutPanel();
            radioOption1 = new RadioButton();
            radioOption2 = new RadioButton();
            radioOption3 = new RadioButton();
            inputPanel = new Panel();
            executeButton = new Button();
            clearButton = new Button();
            inputTextBox = new TextBox();
            mainPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Menu;
            mainPanel.Controls.Add(rightPanel);
            mainPanel.Controls.Add(drawingPanel);
            mainPanel.Controls.Add(groupBox1);
            mainPanel.Controls.Add(inputPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(884, 641);
            mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(tableLayoutPanel1);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(684, 92);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(200, 549);
            rightPanel.TabIndex = 3;
            rightPanel.Paint += rightPanel_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel4, 0, 3);
            tableLayoutPanel1.Controls.Add(panel5, 0, 4);
            tableLayoutPanel1.Controls.Add(panel6, 0, 5);
            tableLayoutPanel1.Controls.Add(panel7, 0, 6);
            tableLayoutPanel1.Controls.Add(panel8, 0, 7);
            tableLayoutPanel1.Controls.Add(panel9, 0, 8);
            tableLayoutPanel1.Controls.Add(panel10, 0, 9);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(200, 549);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(nodesNumberText);
            panel1.Controls.Add(nodesNumberLabel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(194, 48);
            panel1.TabIndex = 0;
            // 
            // nodesNumberText
            // 
            nodesNumberText.Location = new Point(5, 26);
            nodesNumberText.Name = "nodesNumberText";
            nodesNumberText.Size = new Size(180, 23);
            nodesNumberText.TabIndex = 1;
            // 
            // nodesNumberLabel
            // 
            nodesNumberLabel.AutoSize = true;
            nodesNumberLabel.Location = new Point(5, 4);
            nodesNumberLabel.Name = "nodesNumberLabel";
            nodesNumberLabel.Size = new Size(109, 15);
            nodesNumberLabel.TabIndex = 0;
            nodesNumberLabel.Text = "Количество узлов:";
            // 
            // panel2
            // 
            panel2.Controls.Add(heightText);
            panel2.Controls.Add(heightLabel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(194, 48);
            panel2.TabIndex = 1;
            // 
            // heightText
            // 
            heightText.Location = new Point(7, 26);
            heightText.Name = "heightText";
            heightText.Size = new Size(180, 23);
            heightText.TabIndex = 3;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(7, 4);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(50, 15);
            heightLabel.TabIndex = 2;
            heightLabel.Text = "Высота:";
            // 
            // panel3
            // 
            panel3.Controls.Add(minText);
            panel3.Controls.Add(minLabel);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 111);
            panel3.Name = "panel3";
            panel3.Size = new Size(194, 48);
            panel3.TabIndex = 2;
            // 
            // minText
            // 
            minText.Location = new Point(7, 26);
            minText.Name = "minText";
            minText.Size = new Size(180, 23);
            minText.TabIndex = 3;
            // 
            // minLabel
            // 
            minLabel.AutoSize = true;
            minLabel.Location = new Point(7, 4);
            minLabel.Name = "minLabel";
            minLabel.Size = new Size(35, 15);
            minLabel.TabIndex = 2;
            minLabel.Text = "Мин:";
            // 
            // panel4
            // 
            panel4.Controls.Add(maxText);
            panel4.Controls.Add(maxLabel);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 165);
            panel4.Name = "panel4";
            panel4.Size = new Size(194, 48);
            panel4.TabIndex = 3;
            // 
            // maxText
            // 
            maxText.Location = new Point(7, 26);
            maxText.Name = "maxText";
            maxText.Size = new Size(180, 23);
            maxText.TabIndex = 3;
            // 
            // maxLabel
            // 
            maxLabel.AutoSize = true;
            maxLabel.Location = new Point(7, 4);
            maxLabel.Name = "maxLabel";
            maxLabel.Size = new Size(39, 15);
            maxLabel.TabIndex = 2;
            maxLabel.Text = "Макс:";
            // 
            // panel5
            // 
            panel5.Controls.Add(inOrderText);
            panel5.Controls.Add(inOrderLabel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 219);
            panel5.Name = "panel5";
            panel5.Size = new Size(194, 48);
            panel5.TabIndex = 4;
            // 
            // inOrderText
            // 
            inOrderText.Location = new Point(7, 26);
            inOrderText.Name = "inOrderText";
            inOrderText.Size = new Size(180, 23);
            inOrderText.TabIndex = 3;
            // 
            // inOrderLabel
            // 
            inOrderLabel.AutoSize = true;
            inOrderLabel.Location = new Point(7, 4);
            inOrderLabel.Name = "inOrderLabel";
            inOrderLabel.Size = new Size(50, 15);
            inOrderLabel.TabIndex = 2;
            inOrderLabel.Text = "InOrder:";
            // 
            // panel6
            // 
            panel6.Controls.Add(preOrderText);
            panel6.Controls.Add(preOrderLabel);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 273);
            panel6.Name = "panel6";
            panel6.Size = new Size(194, 48);
            panel6.TabIndex = 5;
            // 
            // preOrderText
            // 
            preOrderText.Location = new Point(7, 26);
            preOrderText.Name = "preOrderText";
            preOrderText.Size = new Size(180, 23);
            preOrderText.TabIndex = 3;
            // 
            // preOrderLabel
            // 
            preOrderLabel.AutoSize = true;
            preOrderLabel.Location = new Point(7, 4);
            preOrderLabel.Name = "preOrderLabel";
            preOrderLabel.Size = new Size(57, 15);
            preOrderLabel.TabIndex = 2;
            preOrderLabel.Text = "PreOrder:";
            // 
            // panel7
            // 
            panel7.Controls.Add(postOrderText);
            panel7.Controls.Add(postOrderLabel);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 327);
            panel7.Name = "panel7";
            panel7.Size = new Size(194, 48);
            panel7.TabIndex = 6;
            // 
            // postOrderText
            // 
            postOrderText.Location = new Point(7, 26);
            postOrderText.Name = "postOrderText";
            postOrderText.Size = new Size(180, 23);
            postOrderText.TabIndex = 3;
            // 
            // postOrderLabel
            // 
            postOrderLabel.AutoSize = true;
            postOrderLabel.Location = new Point(7, 4);
            postOrderLabel.Name = "postOrderLabel";
            postOrderLabel.Size = new Size(63, 15);
            postOrderLabel.TabIndex = 2;
            postOrderLabel.Text = "PostOrder:";
            // 
            // panel8
            // 
            panel8.Controls.Add(levelOrderText);
            panel8.Controls.Add(levelOrderLabel);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 381);
            panel8.Name = "panel8";
            panel8.Size = new Size(194, 48);
            panel8.TabIndex = 7;
            // 
            // levelOrderText
            // 
            levelOrderText.Location = new Point(7, 28);
            levelOrderText.Name = "levelOrderText";
            levelOrderText.Size = new Size(180, 23);
            levelOrderText.TabIndex = 3;
            // 
            // levelOrderLabel
            // 
            levelOrderLabel.AutoSize = true;
            levelOrderLabel.Location = new Point(7, 6);
            levelOrderLabel.Name = "levelOrderLabel";
            levelOrderLabel.Size = new Size(67, 15);
            levelOrderLabel.TabIndex = 2;
            levelOrderLabel.Text = "LevelOrder:";
            // 
            // panel9
            // 
            panel9.Controls.Add(leafMaximaText);
            panel9.Controls.Add(leafMaximaLabel);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 435);
            panel9.Name = "panel9";
            panel9.Size = new Size(194, 48);
            panel9.TabIndex = 8;
            // 
            // leafMaximaText
            // 
            leafMaximaText.Location = new Point(7, 24);
            leafMaximaText.Name = "leafMaximaText";
            leafMaximaText.Size = new Size(180, 23);
            leafMaximaText.TabIndex = 5;
            // 
            // leafMaximaLabel
            // 
            leafMaximaLabel.AutoSize = true;
            leafMaximaLabel.Location = new Point(7, 2);
            leafMaximaLabel.Name = "leafMaximaLabel";
            leafMaximaLabel.Size = new Size(162, 15);
            leafMaximaLabel.TabIndex = 4;
            leafMaximaLabel.Text = "Количество макс. в листьях:";
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 489);
            panel10.Name = "panel10";
            panel10.Size = new Size(194, 57);
            panel10.TabIndex = 9;
            // 
            // drawingPanel
            // 
            drawingPanel.BackColor = Color.White;
            drawingPanel.BorderStyle = BorderStyle.FixedSingle;
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(0, 92);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(884, 549);
            drawingPanel.TabIndex = 2;
            drawingPanel.Paint += drawingPanel_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(884, 46);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тип дерева";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.Controls.Add(radioOption1, 0, 0);
            tableLayoutPanel.Controls.Add(radioOption2, 1, 0);
            tableLayoutPanel.Controls.Add(radioOption3, 2, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(3, 19);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(878, 24);
            tableLayoutPanel.TabIndex = 0;
            // 
            // radioOption1
            // 
            radioOption1.AutoSize = true;
            radioOption1.Checked = true;
            radioOption1.Dock = DockStyle.Fill;
            radioOption1.Location = new Point(3, 3);
            radioOption1.Name = "radioOption1";
            radioOption1.Size = new Size(286, 18);
            radioOption1.TabIndex = 0;
            radioOption1.TabStop = true;
            radioOption1.Text = "Бинарное дерево поиска";
            radioOption1.UseVisualStyleBackColor = true;
            // 
            // radioOption2
            // 
            radioOption2.AutoSize = true;
            radioOption2.Dock = DockStyle.Fill;
            radioOption2.Location = new Point(295, 3);
            radioOption2.Name = "radioOption2";
            radioOption2.Size = new Size(286, 18);
            radioOption2.TabIndex = 1;
            radioOption2.Text = "Сбалансированное дерево";
            radioOption2.UseVisualStyleBackColor = true;
            // 
            // radioOption3
            // 
            radioOption3.AutoSize = true;
            radioOption3.Dock = DockStyle.Fill;
            radioOption3.Location = new Point(587, 3);
            radioOption3.Name = "radioOption3";
            radioOption3.Size = new Size(288, 18);
            radioOption3.TabIndex = 2;
            radioOption3.Text = "Обычное дерево";
            radioOption3.UseVisualStyleBackColor = true;
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(executeButton);
            inputPanel.Controls.Add(clearButton);
            inputPanel.Controls.Add(inputTextBox);
            inputPanel.Dock = DockStyle.Top;
            inputPanel.Location = new Point(0, 0);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(884, 46);
            inputPanel.TabIndex = 0;
            // 
            // executeButton
            // 
            executeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            executeButton.Location = new Point(668, 11);
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(99, 23);
            executeButton.TabIndex = 2;
            executeButton.Text = "Выполнить";
            executeButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearButton.Location = new Point(773, 12);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(99, 23);
            clearButton.TabIndex = 1;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // inputTextBox
            // 
            inputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputTextBox.Location = new Point(12, 12);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(650, 23);
            inputTextBox.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 641);
            Controls.Add(mainPanel);
            MinimumSize = new Size(600, 640);
            Name = "MainForm";
            Text = "Binary Tree";
            mainPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel inputPanel;
        private Button clearButton;
        private TextBox inputTextBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel;
        private Panel drawingPanel;
        private RadioButton radioOption1;
        private RadioButton radioOption2;
        private RadioButton radioOption3;
        private Panel rightPanel;
        private Button executeButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private TextBox nodesNumberText;
        private Label nodesNumberLabel;
        private TextBox heightText;
        private Label heightLabel;
        private TextBox minText;
        private Label minLabel;
        private TextBox maxText;
        private Label maxLabel;
        private TextBox inOrderText;
        private Label inOrderLabel;
        private TextBox preOrderText;
        private Label preOrderLabel;
        private TextBox postOrderText;
        private Label postOrderLabel;
        private TextBox levelOrderText;
        private Label levelOrderLabel;
        private Panel panel9;
        private Panel panel10;
        private TextBox leafMaximaText;
        private Label leafMaximaLabel;
    }
}
