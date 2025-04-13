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
            Header = new Panel();
            controlBox = new Panel();
            maximizeBtn = new Button();
            minimizeBtn = new Button();
            closeBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Header.SuspendLayout();
            controlBox.SuspendLayout();
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
            controlBox.Controls.Add(maximizeBtn);
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(1100, 0);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(85, 27);
            controlBox.TabIndex = 4;
            // 
            // maximizeBtn
            // 
            maximizeBtn.BackColor = Color.LightGreen;
            maximizeBtn.BackgroundImage = Properties.Resources.maximize;
            maximizeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            maximizeBtn.FlatAppearance.BorderSize = 0;
            maximizeBtn.FlatStyle = FlatStyle.Flat;
            maximizeBtn.Location = new Point(38, 3);
            maximizeBtn.Name = "maximizeBtn";
            maximizeBtn.Size = new Size(19, 19);
            maximizeBtn.TabIndex = 1;
            maximizeBtn.UseVisualStyleBackColor = false;
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
            closeBtn.Location = new Point(63, 3);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(19, 19);
            closeBtn.TabIndex = 0;
            closeBtn.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 27);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1185, 564);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // TakeQuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 591);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TakeQuizForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TakeQuizForm";
            Header.ResumeLayout(false);
            controlBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel controlBox;
        private Button maximizeBtn;
        private Button minimizeBtn;
        private Button closeBtn;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}