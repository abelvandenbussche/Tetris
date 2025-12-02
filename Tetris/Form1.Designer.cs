namespace Tetris
{
    partial class Form1
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
            PreviewPictureBox = new PictureBox();
            MainPictureBox = new PictureBox();
            HoldPictureBox = new PictureBox();
            Scorelabel = new Label();
            label1 = new Label();
            LinesClearedLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HoldPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PreviewPictureBox
            // 
            PreviewPictureBox.Location = new Point(283, 12);
            PreviewPictureBox.Margin = new Padding(2);
            PreviewPictureBox.Name = "PreviewPictureBox";
            PreviewPictureBox.Size = new Size(129, 220);
            PreviewPictureBox.TabIndex = 0;
            PreviewPictureBox.TabStop = false;
            PreviewPictureBox.Paint += PreviewPictureBox_Paint;
            // 
            // MainPictureBox
            // 
            MainPictureBox.Location = new Point(87, 12);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(191, 246);
            MainPictureBox.TabIndex = 1;
            MainPictureBox.TabStop = false;
            MainPictureBox.Paint += MainPictureBox_Paint;
            // 
            // HoldPictureBox
            // 
            HoldPictureBox.Location = new Point(12, 12);
            HoldPictureBox.Name = "HoldPictureBox";
            HoldPictureBox.Size = new Size(70, 60);
            HoldPictureBox.TabIndex = 2;
            HoldPictureBox.TabStop = false;
            HoldPictureBox.Paint += HoldPictureBox_Paint;
            // 
            // Scorelabel
            // 
            Scorelabel.AutoSize = true;
            Scorelabel.Font = new Font("Segoe UI", 15F);
            Scorelabel.Location = new Point(12, 112);
            Scorelabel.Margin = new Padding(2, 0, 2, 0);
            Scorelabel.Name = "Scorelabel";
            Scorelabel.Size = new Size(23, 28);
            Scorelabel.TabIndex = 3;
            Scorelabel.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(88, 37);
            label1.TabIndex = 4;
            label1.Text = "Score:";
            // 
            // LinesClearedLabel
            // 
            LinesClearedLabel.AutoSize = true;
            LinesClearedLabel.Font = new Font("Segoe UI", 10F);
            LinesClearedLabel.Location = new Point(12, 140);
            LinesClearedLabel.Name = "LinesClearedLabel";
            LinesClearedLabel.Size = new Size(105, 19);
            LinesClearedLabel.TabIndex = 5;
            LinesClearedLabel.Text = "Lines Cleared: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 265);
            Controls.Add(LinesClearedLabel);
            Controls.Add(label1);
            Controls.Add(Scorelabel);
            Controls.Add(HoldPictureBox);
            Controls.Add(MainPictureBox);
            Controls.Add(PreviewPictureBox);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)HoldPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PreviewPictureBox;
        private PictureBox MainPictureBox;
        private PictureBox HoldPictureBox;
        private Label Scorelabel;
        private Label label1;
        private Label LinesClearedLabel;
    }
}
