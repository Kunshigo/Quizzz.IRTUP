namespace Quizzz.IRTUP
{
    partial class registerMenu
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
            registerPanel = new Panel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            loginBtn = new LinkLabel();
            label4 = new Label();
            teacherBtn = new Button();
            studentBtn = new Button();
            registerPanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // registerPanel
            // 
            registerPanel.Controls.Add(panel2);
            registerPanel.Controls.Add(panel1);
            registerPanel.Controls.Add(loginBtn);
            registerPanel.Controls.Add(label4);
            registerPanel.Controls.Add(teacherBtn);
            registerPanel.Controls.Add(studentBtn);
            registerPanel.Dock = DockStyle.Fill;
            registerPanel.Location = new Point(0, 0);
            registerPanel.Name = "registerPanel";
            registerPanel.Size = new Size(1109, 533);
            registerPanel.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(215, 232, 186);
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(577, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 240);
            panel2.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.student;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.student;
            pictureBox2.Location = new Point(77, 61);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(77, 161, 169);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(283, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 240);
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.teacher;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.teacher;
            pictureBox1.Location = new Point(76, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // loginBtn
            // 
            loginBtn.AutoSize = true;
            loginBtn.Font = new Font("Century Gothic", 15.75F);
            loginBtn.LinkColor = SystemColors.HotTrack;
            loginBtn.Location = new Point(654, 480);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(64, 24);
            loginBtn.TabIndex = 5;
            loginBtn.TabStop = true;
            loginBtn.Text = "Login";
            loginBtn.LinkClicked += loginBtn_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(359, 480);
            label4.Name = "label4";
            label4.Size = new Size(289, 24);
            label4.TabIndex = 4;
            label4.Text = "Already have an account?";
            // 
            // teacherBtn
            // 
            teacherBtn.BackColor = Color.White;
            teacherBtn.FlatAppearance.BorderSize = 0;
            teacherBtn.FlatStyle = FlatStyle.Flat;
            teacherBtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            teacherBtn.ForeColor = SystemColors.ActiveCaptionText;
            teacherBtn.Location = new Point(283, 88);
            teacherBtn.Name = "teacherBtn";
            teacherBtn.Size = new Size(251, 289);
            teacherBtn.TabIndex = 6;
            teacherBtn.Text = "Teacher";
            teacherBtn.TextAlign = ContentAlignment.BottomCenter;
            teacherBtn.UseVisualStyleBackColor = false;
            teacherBtn.Click += teacherBtn_Click;
            teacherBtn.MouseEnter += teacherBtn_MouseEnter;
            teacherBtn.MouseLeave += teacherBtn_MouseLeave;
            // 
            // studentBtn
            // 
            studentBtn.BackColor = Color.White;
            studentBtn.FlatAppearance.BorderSize = 0;
            studentBtn.FlatStyle = FlatStyle.Flat;
            studentBtn.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            studentBtn.Location = new Point(577, 88);
            studentBtn.Name = "studentBtn";
            studentBtn.Size = new Size(251, 289);
            studentBtn.TabIndex = 6;
            studentBtn.Text = "Student";
            studentBtn.TextAlign = ContentAlignment.BottomCenter;
            studentBtn.UseVisualStyleBackColor = false;
            studentBtn.MouseEnter += studentBtn_MouseEnter;
            studentBtn.MouseLeave += studentBtn_MouseLeave;
            // 
            // registerMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(registerPanel);
            Name = "registerMenu";
            Size = new Size(1109, 533);
            registerPanel.ResumeLayout(false);
            registerPanel.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel registerPanel;
        private LinkLabel loginBtn;
        private Label label4;
        private Button teacherBtn;
        private Button studentBtn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
    }
}
