namespace Quizzz.IRTUP
{
    partial class signupWindow
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
            panel1 = new Panel();
            controlBox = new Panel();
            minimizeBtn = new Button();
            closeBtn = new Button();
            signUpPanel = new FlowLayoutPanel();
            Header.SuspendLayout();
            controlBox.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.Black;
            Header.Controls.Add(panel1);
            Header.Controls.Add(controlBox);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(1109, 27);
            Header.TabIndex = 3;
            Header.MouseDown += OnMouseDown;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 27);
            panel1.TabIndex = 4;
            panel1.MouseDown += OnMouseDown;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(1062, 0);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(47, 27);
            controlBox.TabIndex = 4;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.Olive;
            minimizeBtn.BackgroundImage = Properties.Resources.minimize;
            minimizeBtn.BackgroundImageLayout = ImageLayout.Stretch;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Location = new Point(4, 4);
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
            closeBtn.Location = new Point(24, 4);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(19, 19);
            closeBtn.TabIndex = 0;
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // signUpPanel
            // 
            signUpPanel.AutoSize = true;
            signUpPanel.Dock = DockStyle.Fill;
            signUpPanel.Location = new Point(0, 27);
            signUpPanel.Name = "signUpPanel";
            signUpPanel.Size = new Size(1109, 551);
            signUpPanel.TabIndex = 4;
            // 
            // signupWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 229, 233);
            ClientSize = new Size(1109, 578);
            ControlBox = false;
            Controls.Add(signUpPanel);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "signupWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Header.ResumeLayout(false);
            controlBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel Header;
        private Panel controlBox;
        private Button minimizeBtn;
        private Button closeBtn;
        private Panel panel1;
        private FlowLayoutPanel signUpPanel;
    }
}