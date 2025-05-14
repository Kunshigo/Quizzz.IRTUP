namespace Quizzz.IRTUP.Panels
{
    partial class AccountSettingsUserControl
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
            label6 = new Label();
            saveBtn = new AntdUI.Button();
            editAccountBtn = new AntdUI.Button();
            subjectComboBox = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            emailTxtBox = new TextBox();
            usernameTxtBox = new TextBox();
            deleteAccountBtn = new AntdUI.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(112, 193, 179);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(editAccountBtn);
            panel1.Controls.Add(subjectComboBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(emailTxtBox);
            panel1.Controls.Add(usernameTxtBox);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 601);
            panel1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 25F);
            label6.Location = new Point(57, 48);
            label6.Name = "label6";
            label6.Size = new Size(277, 40);
            label6.TabIndex = 11;
            label6.Text = "Account Details";
            // 
            // saveBtn
            // 
            saveBtn.DefaultBack = Color.FromArgb(180, 220, 127);
            saveBtn.Font = new Font("Century Gothic", 12F);
            saveBtn.Location = new Point(57, 514);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(402, 32);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Save";
            saveBtn.Visible = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // editAccountBtn
            // 
            editAccountBtn.Font = new Font("Century Gothic", 12F);
            editAccountBtn.Location = new Point(57, 476);
            editAccountBtn.Name = "editAccountBtn";
            editAccountBtn.Size = new Size(402, 32);
            editAccountBtn.TabIndex = 9;
            editAccountBtn.Text = "Edit Account";
            editAccountBtn.Click += editAccountBtn_Click;
            // 
            // subjectComboBox
            // 
            subjectComboBox.Font = new Font("Century Gothic", 20F);
            subjectComboBox.FormattingEnabled = true;
            subjectComboBox.Items.AddRange(new object[] { "Science", "Mathematics", "Filipino", "Araling Panlipunan", "General Education", "English" });
            subjectComboBox.Location = new Point(57, 379);
            subjectComboBox.Name = "subjectComboBox";
            subjectComboBox.Size = new Size(188, 41);
            subjectComboBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 20F);
            label4.Location = new Point(57, 343);
            label4.Name = "label4";
            label4.Size = new Size(113, 33);
            label4.TabIndex = 6;
            label4.Text = "Subject";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 20F);
            label2.Location = new Point(57, 231);
            label2.Name = "label2";
            label2.Size = new Size(85, 33);
            label2.TabIndex = 6;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20F);
            label1.Location = new Point(57, 126);
            label1.Name = "label1";
            label1.Size = new Size(146, 33);
            label1.TabIndex = 7;
            label1.Text = "Username";
            // 
            // emailTxtBox
            // 
            emailTxtBox.Font = new Font("Century Gothic", 20F);
            emailTxtBox.Location = new Point(57, 267);
            emailTxtBox.Name = "emailTxtBox";
            emailTxtBox.Size = new Size(250, 40);
            emailTxtBox.TabIndex = 5;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Font = new Font("Century Gothic", 20F);
            usernameTxtBox.Location = new Point(57, 162);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(250, 40);
            usernameTxtBox.TabIndex = 4;
            // 
            // deleteAccountBtn
            // 
            deleteAccountBtn.BackColor = Color.Red;
            deleteAccountBtn.DefaultBack = Color.FromArgb(249, 112, 104);
            deleteAccountBtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteAccountBtn.Location = new Point(702, 97);
            deleteAccountBtn.Name = "deleteAccountBtn";
            deleteAccountBtn.Size = new Size(213, 372);
            deleteAccountBtn.TabIndex = 9;
            deleteAccountBtn.Text = "DELETE ACCOUNT";
            deleteAccountBtn.Click += deleteAccountBtn_Click;
            // 
            // AccountSettingsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteAccountBtn);
            Controls.Add(panel1);
            Name = "AccountSettingsUserControl";
            Size = new Size(1044, 601);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private AntdUI.Button editAccountBtn;
        private ComboBox subjectComboBox;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox emailTxtBox;
        private TextBox usernameTxtBox;
        private AntdUI.Button deleteAccountBtn;
        private Label label6;
        private AntdUI.Button saveBtn;
    }
}
