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
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HoldPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PreviewPictureBox
            // 
            PreviewPictureBox.Location = new Point(400, 12);
            PreviewPictureBox.Margin = new Padding(2);
            PreviewPictureBox.Name = "PreviewPictureBox";
            PreviewPictureBox.Size = new Size(75, 150);
            PreviewPictureBox.TabIndex = 0;
            PreviewPictureBox.TabStop = false;
            PreviewPictureBox.Paint += PreviewPictureBox_Paint;
            // 
            // MainPictureBox
            // 
            MainPictureBox.Location = new Point(159, 12);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(191, 246);
            MainPictureBox.TabIndex = 1;
            MainPictureBox.TabStop = false;
            MainPictureBox.Paint += MainPictureBox_Paint;
            // 
            // HoldPictureBox
            // 
            HoldPictureBox.Location = new Point(34, 40);
            HoldPictureBox.Name = "HoldPictureBox";
            HoldPictureBox.Size = new Size(75, 75);
            HoldPictureBox.TabIndex = 2;
            HoldPictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
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
        }

        #endregion

        private PictureBox PreviewPictureBox;
        private PictureBox MainPictureBox;
        private PictureBox HoldPictureBox;
    }
}
