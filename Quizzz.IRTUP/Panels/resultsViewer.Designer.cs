namespace Quizzz.IRTUP.Panels
{
    partial class resultsViewer
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
            panel1 = new Panel();
            txtSearch = new TextBox();
            cmbSort = new ComboBox();
            cmbStatus = new ComboBox();
            nextBtn = new Button();
            answersPanel = new FlowLayoutPanel();
            resultsPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            label1 = new Label();
            button1 = new Button();
            panel3 = new Panel();
            label2 = new Label();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 170, 160);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(cmbSort);
            panel1.Controls.Add(cmbStatus);
            panel1.Controls.Add(nextBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1044, 46);
            panel1.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Century Gothic", 9F);
            txtSearch.Location = new Point(571, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(144, 22);
            txtSearch.TabIndex = 2;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Font = new Font("Century Gothic", 9F);
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Title A-Z", "Title Z-A", "Newest First", "Oldest First" });
            cmbSort.Location = new Point(888, 12);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(144, 25);
            cmbSort.TabIndex = 1;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Century Gothic", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Needs Grading", "Graded" });
            cmbStatus.Location = new Point(730, 12);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(144, 25);
            cmbStatus.TabIndex = 1;
            // 
            // nextBtn
            // 
            nextBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nextBtn.Location = new Point(1099, 7);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 29);
            nextBtn.TabIndex = 0;
            nextBtn.Text = "Next";
            nextBtn.UseVisualStyleBackColor = true;
            // 
            // answersPanel
            // 
            answersPanel.AutoScroll = true;
            answersPanel.BackColor = Color.DarkSeaGreen;
            answersPanel.Dock = DockStyle.Top;
            answersPanel.Location = new Point(0, 78);
            answersPanel.Name = "answersPanel";
            answersPanel.Size = new Size(1044, 242);
            answersPanel.TabIndex = 8;
            // 
            // resultsPanel
            // 
            resultsPanel.BackColor = Color.MediumSeaGreen;
            resultsPanel.Dock = DockStyle.Fill;
            resultsPanel.Location = new Point(0, 352);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Size = new Size(1044, 249);
            resultsPanel.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(1044, 32);
            panel2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(151, 21);
            label1.TabIndex = 1;
            label1.Text = "Ungraded Quizzes";
            // 
            // button1
            // 
            button1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1099, 7);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 0;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SeaGreen;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(button2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 320);
            panel3.Name = "panel3";
            panel3.Size = new Size(1044, 32);
            panel3.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(133, 21);
            label2.TabIndex = 1;
            label2.Text = "Graded Quizzes";
            // 
            // button2
            // 
            button2.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1099, 7);
            button2.Name = "button2";
            button2.Size = new Size(75, 29);
            button2.TabIndex = 0;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = true;
            // 
            // resultsViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resultsPanel);
            Controls.Add(panel3);
            Controls.Add(answersPanel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "resultsViewer";
            Size = new Size(1044, 601);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button nextBtn;
        private ComboBox cmbStatus;
        private TextBox txtSearch;
        private ComboBox cmbSort;
        private FlowLayoutPanel answersPanel;
        private FlowLayoutPanel resultsPanel;
        private Panel panel2;
        private Label label1;
        private Button button1;
        private Panel panel3;
        private Button button2;
        private Label label2;
    }
}
