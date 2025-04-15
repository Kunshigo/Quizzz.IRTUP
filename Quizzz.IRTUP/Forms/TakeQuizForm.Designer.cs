namespace Quizzz.IRTUP.Forms
{
    partial class TakeQuizForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Header = new Panel();
            controlBox = new Panel();
            minimizeBtn = new Button();
            closeBtn = new Button();
            quizTakingPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            lblQuestionCount = new Label();
            lblTimer = new Label();
            answerDelayTimer = new System.Windows.Forms.Timer(components);
            Header.SuspendLayout();
            controlBox.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.Black;
            Header.Controls.Add(controlBox);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(1185, 27);
            Header.TabIndex = 4;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(1118, 0);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(67, 27);
            controlBox.TabIndex = 4;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.Orange;
            minimizeBtn.BackgroundImage = Properties.Resources.minimize;
            minimizeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Location = new Point(13, 3);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(19, 19);
            minimizeBtn.TabIndex = 1;
            minimizeBtn.UseVisualStyleBackColor = false;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.FromArgb(255, 128, 128);
            closeBtn.BackgroundImage = Properties.Resources.close;
            closeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Location = new Point(38, 2);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(19, 19);
            closeBtn.TabIndex = 0;
            closeBtn.UseVisualStyleBackColor = false;
            // 
            // quizTakingPanel
            // 
            quizTakingPanel.Dock = DockStyle.Fill;
            quizTakingPanel.Location = new Point(0, 73);
            quizTakingPanel.Margin = new Padding(0);
            quizTakingPanel.Name = "quizTakingPanel";
            quizTakingPanel.Size = new Size(1185, 544);
            quizTakingPanel.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 170, 160);
            panel1.Controls.Add(lblQuestionCount);
            panel1.Controls.Add(lblTimer);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1185, 46);
            panel1.TabIndex = 6;
            // 
            // lblQuestionCount
            // 
            lblQuestionCount.AutoSize = true;
            lblQuestionCount.Location = new Point(557, 15);
            lblQuestionCount.Name = "lblQuestionCount";
            lblQuestionCount.Size = new Size(38, 15);
            lblQuestionCount.TabIndex = 1;
            lblQuestionCount.Text = "label1";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(12, 15);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(38, 15);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "label1";
            // 
            // answerDelayTimer
            // 
            answerDelayTimer.Interval = 1500;
            // 
            // TakeQuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 617);
            Controls.Add(quizTakingPanel);
            Controls.Add(panel1);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TakeQuizForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TakeQuizForm";
            Header.ResumeLayout(false);
            controlBox.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel controlBox;
        private Button minimizeBtn;
        private Button closeBtn;
        private FlowLayoutPanel quizTakingPanel;
        private Panel panel1;
        private Label lblTimer;
        private Label lblQuestionCount;
        private System.Windows.Forms.Timer answerDelayTimer;
    }
}