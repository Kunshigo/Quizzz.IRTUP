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
            cmbSort = new Syncfusion.Windows.Forms.Tools.FontComboBox();
            panel1 = new Panel();
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
            // cmbSort
            // 
            cmbSort.Anchor = AnchorStyles.Right;
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(833, 10);
            cmbSort.Name = "cmbSort";
            cmbSort.ShowSymbolFontPreview = false;
            cmbSort.Size = new Size(200, 24);
            cmbSort.TabIndex = 2;
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonBackColor = Color.FromArgb(255, 255, 255);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonBorderColor = Color.FromArgb(225, 225, 225);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonDisabledBackColor = Color.FromArgb(225, 225, 225);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonDisabledBorderColor = Color.FromArgb(210, 210, 210);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonHoverBackColor = Color.FromArgb(114, 114, 114);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonHoverBorderColor = Color.FromArgb(94, 94, 94);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonPressedBackColor = Color.FromArgb(225, 225, 225);
            cmbSort.ThemeStyle.ScrollBarStyle.ArrowButtonPressedBorderColor = Color.FromArgb(150, 150, 150);
            cmbSort.ThemeStyle.ScrollBarStyle.ScrollBarBackColor = Color.FromArgb(225, 225, 225);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbBorderColor = Color.FromArgb(171, 171, 171);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbColor = Color.FromArgb(255, 255, 255);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbDisabledBorderColor = Color.FromArgb(210, 210, 210);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbDisabledColor = Color.FromArgb(225, 225, 225);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbHoverBorderColor = Color.FromArgb(171, 171, 171);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbHoverColor = Color.FromArgb(197, 197, 197);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbPressedBorderColor = Color.FromArgb(150, 150, 150);
            cmbSort.ThemeStyle.ScrollBarStyle.ThumbPressedColor = Color.FromArgb(197, 197, 197);
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(3, 121, 113);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbSort);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 43);
            panel1.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Right;
            txtSearch.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(607, 11);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 3;
            // 
            // quizzesPanel
            // 
            quizzesPanel.AutoScroll = true;
            quizzesPanel.BackColor = Color.FromArgb(160, 220, 180);
            quizzesPanel.BorderStyle = BorderStyle.FixedSingle;
            quizzesPanel.Controls.Add(panel2);
            quizzesPanel.Dock = DockStyle.Top;
            quizzesPanel.Location = new Point(0, 43);
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
        private Syncfusion.Windows.Forms.Tools.FontComboBox cmbSort;
        private Panel panel1;
        private FlowLayoutPanel quizzesPanel;
        private TextBox txtSearch;
        private AntdUI.Button btnAddQuiz;
        private Panel panel2;
        private AntdUI.Button delQuizBtn;
    }
}
