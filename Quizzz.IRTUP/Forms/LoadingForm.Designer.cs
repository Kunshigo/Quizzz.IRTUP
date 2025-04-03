namespace Quizzz.IRTUP
{
    partial class LoadingForm
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
            lblMessage = new Label();
            materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(90, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(47, 17);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            // 
            // materialProgressBar1
            // 
            materialProgressBar1.Depth = 0;
            materialProgressBar1.ForeColor = Color.FromArgb(99, 185, 149);
            materialProgressBar1.Location = new Point(12, 52);
            materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar1.Name = "materialProgressBar1";
            materialProgressBar1.Size = new Size(200, 5);
            materialProgressBar1.TabIndex = 1;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 74);
            Controls.Add(materialProgressBar1);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            Text = "LoadingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    }
}