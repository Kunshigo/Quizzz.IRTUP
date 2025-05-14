namespace Quizzz.IRTUP.Panels
{
    partial class manageQuizMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new AntdUI.Label();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            gradeLevelFilterComboBox = new ComboBox();
            difficultyFilterComboBox = new ComboBox();
            txtSearch = new TextBox();
            quizzesPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            btnAddQuiz = new AntdUI.Button();
            delQuizBtn = new AntdUI.Button();
            panel1.SuspendLayout();
            quizzesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 17);
            label1.Name = "label1";
            label1.Size = new Size(138, 23);
            label1.TabIndex = 0;
            label1.Text = "Your Quizzes";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(3, 121, 113);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(gradeLevelFilterComboBox);
            panel1.Controls.Add(difficultyFilterComboBox);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 50);
            panel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(890, 3);
            label3.Name = "label3";
            label3.Size = new Size(79, 16);
            label3.TabIndex = 7;
            label3.Text = "Grade Level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label2.Location = new Point(722, 3);
            label2.Name = "label2";
            label2.Size = new Size(55, 16);
            label2.TabIndex = 7;
            label2.Text = "Difficulty";
            // 
            // gradeLevelFilterComboBox
            // 
            gradeLevelFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeLevelFilterComboBox.Font = new Font("Century Gothic", 9F);
            gradeLevelFilterComboBox.FormattingEnabled = true;
            gradeLevelFilterComboBox.Items.AddRange(new object[] { "All Grades", "1", "2", "3", "4", "5", "6" });
            gradeLevelFilterComboBox.Location = new Point(843, 22);
            gradeLevelFilterComboBox.Name = "gradeLevelFilterComboBox";
            gradeLevelFilterComboBox.Size = new Size(185, 25);
            gradeLevelFilterComboBox.TabIndex = 6;
            // 
            // difficultyFilterComboBox
            // 
            difficultyFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            difficultyFilterComboBox.Font = new Font("Century Gothic", 9F);
            difficultyFilterComboBox.FormattingEnabled = true;
            difficultyFilterComboBox.Items.AddRange(new object[] { "All Difficulties", "Easy", "Medium", "Hard" });
            difficultyFilterComboBox.Location = new Point(652, 22);
            difficultyFilterComboBox.Name = "difficultyFilterComboBox";
            difficultyFilterComboBox.Size = new Size(185, 25);
            difficultyFilterComboBox.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Right;
            txtSearch.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(465, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search...";
            txtSearch.Size = new Size(181, 23);
            txtSearch.TabIndex = 3;
            // 
            // quizzesPanel
            // 
            quizzesPanel.AutoScroll = true;
            quizzesPanel.BackColor = Color.FromArgb(160, 220, 180);
            quizzesPanel.BorderStyle = BorderStyle.FixedSingle;
            quizzesPanel.Controls.Add(panel2);
            quizzesPanel.Dock = DockStyle.Top;
            quizzesPanel.Location = new Point(0, 50);
            quizzesPanel.Name = "quizzesPanel";
            quizzesPanel.Size = new Size(1047, 494);
            quizzesPanel.TabIndex = 4;
            quizzesPanel.WrapContents = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 192);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(13, 13);
            panel2.Margin = new Padding(13);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(180, 180);
            panel2.TabIndex = 1;
            // 
            // btnAddQuiz
            // 
            btnAddQuiz.Cursor = Cursors.Hand;
            btnAddQuiz.DefaultBack = Color.AntiqueWhite;
            btnAddQuiz.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddQuiz.Location = new Point(14, 543);
            btnAddQuiz.Name = "btnAddQuiz";
            btnAddQuiz.Size = new Size(250, 42);
            btnAddQuiz.TabIndex = 0;
            btnAddQuiz.Text = "Create Quiz";
            btnAddQuiz.Click += btnAddQuiz_Click;
            // 
            // delQuizBtn
            // 
            delQuizBtn.Cursor = Cursors.Hand;
            delQuizBtn.DefaultBack = Color.PaleVioletRed;
            delQuizBtn.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delQuizBtn.Location = new Point(763, 543);
            delQuizBtn.Name = "delQuizBtn";
            delQuizBtn.Size = new Size(250, 42);
            delQuizBtn.TabIndex = 0;
            delQuizBtn.Text = "Delete Quiz";
            delQuizBtn.Click += deleteQuizBtn_Click;
            // 
            // manageQuizMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(160, 220, 180);
            Controls.Add(delQuizBtn);
            Controls.Add(btnAddQuiz);
            Controls.Add(quizzesPanel);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "manageQuizMenu";
            Size = new Size(1047, 604);
            Load += manageQuizMenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            quizzesPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Label label1;
        private Panel panel1;
        private FlowLayoutPanel quizzesPanel;
        private TextBox txtSearch;
        private AntdUI.Button btnAddQuiz;
        private Panel panel2;
        private AntdUI.Button delQuizBtn;
        private Label label2;
        private ComboBox difficultyFilterComboBox;
        private Label label3;
        private ComboBox gradeLevelFilterComboBox;
    }
}
