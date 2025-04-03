namespace Quizzz.IRTUP
{
    partial class teacherPanel
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
            panel1 = new Panel();
            showPasswordCheckBox = new CheckBox();
            registerBtn = new AntdUI.Button();
            label2 = new Label();
            label1 = new Label();
            gradeLvlComboBox = new ComboBox();
            subjectComboBox = new ComboBox();
            radioButtonAdv1 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            passwordTxtBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            cPassTxtBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            emailTxtBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            usernameTxtBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            backBtn = new Button();
            teacherSignUpPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioButtonAdv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cPassTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emailTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usernameTxtBox).BeginInit();
            SuspendLayout();
            // 
            // teacherSignUpPanel
            // 
            teacherSignUpPanel.BackgroundImageLayout = ImageLayout.Stretch;
            teacherSignUpPanel.Controls.Add(panel1);
            teacherSignUpPanel.Controls.Add(backBtn);
            teacherSignUpPanel.Dock = DockStyle.Fill;
            teacherSignUpPanel.Location = new Point(0, 0);
            teacherSignUpPanel.Margin = new Padding(0);
            teacherSignUpPanel.Name = "teacherSignUpPanel";
            teacherSignUpPanel.Size = new Size(1109, 551);
            teacherSignUpPanel.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 240, 210);
            panel1.Controls.Add(showPasswordCheckBox);
            panel1.Controls.Add(registerBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(gradeLvlComboBox);
            panel1.Controls.Add(subjectComboBox);
            panel1.Controls.Add(radioButtonAdv1);
            panel1.Controls.Add(autoLabel5);
            panel1.Controls.Add(autoLabel3);
            panel1.Controls.Add(autoLabel4);
            panel1.Controls.Add(autoLabel2);
            panel1.Controls.Add(autoLabel1);
            panel1.Controls.Add(passwordTxtBox);
            panel1.Controls.Add(cPassTxtBox);
            panel1.Controls.Add(emailTxtBox);
            panel1.Controls.Add(usernameTxtBox);
            panel1.Location = new Point(331, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 551);
            panel1.TabIndex = 5;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasswordCheckBox.Location = new Point(47, 347);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(142, 24);
            showPasswordCheckBox.TabIndex = 20;
            showPasswordCheckBox.Text = "Show Password";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            showPasswordCheckBox.CheckedChanged += showPasswordCheckBox_CheckedChanged;
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            registerBtn.Location = new Point(81, 480);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(280, 42);
            registerBtn.TabIndex = 19;
            registerBtn.Text = "Register";
            registerBtn.Click += registerBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(279, 382);
            label2.Name = "label2";
            label2.Size = new Size(82, 17);
            label2.TabIndex = 18;
            label2.Text = "Grade Level";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F);
            label1.Location = new Point(32, 382);
            label1.Name = "label1";
            label1.Size = new Size(132, 17);
            label1.TabIndex = 17;
            label1.Text = "Subject/Department";
            // 
            // gradeLvlComboBox
            // 
            gradeLvlComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeLvlComboBox.FlatStyle = FlatStyle.Flat;
            gradeLvlComboBox.Font = new Font("Century Gothic", 12F);
            gradeLvlComboBox.FormattingEnabled = true;
            gradeLvlComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            gradeLvlComboBox.Location = new Point(279, 400);
            gradeLvlComboBox.Name = "gradeLvlComboBox";
            gradeLvlComboBox.Size = new Size(121, 29);
            gradeLvlComboBox.TabIndex = 16;
            // 
            // subjectComboBox
            // 
            subjectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            subjectComboBox.FlatStyle = FlatStyle.Flat;
            subjectComboBox.Font = new Font("Century Gothic", 12F);
            subjectComboBox.FormattingEnabled = true;
            subjectComboBox.Items.AddRange(new object[] { "Science", "Mathematics", "Filipino", "Araling Panlipunan", "General Education", "English" });
            subjectComboBox.Location = new Point(32, 400);
            subjectComboBox.Name = "subjectComboBox";
            subjectComboBox.Size = new Size(206, 29);
            subjectComboBox.TabIndex = 15;
            // 
            // radioButtonAdv1
            // 
            radioButtonAdv1.AccessibilityEnabled = true;
            radioButtonAdv1.BeforeTouchSize = new Size(0, 10);
            radioButtonAdv1.Location = new Point(42, 194);
            radioButtonAdv1.MetroColor = Color.FromArgb(88, 89, 91);
            radioButtonAdv1.Name = "radioButtonAdv1";
            radioButtonAdv1.Size = new Size(0, 10);
            radioButtonAdv1.TabIndex = 13;
            radioButtonAdv1.Text = "radioButtonAdv1";
            // 
            // autoLabel5
            // 
            autoLabel5.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel5.Location = new Point(32, 201);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(79, 20);
            autoLabel5.TabIndex = 8;
            autoLabel5.Text = "Password";
            // 
            // autoLabel3
            // 
            autoLabel3.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel3.Location = new Point(32, 275);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(140, 20);
            autoLabel3.TabIndex = 9;
            autoLabel3.Text = "Confirm Password";
            // 
            // autoLabel4
            // 
            autoLabel4.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel4.Location = new Point(32, 135);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(46, 20);
            autoLabel4.TabIndex = 10;
            autoLabel4.Text = "Email";
            // 
            // autoLabel2
            // 
            autoLabel2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel2.Location = new Point(32, 61);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(83, 20);
            autoLabel2.TabIndex = 11;
            autoLabel2.Text = "Username";
            // 
            // autoLabel1
            // 
            autoLabel1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            autoLabel1.Location = new Point(132, 26);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(175, 19);
            autoLabel1.TabIndex = 12;
            autoLabel1.Text = "CREATE AN ACCOUNT";
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.BeforeTouchSize = new Size(369, 27);
            passwordTxtBox.Font = new Font("Century Gothic", 12F);
            passwordTxtBox.Location = new Point(32, 224);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '●';
            passwordTxtBox.Size = new Size(369, 27);
            passwordTxtBox.TabIndex = 4;
            passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // cPassTxtBox
            // 
            cPassTxtBox.BeforeTouchSize = new Size(369, 27);
            cPassTxtBox.Font = new Font("Century Gothic", 12F);
            cPassTxtBox.Location = new Point(32, 298);
            cPassTxtBox.Name = "cPassTxtBox";
            cPassTxtBox.PasswordChar = '●';
            cPassTxtBox.Size = new Size(369, 27);
            cPassTxtBox.TabIndex = 5;
            cPassTxtBox.UseSystemPasswordChar = true;
            // 
            // emailTxtBox
            // 
            emailTxtBox.BeforeTouchSize = new Size(369, 27);
            emailTxtBox.Font = new Font("Century Gothic", 12F);
            emailTxtBox.Location = new Point(32, 157);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(369, 27);
            emailTxtBox.TabIndex = 6;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.BeforeTouchSize = new Size(369, 27);
            usernameTxtBox.Font = new Font("Century Gothic", 12F);
            usernameTxtBox.Location = new Point(32, 83);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(369, 27);
            usernameTxtBox.TabIndex = 7;
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
            // teacherPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(teacherSignUpPanel);
            Name = "teacherPanel";
            Size = new Size(1109, 551);
            teacherSignUpPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radioButtonAdv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordTxtBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cPassTxtBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)emailTxtBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)usernameTxtBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel teacherSignUpPanel;
        private Button backBtn;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private ComboBox gradeLvlComboBox;
        private ComboBox subjectComboBox;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv radioButtonAdv1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt passwordTxtBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt cPassTxtBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt emailTxtBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt usernameTxtBox;
        private AntdUI.Button registerBtn;
        private CheckBox showPasswordCheckBox;
    }
}
