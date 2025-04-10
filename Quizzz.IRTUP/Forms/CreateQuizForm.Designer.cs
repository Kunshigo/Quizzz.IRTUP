namespace Quizzz.IRTUP.Forms
{
    partial class CreateQuizForm
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
            questionsPanel = new Panel();
            addQuestionBtn = new AntdUI.Button();
            selectedQuizPanel = new FlowLayoutPanel();
            settingsPanel = new Panel();
            saveQuizBtn = new AntdUI.Button();
            dPCheckBox = new AntdUI.Checkbox();
            timeLimitComboBox = new ComboBox();
            questionTypeComboBox = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            delQuestionBtn = new AntdUI.Button();
            Header.SuspendLayout();
            controlBox.SuspendLayout();
            questionsPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BackColor = Color.Black;
            Header.Controls.Add(controlBox);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(1199, 27);
            Header.TabIndex = 3;
            Header.MouseDown += OnMouseDown;
            // 
            // controlBox
            // 
            controlBox.Controls.Add(maximizeBtn);
            controlBox.Controls.Add(minimizeBtn);
            controlBox.Controls.Add(closeBtn);
            controlBox.Dock = DockStyle.Right;
            controlBox.Location = new Point(1114, 0);
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
            // questionsPanel
            // 
            questionsPanel.AutoScroll = true;
            questionsPanel.BackColor = Color.FromArgb(216, 229, 233);
            questionsPanel.Controls.Add(addQuestionBtn);
            questionsPanel.Dock = DockStyle.Top;
            questionsPanel.Location = new Point(0, 27);
            questionsPanel.Name = "questionsPanel";
            questionsPanel.Size = new Size(999, 88);
            questionsPanel.TabIndex = 4;
            questionsPanel.Resize += questionsPanel_Resize;
            // 
            // addQuestionBtn
            // 
            addQuestionBtn.Dock = DockStyle.Left;
            addQuestionBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addQuestionBtn.Location = new Point(0, 0);
            addQuestionBtn.Name = "addQuestionBtn";
            addQuestionBtn.Padding = new Padding(0, 25, 0, 25);
            addQuestionBtn.Size = new Size(106, 88);
            addQuestionBtn.TabIndex = 1;
            addQuestionBtn.Text = "Add Question";
            addQuestionBtn.Click += addQuestionBtn_Click;
            // 
            // selectedQuizPanel
            // 
            selectedQuizPanel.Dock = DockStyle.Fill;
            selectedQuizPanel.Location = new Point(0, 115);
            selectedQuizPanel.Name = "selectedQuizPanel";
            selectedQuizPanel.Size = new Size(999, 513);
            selectedQuizPanel.TabIndex = 5;
            selectedQuizPanel.Resize += selectedQuizPanel_Resize;
            // 
            // settingsPanel
            // 
            settingsPanel.BackColor = SystemColors.ButtonHighlight;
            settingsPanel.Controls.Add(delQuestionBtn);
            settingsPanel.Controls.Add(saveQuizBtn);
            settingsPanel.Controls.Add(dPCheckBox);
            settingsPanel.Controls.Add(timeLimitComboBox);
            settingsPanel.Controls.Add(questionTypeComboBox);
            settingsPanel.Controls.Add(label2);
            settingsPanel.Controls.Add(label1);
            settingsPanel.Dock = DockStyle.Right;
            settingsPanel.Location = new Point(999, 27);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(200, 601);
            settingsPanel.TabIndex = 6;
            // 
            // saveQuizBtn
            // 
            saveQuizBtn.DefaultBack = Color.FromArgb(127, 216, 190);
            saveQuizBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveQuizBtn.Location = new Point(22, 560);
            saveQuizBtn.Name = "saveQuizBtn";
            saveQuizBtn.Size = new Size(162, 29);
            saveQuizBtn.TabIndex = 4;
            saveQuizBtn.Text = "Save";
            saveQuizBtn.Click += saveQuizBtn_Click;
            // 
            // dPCheckBox
            // 
            dPCheckBox.Font = new Font("Century Gothic", 11F);
            dPCheckBox.Location = new Point(22, 249);
            dPCheckBox.Name = "dPCheckBox";
            dPCheckBox.Size = new Size(162, 23);
            dPCheckBox.TabIndex = 3;
            dPCheckBox.Text = "Double Points";
            // 
            // timeLimitComboBox
            // 
            timeLimitComboBox.FormattingEnabled = true;
            timeLimitComboBox.Items.AddRange(new object[] { "5 Seconds", "10 Seconds", "20 Seconds", "30 Seconds", "50 Seconds", "1 Minute", "2 Minutes", "4 Minutes" });
            timeLimitComboBox.Location = new Point(26, 177);
            timeLimitComboBox.Name = "timeLimitComboBox";
            timeLimitComboBox.Size = new Size(146, 23);
            timeLimitComboBox.TabIndex = 2;
            // 
            // questionTypeComboBox
            // 
            questionTypeComboBox.FormattingEnabled = true;
            questionTypeComboBox.Items.AddRange(new object[] { "Multiple Choice", "Identification", "True or False", "Drag and Drop", "Open - Ended" });
            questionTypeComboBox.Location = new Point(26, 49);
            questionTypeComboBox.Name = "questionTypeComboBox";
            questionTypeComboBox.Size = new Size(146, 23);
            questionTypeComboBox.TabIndex = 2;
            questionTypeComboBox.SelectedIndexChanged += questionTypeComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 153);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 1;
            label2.Text = "Time Limit";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(121, 21);
            label1.TabIndex = 1;
            label1.Text = "Question Type";
            // 
            // delQuestionBtn
            // 
            delQuestionBtn.DefaultBack = Color.FromArgb(127, 216, 190);
            delQuestionBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delQuestionBtn.Location = new Point(22, 525);
            delQuestionBtn.Name = "delQuestionBtn";
            delQuestionBtn.Size = new Size(162, 29);
            delQuestionBtn.TabIndex = 4;
            delQuestionBtn.Text = "Delete";
            delQuestionBtn.Click += delQuestionBtn_Click;
            // 
            // CreateQuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 229, 233);
            ClientSize = new Size(1199, 628);
            ControlBox = false;
            Controls.Add(selectedQuizPanel);
            Controls.Add(questionsPanel);
            Controls.Add(settingsPanel);
            Controls.Add(Header);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CreateQuizForm";
            StartPosition = FormStartPosition.CenterScreen;
            Resize += CreateQuizForm_Resize;
            Header.ResumeLayout(false);
            controlBox.ResumeLayout(false);
            questionsPanel.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel controlBox;
        private Button maximizeBtn;
        private Button minimizeBtn;
        private Button closeBtn;
        private Panel questionsPanel;
        private FlowLayoutPanel selectedQuizPanel;
        private Panel settingsPanel;
        private Label label1;
        private AntdUI.Button addQuestionBtn;
        private Label label2;
        private ComboBox questionTypeComboBox;
        private AntdUI.Checkbox dPCheckBox;
        private ComboBox timeLimitComboBox;
        private AntdUI.Button saveQuizBtn;
        private AntdUI.Button delQuestionBtn;
    }
}