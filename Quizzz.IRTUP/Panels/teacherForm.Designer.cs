namespace Quizzz.IRTUP
{
    partial class teacherForm
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
            teacherSignUpPanel = new Panel();
            backBtn = new Button();
            radioButton1 = new RadioButton();
            radioButtonAdv1 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            usernameTxtBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            teacherSignUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioButtonAdv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usernameTxtBox).BeginInit();
            SuspendLayout();
            // 
            // teacherSignUpPanel
            // 
            teacherSignUpPanel.BackgroundImageLayout = ImageLayout.Stretch;
            teacherSignUpPanel.Controls.Add(backBtn);
            teacherSignUpPanel.Controls.Add(radioButton1);
            teacherSignUpPanel.Controls.Add(radioButtonAdv1);
            teacherSignUpPanel.Controls.Add(autoLabel3);
            teacherSignUpPanel.Controls.Add(autoLabel2);
            teacherSignUpPanel.Controls.Add(autoLabel1);
            teacherSignUpPanel.Controls.Add(textBoxExt1);
            teacherSignUpPanel.Controls.Add(usernameTxtBox);
            teacherSignUpPanel.Dock = DockStyle.Fill;
            teacherSignUpPanel.Location = new Point(0, 0);
            teacherSignUpPanel.Name = "teacherSignUpPanel";
            teacherSignUpPanel.Size = new Size(1109, 533);
            teacherSignUpPanel.TabIndex = 8;
            // 
            // backBtn
            // 
            backBtn.BackgroundImage = Properties.Resources.back_1;
            backBtn.BackgroundImageLayout = ImageLayout.Zoom;
            backBtn.Cursor = Cursors.Hand;
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.Location = new Point(9, 15);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(30, 30);
            backBtn.TabIndex = 4;
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(410, 197);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(117, 21);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Show Password";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdv1
            // 
            radioButtonAdv1.AccessibilityEnabled = true;
            radioButtonAdv1.BeforeTouchSize = new Size(0, 0);
            radioButtonAdv1.Location = new Point(410, 197);
            radioButtonAdv1.MetroColor = Color.FromArgb(88, 89, 91);
            radioButtonAdv1.Name = "radioButtonAdv1";
            radioButtonAdv1.Size = new Size(0, 0);
            radioButtonAdv1.TabIndex = 2;
            radioButtonAdv1.Text = "radioButtonAdv1";
            // 
            // autoLabel3
            // 
            autoLabel3.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel3.Location = new Point(410, 141);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(79, 20);
            autoLabel3.TabIndex = 1;
            autoLabel3.Text = "Password";
            // 
            // autoLabel2
            // 
            autoLabel2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel2.Location = new Point(410, 63);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(83, 20);
            autoLabel2.TabIndex = 1;
            autoLabel2.Text = "Username";
            // 
            // autoLabel1
            // 
            autoLabel1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            autoLabel1.Location = new Point(453, 26);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(175, 19);
            autoLabel1.TabIndex = 1;
            autoLabel1.Text = "CREATE AN ACCOUNT";
            // 
            // textBoxExt1
            // 
            textBoxExt1.BeforeTouchSize = new Size(276, 27);
            textBoxExt1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxExt1.Location = new Point(410, 164);
            textBoxExt1.Name = "textBoxExt1";
            textBoxExt1.Size = new Size(276, 27);
            textBoxExt1.TabIndex = 0;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.BeforeTouchSize = new Size(276, 27);
            usernameTxtBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTxtBox.Location = new Point(410, 85);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(276, 27);
            usernameTxtBox.TabIndex = 0;
            // 
            // teacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(teacherSignUpPanel);
            Name = "teacherForm";
            Size = new Size(1109, 533);
            teacherSignUpPanel.ResumeLayout(false);
            teacherSignUpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radioButtonAdv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)usernameTxtBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel teacherSignUpPanel;
        private Button backBtn;
        private RadioButton radioButton1;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv radioButtonAdv1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt usernameTxtBox;
    }
}
