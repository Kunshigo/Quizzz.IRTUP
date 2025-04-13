namespace Quizzz.IRTUP.Panels
{
    partial class ViewQuizzes
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
            availableQuizzesPanel = new FlowLayoutPanel();
            completedQuizzesPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            difficultyFilterComboBox = new ComboBox();
            subjectFilterComboBox = new ComboBox();
            txtSearch = new TextBox();
            cmbSort = new Syncfusion.Windows.Forms.Tools.FontComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // availableQuizzesPanel
            // 
            availableQuizzesPanel.BackColor = Color.FromArgb(160, 220, 180);
            availableQuizzesPanel.Dock = DockStyle.Fill;
            availableQuizzesPanel.Location = new Point(0, 68);
            availableQuizzesPanel.Name = "availableQuizzesPanel";
            availableQuizzesPanel.Size = new Size(1028, 494);
            availableQuizzesPanel.TabIndex = 0;
            // 
            // completedQuizzesPanel
            // 
            completedQuizzesPanel.BackColor = Color.FromArgb(140, 170, 140);
            completedQuizzesPanel.Dock = DockStyle.Bottom;
            completedQuizzesPanel.Location = new Point(0, 321);
            completedQuizzesPanel.Name = "completedQuizzesPanel";
            completedQuizzesPanel.Size = new Size(1028, 241);
            completedQuizzesPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 121, 113);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(difficultyFilterComboBox);
            panel1.Controls.Add(subjectFilterComboBox);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cmbSort);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1028, 68);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(809, 21);
            label2.Name = "label2";
            label2.Size = new Size(60, 17);
            label2.TabIndex = 5;
            label2.Text = "Difficulty";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F);
            label1.Location = new Point(618, 21);
            label1.Name = "label1";
            label1.Size = new Size(54, 17);
            label1.TabIndex = 5;
            label1.Text = "Subject";
            // 
            // difficultyFilterComboBox
            // 
            difficultyFilterComboBox.FormattingEnabled = true;
            difficultyFilterComboBox.Location = new Point(809, 39);
            difficultyFilterComboBox.Name = "difficultyFilterComboBox";
            difficultyFilterComboBox.Size = new Size(185, 23);
            difficultyFilterComboBox.TabIndex = 4;
            // 
            // subjectFilterComboBox
            // 
            subjectFilterComboBox.FormattingEnabled = true;
            subjectFilterComboBox.Location = new Point(618, 39);
            subjectFilterComboBox.Name = "subjectFilterComboBox";
            subjectFilterComboBox.Size = new Size(185, 23);
            subjectFilterComboBox.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Right;
            txtSearch.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(1435, -5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 3;
            // 
            // cmbSort
            // 
            cmbSort.Anchor = AnchorStyles.Right;
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(1661, -6);
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
            // ViewQuizzes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(completedQuizzesPanel);
            Controls.Add(availableQuizzesPanel);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "ViewQuizzes";
            Size = new Size(1028, 562);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel availableQuizzesPanel;
        private FlowLayoutPanel completedQuizzesPanel;
        private Panel panel1;
        private TextBox txtSearch;
        private Syncfusion.Windows.Forms.Tools.FontComboBox cmbSort;
        private ComboBox subjectFilterComboBox;
        private Label label1;
        private Label label2;
        private ComboBox difficultyFilterComboBox;
    }
}
