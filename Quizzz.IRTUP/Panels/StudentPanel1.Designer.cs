namespace Quizzz.IRTUP.Panels
{
    partial class StudentPanel1
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
            gradeLvlComboBox = new ComboBox();
            birthDatePicker = new DateTimePicker();
            showPasswordCheckBox = new CheckBox();
            registerBtn = new AntdUI.Button();
            radioButtonAdv1 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radioButtonAdv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cPassTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emailTxtBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usernameTxtBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(190, 210, 180);
            panel1.Controls.Add(gradeLvlComboBox);
            panel1.Controls.Add(birthDatePicker);
            panel1.Controls.Add(showPasswordCheckBox);
            panel1.Controls.Add(registerBtn);
            panel1.Controls.Add(radioButtonAdv1);
            panel1.Controls.Add(autoLabel7);
            panel1.Controls.Add(autoLabel6);
            panel1.Controls.Add(autoLabel5);
            panel1.Controls.Add(autoLabel3);
            panel1.Controls.Add(autoLabel4);
            panel1.Controls.Add(autoLabel2);
            panel1.Controls.Add(autoLabel1);
            panel1.Controls.Add(passwordTxtBox);
            panel1.Controls.Add(cPassTxtBox);
            panel1.Controls.Add(emailTxtBox);
            panel1.Controls.Add(usernameTxtBox);
            panel1.Location = new Point(333, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 551);
            panel1.TabIndex = 6;
            // 
            // gradeLvlComboBox
            // 
            gradeLvlComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gradeLvlComboBox.Font = new Font("Century Gothic", 12F);
            gradeLvlComboBox.FormattingEnabled = true;
            gradeLvlComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            gradeLvlComboBox.Location = new Point(232, 370);
            gradeLvlComboBox.Name = "gradeLvlComboBox";
            gradeLvlComboBox.Size = new Size(121, 29);
            gradeLvlComboBox.TabIndex = 22;
            // 
            // birthDatePicker
            // 
            birthDatePicker.CustomFormat = "MMMM dd yyyy";
            birthDatePicker.Font = new Font("Century Gothic", 12F);
            birthDatePicker.Format = DateTimePickerFormat.Custom;
            birthDatePicker.Location = new Point(31, 370);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.RightToLeft = RightToLeft.No;
            birthDatePicker.Size = new Size(186, 27);
            birthDatePicker.TabIndex = 21;
            birthDatePicker.Value = new DateTime(2025, 4, 13, 0, 0, 0, 0);
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPasswordCheckBox.Location = new Point(47, 421);
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
            // radioButtonAdv1
            // 
            radioButtonAdv1.AccessibilityEnabled = true;
            radioButtonAdv1.BeforeTouchSize = new Size(0, 10);
            radioButtonAdv1.Location = new Point(41, 196);
            radioButtonAdv1.MetroColor = Color.FromArgb(88, 89, 91);
            radioButtonAdv1.Name = "radioButtonAdv1";
            radioButtonAdv1.Size = new Size(0, 10);
            radioButtonAdv1.TabIndex = 13;
            radioButtonAdv1.Text = "radioButtonAdv1";
            // 
            // autoLabel7
            // 
            autoLabel7.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel7.Location = new Point(232, 347);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(101, 20);
            autoLabel7.TabIndex = 11;
            autoLabel7.Text = "Grade Level";
            // 
            // autoLabel6
            // 
            autoLabel6.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel6.Location = new Point(31, 347);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(75, 20);
            autoLabel6.TabIndex = 11;
            autoLabel6.Text = "Birthdate";
            // 
            // autoLabel5
            // 
            autoLabel5.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel5.Location = new Point(31, 203);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(79, 20);
            autoLabel5.TabIndex = 8;
            autoLabel5.Text = "Password";
            // 
            // autoLabel3
            // 
            autoLabel3.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel3.Location = new Point(31, 277);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(140, 20);
            autoLabel3.TabIndex = 9;
            autoLabel3.Text = "Confirm Password";
            // 
            // autoLabel4
            // 
            autoLabel4.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel4.Location = new Point(31, 137);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(46, 20);
            autoLabel4.TabIndex = 10;
            autoLabel4.Text = "Email";
            // 
            // autoLabel2
            // 
            autoLabel2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoLabel2.Location = new Point(31, 63);
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
            passwordTxtBox.Location = new Point(31, 226);
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
            cPassTxtBox.Location = new Point(31, 300);
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
            emailTxtBox.Location = new Point(31, 159);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(369, 27);
            emailTxtBox.TabIndex = 6;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.BeforeTouchSize = new Size(369, 27);
            usernameTxtBox.Font = new Font("Century Gothic", 12F);
            usernameTxtBox.Location = new Point(31, 85);
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
            backBtn.Location = new Point(3, 3);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(30, 30);
            backBtn.TabIndex = 7;
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // StudentPanel1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backBtn);
            Controls.Add(panel1);
            Name = "StudentPanel1";
            Size = new Size(1109, 551);
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

        private Panel panel1;
        private CheckBox showPasswordCheckBox;
        private AntdUI.Button registerBtn;
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
        private DateTimePicker birthDatePicker;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Button backBtn;
        private ComboBox gradeLvlComboBox;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
    }
}
