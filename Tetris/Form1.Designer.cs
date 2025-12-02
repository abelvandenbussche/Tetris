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
            ((System.ComponentModel.ISupportInitialize)PreviewPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HoldPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PreviewPictureBox
            // 
            PreviewPictureBox.Location = new Point(571, 20);
            PreviewPictureBox.Name = "PreviewPictureBox";
            PreviewPictureBox.Size = new Size(184, 366);
            PreviewPictureBox.TabIndex = 0;
            PreviewPictureBox.TabStop = false;
            PreviewPictureBox.Paint += PreviewPictureBox_Paint;
            // 
            // MainPictureBox
            // 
            MainPictureBox.Location = new Point(227, 20);
            MainPictureBox.Margin = new Padding(4, 5, 4, 5);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(273, 410);
            MainPictureBox.TabIndex = 1;
            MainPictureBox.TabStop = false;
            MainPictureBox.Paint += MainPictureBox_Paint;
            // 
            // HoldPictureBox
            // 
            HoldPictureBox.Location = new Point(49, 67);
            HoldPictureBox.Margin = new Padding(4, 5, 4, 5);
            HoldPictureBox.Name = "HoldPictureBox";
            HoldPictureBox.Size = new Size(100, 100);
            HoldPictureBox.TabIndex = 2;
            HoldPictureBox.TabStop = false;
            HoldPictureBox.Paint += HoldPictureBox_Paint;
            // 
            // Scorelabel
            // 
            Scorelabel.AutoSize = true;
            Scorelabel.Location = new Point(49, 250);
            Scorelabel.Name = "Scorelabel";
            Scorelabel.Size = new Size(75, 25);
            Scorelabel.TabIndex = 3;
            Scorelabel.Text = "Score: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Scorelabel);
            Controls.Add(HoldPictureBox);
            Controls.Add(MainPictureBox);
            Controls.Add(PreviewPictureBox);
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
    }
}
