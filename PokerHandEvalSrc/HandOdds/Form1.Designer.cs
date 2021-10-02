namespace HandOdds
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Player1Value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Player1Pocket = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Player2Value = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Player2Pocket = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Player3Value = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player3Pocket = new System.Windows.Forms.TextBox();
            this.Player4 = new System.Windows.Forms.GroupBox();
            this.Player4Value = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Player4Pocket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Board = new System.Windows.Forms.TextBox();
            this.DeadCardsLabel = new System.Windows.Forms.Label();
            this.DeadCards = new System.Windows.Forms.TextBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.ErrorInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Player4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Player1Value);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Player1Pocket);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player1";
            // 
            // Player1Value
            // 
            this.Player1Value.AutoSize = true;
            this.Player1Value.Location = new System.Drawing.Point(38, 42);
            this.Player1Value.Name = "Player1Value";
            this.Player1Value.Size = new System.Drawing.Size(30, 13);
            this.Player1Value.TabIndex = 2;
            this.Player1Value.Text = "0.0%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pocket";
            // 
            // Player1Pocket
            // 
            this.Player1Pocket.Location = new System.Drawing.Point(60, 18);
            this.Player1Pocket.Name = "Player1Pocket";
            this.Player1Pocket.Size = new System.Drawing.Size(40, 20);
            this.Player1Pocket.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Player2Value);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Player2Pocket);
            this.groupBox2.Location = new System.Drawing.Point(124, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 66);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player2";
            // 
            // Player2Value
            // 
            this.Player2Value.AutoSize = true;
            this.Player2Value.Location = new System.Drawing.Point(38, 42);
            this.Player2Value.Name = "Player2Value";
            this.Player2Value.Size = new System.Drawing.Size(30, 13);
            this.Player2Value.TabIndex = 2;
            this.Player2Value.Text = "0.0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pocket";
            // 
            // Player2Pocket
            // 
            this.Player2Pocket.Location = new System.Drawing.Point(60, 18);
            this.Player2Pocket.Name = "Player2Pocket";
            this.Player2Pocket.Size = new System.Drawing.Size(40, 20);
            this.Player2Pocket.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Player3Value);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Player3Pocket);
            this.groupBox3.Location = new System.Drawing.Point(236, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 66);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player3";
            // 
            // Player3Value
            // 
            this.Player3Value.AutoSize = true;
            this.Player3Value.Location = new System.Drawing.Point(38, 42);
            this.Player3Value.Name = "Player3Value";
            this.Player3Value.Size = new System.Drawing.Size(30, 13);
            this.Player3Value.TabIndex = 2;
            this.Player3Value.Text = "0.0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pocket";
            // 
            // Player3Pocket
            // 
            this.Player3Pocket.Location = new System.Drawing.Point(60, 18);
            this.Player3Pocket.Name = "Player3Pocket";
            this.Player3Pocket.Size = new System.Drawing.Size(40, 20);
            this.Player3Pocket.TabIndex = 0;
            // 
            // Player4
            // 
            this.Player4.Controls.Add(this.Player4Value);
            this.Player4.Controls.Add(this.label5);
            this.Player4.Controls.Add(this.Player4Pocket);
            this.Player4.Location = new System.Drawing.Point(348, 55);
            this.Player4.Name = "Player4";
            this.Player4.Size = new System.Drawing.Size(106, 66);
            this.Player4.TabIndex = 5;
            this.Player4.TabStop = false;
            this.Player4.Text = "Player4";
            // 
            // Player4Value
            // 
            this.Player4Value.AutoSize = true;
            this.Player4Value.Location = new System.Drawing.Point(38, 42);
            this.Player4Value.Name = "Player4Value";
            this.Player4Value.Size = new System.Drawing.Size(30, 13);
            this.Player4Value.TabIndex = 2;
            this.Player4Value.Text = "0.0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Pocket";
            // 
            // Player4Pocket
            // 
            this.Player4Pocket.Location = new System.Drawing.Point(60, 18);
            this.Player4Pocket.Name = "Player4Pocket";
            this.Player4Pocket.Size = new System.Drawing.Size(40, 20);
            this.Player4Pocket.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Board";
            // 
            // Board
            // 
            this.Board.Location = new System.Drawing.Point(54, 13);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(100, 20);
            this.Board.TabIndex = 7;
            // 
            // DeadCardsLabel
            // 
            this.DeadCardsLabel.AutoSize = true;
            this.DeadCardsLabel.Location = new System.Drawing.Point(188, 16);
            this.DeadCardsLabel.Name = "DeadCardsLabel";
            this.DeadCardsLabel.Size = new System.Drawing.Size(60, 13);
            this.DeadCardsLabel.TabIndex = 8;
            this.DeadCardsLabel.Text = "DeadCards";
            // 
            // DeadCards
            // 
            this.DeadCards.Location = new System.Drawing.Point(254, 13);
            this.DeadCards.Name = "DeadCards";
            this.DeadCards.Size = new System.Drawing.Size(100, 20);
            this.DeadCards.TabIndex = 9;
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(191, 170);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 10;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ErrorInfo
            // 
            this.ErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorInfo.AutoSize = true;
            this.ErrorInfo.Location = new System.Drawing.Point(12, 142);
            this.ErrorInfo.Name = "ErrorInfo";
            this.ErrorInfo.Size = new System.Drawing.Size(0, 13);
            this.ErrorInfo.TabIndex = 11;
            this.ErrorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 205);
            this.Controls.Add(this.ErrorInfo);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.DeadCards);
            this.Controls.Add(this.DeadCardsLabel);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Player4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hand Odds";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Player4.ResumeLayout(false);
            this.Player4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Player1Pocket;
        private System.Windows.Forms.Label Player1Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Player2Value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Player2Pocket;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Player3Value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Player3Pocket;
        private System.Windows.Forms.GroupBox Player4;
        private System.Windows.Forms.Label Player4Value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Player4Pocket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Board;
        private System.Windows.Forms.Label DeadCardsLabel;
        private System.Windows.Forms.TextBox DeadCards;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label ErrorInfo;
    }
}

