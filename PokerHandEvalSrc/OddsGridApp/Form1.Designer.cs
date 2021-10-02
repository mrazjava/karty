namespace OddsGridApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.PocketCards = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Board = new System.Windows.Forms.TextBox();
            this.oddsGrid1 = new OddsGrid.OddsGrid();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pocket:";
            // 
            // PocketCards
            // 
            this.PocketCards.Location = new System.Drawing.Point(63, 9);
            this.PocketCards.Name = "PocketCards";
            this.PocketCards.Size = new System.Drawing.Size(49, 20);
            this.PocketCards.TabIndex = 2;
            this.PocketCards.Text = "As Ks";
            this.PocketCards.TextChanged += new System.EventHandler(this.PocketCards_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Board:";
            // 
            // Board
            // 
            this.Board.Location = new System.Drawing.Point(184, 9);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(100, 20);
            this.Board.TabIndex = 4;
            this.Board.Text = "Ts Qs 2d";
            this.Board.TextChanged += new System.EventHandler(this.Board_TextChanged);
            // 
            // oddsGrid1
            // 
            this.oddsGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oddsGrid1.Board = "";
            this.oddsGrid1.Location = new System.Drawing.Point(0, 31);
            this.oddsGrid1.Name = "oddsGrid1";
            this.oddsGrid1.Pocket = "";
            this.oddsGrid1.Size = new System.Drawing.Size(367, 299);
            this.oddsGrid1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 335);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PocketCards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oddsGrid1);
            this.Name = "Form1";
            this.Text = "Hand Odds App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OddsGrid.OddsGrid oddsGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PocketCards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Board;

    }
}

