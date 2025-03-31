namespace Quizzz.IRTUP
{
    partial class loginWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Header = new Panel();
            controlBox = new Panel();
            minimizeBtn = new Button();
            closeBtn = new Button();
            usernameTxtBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            passwordTxtBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            signUpLbl = new Label();
            pictureBox1 = new PictureBox();
            loginBtn = new Button();
            Header.SuspendLayout();
            controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(209, 128);
            label1.Name = "label1";
            label1.Size = new Size(84, 30);
            label1.TabIndex = 1;
            label1.Text = "Log In";
            // 
            // Header
            // 
            Header.BackColor = Color.Black;
            Header.Controls.Add(controlBox);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(500, 27);
            Header.TabIndex = 2;
            Header.MouseDown += OnMouseDown;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(453, 0);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(47, 27);
            controlBox.TabIndex = 3;
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
            minimizeBtn.Click += minimizeBtn_Click;
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
            // usernameTxtBox
            // 
            usernameTxtBox.AllowPromptAsInput = true;
            usernameTxtBox.AnimateReadOnly = false;
            usernameTxtBox.AsciiOnly = false;
            usernameTxtBox.BackgroundImageLayout = ImageLayout.None;
            usernameTxtBox.BeepOnError = false;
            usernameTxtBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            usernameTxtBox.Depth = 0;
            usernameTxtBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            usernameTxtBox.HidePromptOnLeave = false;
            usernameTxtBox.HideSelection = true;
            usernameTxtBox.InsertKeyMode = InsertKeyMode.Default;
            usernameTxtBox.LeadingIcon = null;
            usernameTxtBox.Location = new Point(33, 212);
            usernameTxtBox.Mask = "";
            usernameTxtBox.MaxLength = 32767;
            usernameTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.PasswordChar = '\0';
            usernameTxtBox.PrefixSuffixText = null;
            usernameTxtBox.PromptChar = '_';
            usernameTxtBox.ReadOnly = false;
            usernameTxtBox.RejectInputOnFirstFailure = false;
            usernameTxtBox.ResetOnPrompt = true;
            usernameTxtBox.ResetOnSpace = true;
            usernameTxtBox.RightToLeft = RightToLeft.No;
            usernameTxtBox.SelectedText = "";
            usernameTxtBox.SelectionLength = 0;
            usernameTxtBox.SelectionStart = 0;
            usernameTxtBox.ShortcutsEnabled = true;
            usernameTxtBox.Size = new Size(420, 48);
            usernameTxtBox.SkipLiterals = true;
            usernameTxtBox.TabIndex = 3;
            usernameTxtBox.TabStop = false;
            usernameTxtBox.TextAlign = HorizontalAlignment.Left;
            usernameTxtBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            usernameTxtBox.TrailingIcon = null;
            usernameTxtBox.UseSystemPasswordChar = false;
            usernameTxtBox.ValidatingType = null;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.AllowPromptAsInput = true;
            passwordTxtBox.AnimateReadOnly = false;
            passwordTxtBox.AsciiOnly = false;
            passwordTxtBox.BackgroundImageLayout = ImageLayout.None;
            passwordTxtBox.BeepOnError = false;
            passwordTxtBox.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            passwordTxtBox.Depth = 0;
            passwordTxtBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            passwordTxtBox.HidePromptOnLeave = false;
            passwordTxtBox.HideSelection = true;
            passwordTxtBox.InsertKeyMode = InsertKeyMode.Default;
            passwordTxtBox.LeadingIcon = null;
            passwordTxtBox.Location = new Point(33, 301);
            passwordTxtBox.Mask = "";
            passwordTxtBox.MaxLength = 32767;
            passwordTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '\0';
            passwordTxtBox.PrefixSuffixText = null;
            passwordTxtBox.PromptChar = '_';
            passwordTxtBox.ReadOnly = false;
            passwordTxtBox.RejectInputOnFirstFailure = false;
            passwordTxtBox.ResetOnPrompt = true;
            passwordTxtBox.ResetOnSpace = true;
            passwordTxtBox.RightToLeft = RightToLeft.No;
            passwordTxtBox.SelectedText = "";
            passwordTxtBox.SelectionLength = 0;
            passwordTxtBox.SelectionStart = 0;
            passwordTxtBox.ShortcutsEnabled = true;
            passwordTxtBox.Size = new Size(420, 48);
            passwordTxtBox.SkipLiterals = true;
            passwordTxtBox.TabIndex = 3;
            passwordTxtBox.TabStop = false;
            passwordTxtBox.TextAlign = HorizontalAlignment.Left;
            passwordTxtBox.TextMaskFormat = MaskFormat.IncludeLiterals;
            passwordTxtBox.TrailingIcon = null;
            passwordTxtBox.UseSystemPasswordChar = false;
            passwordTxtBox.ValidatingType = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 14.25F);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(33, 187);
            label2.Name = "label2";
            label2.Size = new Size(180, 22);
            label2.TabIndex = 4;
            label2.Text = " Username or Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 14.25F);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(33, 276);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(62, 460);
            label4.Name = "label4";
            label4.Size = new Size(264, 24);
            label4.TabIndex = 1;
            label4.Text = "Don't have an account?";
            // 
            // signUpLbl
            // 
            signUpLbl.AutoSize = true;
            signUpLbl.Cursor = Cursors.Hand;
            signUpLbl.Font = new Font("Century Gothic", 15.75F);
            signUpLbl.ForeColor = SystemColors.HotTrack;
            signUpLbl.Location = new Point(332, 460);
            signUpLbl.Name = "signUpLbl";
            signUpLbl.Size = new Size(83, 24);
            signUpLbl.TabIndex = 1;
            signUpLbl.Text = "Sign up";
            signUpLbl.Click += signUpLbl_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.QUIZZ_1_;
            pictureBox1.Location = new Point(206, 41);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.FromArgb(4, 167, 119);
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.Transparent;
            loginBtn.Location = new Point(98, 384);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(293, 40);
            loginBtn.TabIndex = 7;
            loginBtn.Text = "Log In";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // loginWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 229, 233);
            ClientSize = new Size(500, 528);
            ControlBox = false;
            Controls.Add(loginBtn);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordTxtBox);
            Controls.Add(usernameTxtBox);
            Controls.Add(Header);
            Controls.Add(signUpLbl);
            Controls.Add(label4);
            Controls.Add(label1);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            Name = "loginWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quizzz Login";
            Header.ResumeLayout(false);
            controlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel Header;
        private Panel controlBox;
        private Button minimizeBtn;
        private Button closeBtn;
        private MaterialSkin.Controls.MaterialMaskedTextBox usernameTxtBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox passwordTxtBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label signUpLbl;
        private PictureBox pictureBox1;
        private Button loginBtn;
    }
}
