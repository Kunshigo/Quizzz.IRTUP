namespace Quizzz.IRTUP.Forms
{
    partial class MainMenuStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuStudent));
            Header = new Panel();
            welcomeLbl = new Label();
            label1 = new Label();
            menuPanelBtn = new PictureBox();
            controlBox = new Panel();
            maximizeBtn = new Button();
            minimizeBtn = new Button();
            closeBtn = new Button();
            sideBar = new FlowLayoutPanel();
            menuContainer1 = new FlowLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            menuBtn = new Button();
            panel5 = new Panel();
            viewQuizBtn = new Button();
            panel6 = new Panel();
            notificationBtn = new Button();
            menuContainer2 = new FlowLayoutPanel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            settingsBtn = new Button();
            panel7 = new Panel();
            generalSettingsBtn = new Button();
            panel8 = new Panel();
            accountSettingsBtn = new Button();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            button3 = new Button();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            button4 = new Button();
            mainMenuPanel = new FlowLayoutPanel();
            sideBarTransition = new System.Windows.Forms.Timer(components);
            menuTransition = new System.Windows.Forms.Timer(components);
            menuTransition2 = new System.Windows.Forms.Timer(components);
            Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuPanelBtn).BeginInit();
            controlBox.SuspendLayout();
            sideBar.SuspendLayout();
            menuContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            menuContainer2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.Black;
            Header.Controls.Add(welcomeLbl);
            Header.Controls.Add(label1);
            Header.Controls.Add(menuPanelBtn);
            Header.Controls.Add(controlBox);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(1227, 43);
            Header.TabIndex = 4;
            Header.MouseDown += OnMouseDown;
            // 
            // welcomeLbl
            // 
            welcomeLbl.AutoSize = true;
            welcomeLbl.Font = new Font("Century Gothic", 10.75F);
            welcomeLbl.ForeColor = SystemColors.ButtonHighlight;
            welcomeLbl.Location = new Point(953, 17);
            welcomeLbl.Name = "welcomeLbl";
            welcomeLbl.Size = new Size(49, 20);
            welcomeLbl.TabIndex = 5;
            welcomeLbl.Text = "blank";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.75F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(43, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 5;
            label1.Text = "Quizzz";
            // 
            // menuPanelBtn
            // 
            menuPanelBtn.BackColor = Color.Transparent;
            menuPanelBtn.BackgroundImage = Properties.Resources.MenuStripesTransparentGreen;
            menuPanelBtn.BackgroundImageLayout = ImageLayout.Stretch;
            menuPanelBtn.Cursor = Cursors.Hand;
            menuPanelBtn.Location = new Point(4, 4);
            menuPanelBtn.Name = "menuPanelBtn";
            menuPanelBtn.Size = new Size(33, 33);
            menuPanelBtn.TabIndex = 4;
            menuPanelBtn.TabStop = false;
            menuPanelBtn.Click += menuPanelBtn_Click;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(maximizeBtn);
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(1142, 0);
            controlBox.Name = "controlBox";
            controlBox.Size = new Size(85, 43);
            controlBox.TabIndex = 3;
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
            maximizeBtn.Click += maximizeBtn_Click;
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
            minimizeBtn.Click += minimizeBtn_Click;
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
            closeBtn.Click += closeBtn_Click;
            // 
            // sideBar
            // 
            sideBar.BackColor = Color.FromArgb(50, 170, 160);
            sideBar.Controls.Add(menuContainer1);
            sideBar.Controls.Add(menuContainer2);
            sideBar.Controls.Add(panel3);
            sideBar.Controls.Add(panel4);
            sideBar.Dock = DockStyle.Left;
            sideBar.Location = new Point(0, 43);
            sideBar.Name = "sideBar";
            sideBar.Size = new Size(199, 562);
            sideBar.TabIndex = 5;
            // 
            // menuContainer1
            // 
            menuContainer1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            menuContainer1.BackColor = Color.FromArgb(66, 226, 184);
            menuContainer1.Controls.Add(panel1);
            menuContainer1.Controls.Add(panel5);
            menuContainer1.Controls.Add(panel6);
            menuContainer1.FlowDirection = FlowDirection.TopDown;
            menuContainer1.Location = new Point(0, 0);
            menuContainer1.Margin = new Padding(0);
            menuContainer1.Name = "menuContainer1";
            menuContainer1.Size = new Size(196, 58);
            menuContainer1.TabIndex = 9;
            menuContainer1.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(menuBtn);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 58);
            panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.BackColor = Color.FromArgb(50, 170, 160);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.homeicon;
            pictureBox1.Location = new Point(12, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // menuBtn
            // 
            menuBtn.BackColor = Color.FromArgb(50, 170, 160);
            menuBtn.Cursor = Cursors.Hand;
            menuBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuBtn.Location = new Point(-50, -19);
            menuBtn.Margin = new Padding(0);
            menuBtn.Name = "menuBtn";
            menuBtn.Size = new Size(280, 100);
            menuBtn.TabIndex = 6;
            menuBtn.Text = "Menu";
            menuBtn.UseVisualStyleBackColor = false;
            menuBtn.Click += menuBtn_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(viewQuizBtn);
            panel5.Location = new Point(0, 58);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(196, 58);
            panel5.TabIndex = 5;
            // 
            // viewQuizBtn
            // 
            viewQuizBtn.BackColor = Color.FromArgb(66, 226, 184);
            viewQuizBtn.Cursor = Cursors.Hand;
            viewQuizBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewQuizBtn.Location = new Point(-12, -19);
            viewQuizBtn.Margin = new Padding(0);
            viewQuizBtn.Name = "viewQuizBtn";
            viewQuizBtn.Size = new Size(242, 100);
            viewQuizBtn.TabIndex = 6;
            viewQuizBtn.Text = "Available Quizzes";
            viewQuizBtn.UseVisualStyleBackColor = false;
            viewQuizBtn.Click += viewQuizBtn_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(notificationBtn);
            panel6.Location = new Point(0, 116);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(196, 58);
            panel6.TabIndex = 5;
            // 
            // notificationBtn
            // 
            notificationBtn.BackColor = Color.FromArgb(66, 226, 184);
            notificationBtn.Cursor = Cursors.Hand;
            notificationBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            notificationBtn.Location = new Point(-12, -19);
            notificationBtn.Margin = new Padding(0);
            notificationBtn.Name = "notificationBtn";
            notificationBtn.Size = new Size(242, 100);
            notificationBtn.TabIndex = 6;
            notificationBtn.Text = "Notifications";
            notificationBtn.UseVisualStyleBackColor = false;
            notificationBtn.Click += notificationBtn_Click;
            // 
            // menuContainer2
            // 
            menuContainer2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            menuContainer2.BackColor = Color.FromArgb(66, 226, 184);
            menuContainer2.Controls.Add(panel2);
            menuContainer2.Controls.Add(panel7);
            menuContainer2.Controls.Add(panel8);
            menuContainer2.FlowDirection = FlowDirection.TopDown;
            menuContainer2.Location = new Point(0, 58);
            menuContainer2.Margin = new Padding(0);
            menuContainer2.Name = "menuContainer2";
            menuContainer2.Size = new Size(196, 58);
            menuContainer2.TabIndex = 10;
            menuContainer2.WrapContents = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(settingsBtn);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(196, 58);
            panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.BackColor = Color.FromArgb(50, 170, 160);
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = Properties.Resources.settingicon;
            pictureBox2.Location = new Point(15, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // settingsBtn
            // 
            settingsBtn.BackColor = Color.FromArgb(50, 170, 160);
            settingsBtn.Cursor = Cursors.Hand;
            settingsBtn.Font = new Font("Century Gothic", 9F);
            settingsBtn.Location = new Point(-12, -19);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(218, 100);
            settingsBtn.TabIndex = 6;
            settingsBtn.Text = "Settings";
            settingsBtn.UseVisualStyleBackColor = false;
            settingsBtn.Click += settingsBtn_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(generalSettingsBtn);
            panel7.Location = new Point(0, 58);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(196, 58);
            panel7.TabIndex = 5;
            // 
            // generalSettingsBtn
            // 
            generalSettingsBtn.BackColor = Color.FromArgb(66, 226, 184);
            generalSettingsBtn.Cursor = Cursors.Hand;
            generalSettingsBtn.Font = new Font("Century Gothic", 9F);
            generalSettingsBtn.Location = new Point(-12, -19);
            generalSettingsBtn.Name = "generalSettingsBtn";
            generalSettingsBtn.Size = new Size(250, 100);
            generalSettingsBtn.TabIndex = 6;
            generalSettingsBtn.Text = "General Settings";
            generalSettingsBtn.UseVisualStyleBackColor = false;
            generalSettingsBtn.Click += generalSettingsBtn_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(accountSettingsBtn);
            panel8.Location = new Point(0, 116);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(196, 58);
            panel8.TabIndex = 5;
            // 
            // accountSettingsBtn
            // 
            accountSettingsBtn.BackColor = Color.FromArgb(66, 226, 184);
            accountSettingsBtn.Cursor = Cursors.Hand;
            accountSettingsBtn.Font = new Font("Century Gothic", 9F);
            accountSettingsBtn.Location = new Point(-12, -19);
            accountSettingsBtn.Name = "accountSettingsBtn";
            accountSettingsBtn.Size = new Size(250, 100);
            accountSettingsBtn.TabIndex = 6;
            accountSettingsBtn.Text = "Account Settings";
            accountSettingsBtn.UseVisualStyleBackColor = false;
            accountSettingsBtn.Click += accountSettingsBtn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(button3);
            panel3.Location = new Point(0, 116);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(196, 58);
            panel3.TabIndex = 7;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Left;
            pictureBox3.BackColor = Color.FromArgb(50, 170, 160);
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.ErrorImage = null;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(16, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 35);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(50, 170, 160);
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Century Gothic", 9F);
            button3.Location = new Point(-26, -19);
            button3.Name = "button3";
            button3.Size = new Size(232, 100);
            button3.TabIndex = 6;
            button3.Text = "About";
            button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(button4);
            panel4.Location = new Point(0, 174);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(196, 58);
            panel4.TabIndex = 8;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Left;
            pictureBox4.BackColor = Color.FromArgb(50, 170, 160);
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.ErrorImage = null;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(15, 13);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 35);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(50, 170, 160);
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Century Gothic", 9F);
            button4.Location = new Point(-26, -19);
            button4.Name = "button4";
            button4.Size = new Size(232, 100);
            button4.TabIndex = 6;
            button4.Text = "Logout";
            button4.UseVisualStyleBackColor = false;
            // 
            // mainMenuPanel
            // 
            mainMenuPanel.Dock = DockStyle.Fill;
            mainMenuPanel.Location = new Point(199, 43);
            mainMenuPanel.Margin = new Padding(0);
            mainMenuPanel.Name = "mainMenuPanel";
            mainMenuPanel.Size = new Size(1028, 562);
            mainMenuPanel.TabIndex = 6;
            mainMenuPanel.WrapContents = false;
            // 
            // sideBarTransition
            // 
            sideBarTransition.Interval = 10;
            sideBarTransition.Tick += sideBarTransition_Tick;
            // 
            // menuTransition
            // 
            menuTransition.Interval = 10;
            menuTransition.Tick += menuTransition_Tick;
            // 
            // menuTransition2
            // 
            menuTransition2.Interval = 10;
            menuTransition2.Tick += menuTransition2_Tick;
            // 
            // MainMenuStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 605);
            Controls.Add(mainMenuPanel);
            Controls.Add(sideBar);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainMenuStudent";
            Text = "MainMenuStudent";
            Header.ResumeLayout(false);
            Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)menuPanelBtn).EndInit();
            controlBox.ResumeLayout(false);
            sideBar.ResumeLayout(false);
            menuContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            menuContainer2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Label welcomeLbl;
        private Label label1;
        private PictureBox menuPanelBtn;
        private Panel controlBox;
        private Button maximizeBtn;
        private Button minimizeBtn;
        private Button closeBtn;
        private FlowLayoutPanel sideBar;
        private FlowLayoutPanel mainMenuPanel;
        private System.Windows.Forms.Timer sideBarTransition;
        private FlowLayoutPanel menuContainer1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button menuBtn;
        private Panel panel5;
        private Button viewQuizBtn;
        private Panel panel6;
        private Button notificationBtn;
        private FlowLayoutPanel menuContainer2;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Button settingsBtn;
        private Panel panel7;
        private Button generalSettingsBtn;
        private Panel panel8;
        private Button accountSettingsBtn;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Button button3;
        private Panel panel4;
        private PictureBox pictureBox4;
        private Button button4;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer menuTransition2;
    }
}