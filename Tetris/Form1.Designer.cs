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
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PreviewPictureBox
            // 
            PreviewPictureBox.Location = new Point(39, 59);
            PreviewPictureBox.Name = "PreviewPictureBox";
            PreviewPictureBox.Size = new Size(409, 253);
            PreviewPictureBox.TabIndex = 0;
            PreviewPictureBox.TabStop = false;
            PreviewPictureBox.Paint += PreviewPictureBox_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PreviewPictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PreviewPictureBox;
    }
}
