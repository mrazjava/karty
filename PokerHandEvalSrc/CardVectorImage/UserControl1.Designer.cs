namespace CardVectorImage
{
    partial class CardVector
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
            this.SuspendLayout();
            // 
            // CardVector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CardVector";
            this.Size = new System.Drawing.Size(261, 194);
            this.Load += new System.EventHandler(this.CardVector_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CardVector_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CardVector_MouseDoubleClick);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CardVector_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
