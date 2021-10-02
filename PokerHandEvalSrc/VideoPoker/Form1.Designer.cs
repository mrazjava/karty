namespace VideoPoker
{
    /// <summary>
    /// 
    /// </summary>
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Coins = new System.Windows.Forms.Label();
            this.Card1 = new CardVectorImage.CardVector();
            this.HoldLabel1 = new System.Windows.Forms.Label();
            this.Card2 = new CardVectorImage.CardVector();
            this.Win = new System.Windows.Forms.Label();
            this.Card3 = new CardVectorImage.CardVector();
            this.HoldLabel3 = new System.Windows.Forms.Label();
            this.Card4 = new CardVectorImage.CardVector();
            this.HoldLabel4 = new System.Windows.Forms.Label();
            this.Card5 = new CardVectorImage.CardVector();
            this.EV = new System.Windows.Forms.Label();
            this.HoldLabel5 = new System.Windows.Forms.Label();
            this.Hold1 = new System.Windows.Forms.Button();
            this.Hold2 = new System.Windows.Forms.Button();
            this.Hold3 = new System.Windows.Forms.Button();
            this.Hold4 = new System.Windows.Forms.Button();
            this.Hold5 = new System.Windows.Forms.Button();
            this.Bet1 = new System.Windows.Forms.Button();
            this.Deal = new System.Windows.Forms.Button();
            this.BetMax = new System.Windows.Forms.Button();
            this.HoldLabel2 = new System.Windows.Forms.Label();
            this.Bet = new System.Windows.Forms.Label();
            this.StatusInfo = new System.Windows.Forms.Label();
            this.BestHold = new System.Windows.Forms.Button();
            this.CurrentEv = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.Controls.Add(this.Coins, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Win, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.EV, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bet, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatusInfo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bet1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.BetMax, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.BestHold, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.Deal, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.Hold3, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.Hold4, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.Hold5, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.Hold2, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.Hold1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Card2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card3, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card4, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.Card5, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.HoldLabel5, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.HoldLabel4, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.HoldLabel3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.HoldLabel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.HoldLabel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CurrentEv, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Coins
            // 
            this.Coins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Coins.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.Coins, 2);
            this.Coins.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coins.Location = new System.Drawing.Point(3, 0);
            this.Coins.Name = "Coins";
            this.Coins.Size = new System.Drawing.Size(150, 18);
            this.Coins.TabIndex = 10;
            this.Coins.Text = "Coins: 1000";
            this.Coins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card1
            // 
            this.Card1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Card1.AutoSize = true;
            this.Card1.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            this.Card1.Location = new System.Drawing.Point(48, 64);
            this.Card1.Name = "Card1";
            this.Card1.Size = new System.Drawing.Size(105, 121);
            this.Card1.TabIndex = 13;
            this.Card1.CardClick += new CardVectorImage.CardVector.CardClickHandler(this.Card1_CardClick);
            // 
            // HoldLabel1
            // 
            this.HoldLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoldLabel1.AutoSize = true;
            this.HoldLabel1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldLabel1.Location = new System.Drawing.Point(48, 43);
            this.HoldLabel1.Name = "HoldLabel1";
            this.HoldLabel1.Size = new System.Drawing.Size(105, 18);
            this.HoldLabel1.TabIndex = 18;
            this.HoldLabel1.Text = "Hold";
            this.HoldLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Card2
            // 
            this.Card2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Card2.AutoSize = true;
            this.Card2.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            this.Card2.Location = new System.Drawing.Point(159, 64);
            this.Card2.Name = "Card2";
            this.Card2.Size = new System.Drawing.Size(105, 121);
            this.Card2.TabIndex = 14;
            this.Card2.CardClick += new CardVectorImage.CardVector.CardClickHandler(this.Card2_CardClick);
            // 
            // Win
            // 
            this.Win.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Win.AutoSize = true;
            this.Win.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Win.Location = new System.Drawing.Point(159, 0);
            this.Win.Name = "Win";
            this.Win.Size = new System.Drawing.Size(105, 18);
            this.Win.TabIndex = 11;
            this.Win.Text = "Win: 5";
            this.Win.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card3
            // 
            this.Card3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Card3.AutoSize = true;
            this.Card3.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            this.Card3.Location = new System.Drawing.Point(270, 64);
            this.Card3.Name = "Card3";
            this.Card3.Size = new System.Drawing.Size(105, 121);
            this.Card3.TabIndex = 15;
            this.Card3.CardClick += new CardVectorImage.CardVector.CardClickHandler(this.Card3_CardClick);
            // 
            // HoldLabel3
            // 
            this.HoldLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoldLabel3.AutoSize = true;
            this.HoldLabel3.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldLabel3.Location = new System.Drawing.Point(270, 43);
            this.HoldLabel3.Name = "HoldLabel3";
            this.HoldLabel3.Size = new System.Drawing.Size(105, 18);
            this.HoldLabel3.TabIndex = 20;
            this.HoldLabel3.Text = "Hold";
            this.HoldLabel3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Card4
            // 
            this.Card4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Card4.AutoSize = true;
            this.Card4.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            this.Card4.Location = new System.Drawing.Point(381, 64);
            this.Card4.Name = "Card4";
            this.Card4.Size = new System.Drawing.Size(105, 121);
            this.Card4.TabIndex = 16;
            this.Card4.CardClick += new CardVectorImage.CardVector.CardClickHandler(this.Card4_CardClick);
            // 
            // HoldLabel4
            // 
            this.HoldLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoldLabel4.AutoSize = true;
            this.HoldLabel4.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldLabel4.Location = new System.Drawing.Point(381, 43);
            this.HoldLabel4.Name = "HoldLabel4";
            this.HoldLabel4.Size = new System.Drawing.Size(105, 18);
            this.HoldLabel4.TabIndex = 21;
            this.HoldLabel4.Text = "Hold";
            this.HoldLabel4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Card5
            // 
            this.Card5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Card5.AutoSize = true;
            this.Card5.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            this.Card5.Location = new System.Drawing.Point(492, 64);
            this.Card5.Name = "Card5";
            this.Card5.Size = new System.Drawing.Size(105, 121);
            this.Card5.TabIndex = 17;
            this.Card5.CardClick += new CardVectorImage.CardVector.CardClickHandler(this.Card5_CardClick);
            // 
            // EV
            // 
            this.EV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EV.AutoEllipsis = true;
            this.EV.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.EV, 2);
            this.EV.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EV.Location = new System.Drawing.Point(492, 0);
            this.EV.Name = "EV";
            this.EV.Size = new System.Drawing.Size(159, 18);
            this.EV.TabIndex = 9;
            this.EV.Text = "EV: 0.84";
            this.EV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HoldLabel5
            // 
            this.HoldLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoldLabel5.AutoSize = true;
            this.HoldLabel5.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldLabel5.Location = new System.Drawing.Point(492, 43);
            this.HoldLabel5.Name = "HoldLabel5";
            this.HoldLabel5.Size = new System.Drawing.Size(105, 18);
            this.HoldLabel5.TabIndex = 22;
            this.HoldLabel5.Text = "Hold";
            this.HoldLabel5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Hold1
            // 
            this.Hold1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hold1.AutoSize = true;
            this.Hold1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hold1.Location = new System.Drawing.Point(48, 191);
            this.Hold1.Name = "Hold1";
            this.Hold1.Size = new System.Drawing.Size(105, 25);
            this.Hold1.TabIndex = 1;
            this.Hold1.Text = "Hold";
            this.Hold1.UseVisualStyleBackColor = true;
            this.Hold1.Click += new System.EventHandler(this.Hold1_Click);
            // 
            // Hold2
            // 
            this.Hold2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hold2.AutoSize = true;
            this.Hold2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hold2.Location = new System.Drawing.Point(159, 191);
            this.Hold2.Name = "Hold2";
            this.Hold2.Size = new System.Drawing.Size(105, 25);
            this.Hold2.TabIndex = 2;
            this.Hold2.Text = "Hold";
            this.Hold2.UseVisualStyleBackColor = true;
            this.Hold2.Click += new System.EventHandler(this.Hold2_Click);
            // 
            // Hold3
            // 
            this.Hold3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hold3.AutoSize = true;
            this.Hold3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hold3.Location = new System.Drawing.Point(270, 191);
            this.Hold3.Name = "Hold3";
            this.Hold3.Size = new System.Drawing.Size(105, 25);
            this.Hold3.TabIndex = 3;
            this.Hold3.Text = "Hold";
            this.Hold3.UseVisualStyleBackColor = true;
            this.Hold3.Click += new System.EventHandler(this.Hold3_Click);
            // 
            // Hold4
            // 
            this.Hold4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hold4.AutoSize = true;
            this.Hold4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hold4.Location = new System.Drawing.Point(381, 191);
            this.Hold4.Name = "Hold4";
            this.Hold4.Size = new System.Drawing.Size(105, 25);
            this.Hold4.TabIndex = 4;
            this.Hold4.Text = "Hold";
            this.Hold4.UseVisualStyleBackColor = true;
            this.Hold4.Click += new System.EventHandler(this.Hold4_Click);
            // 
            // Hold5
            // 
            this.Hold5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hold5.AutoSize = true;
            this.Hold5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hold5.Location = new System.Drawing.Point(492, 191);
            this.Hold5.Name = "Hold5";
            this.Hold5.Size = new System.Drawing.Size(105, 25);
            this.Hold5.TabIndex = 5;
            this.Hold5.Text = "Hold";
            this.Hold5.UseVisualStyleBackColor = true;
            this.Hold5.Click += new System.EventHandler(this.Hold5_Click);
            // 
            // Bet1
            // 
            this.Bet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Bet1.AutoSize = true;
            this.Bet1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bet1.Location = new System.Drawing.Point(48, 229);
            this.Bet1.Name = "Bet1";
            this.Bet1.Size = new System.Drawing.Size(105, 28);
            this.Bet1.TabIndex = 6;
            this.Bet1.Text = "Bet 1";
            this.Bet1.UseVisualStyleBackColor = true;
            this.Bet1.Click += new System.EventHandler(this.Bet1_Click);
            // 
            // Deal
            // 
            this.Deal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Deal.AutoSize = true;
            this.Deal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deal.Location = new System.Drawing.Point(492, 229);
            this.Deal.Name = "Deal";
            this.Deal.Size = new System.Drawing.Size(105, 28);
            this.Deal.TabIndex = 8;
            this.Deal.Text = "Deal";
            this.Deal.UseVisualStyleBackColor = true;
            this.Deal.Click += new System.EventHandler(this.Deal_Click);
            // 
            // BetMax
            // 
            this.BetMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BetMax.AutoSize = true;
            this.BetMax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BetMax.Location = new System.Drawing.Point(159, 229);
            this.BetMax.Name = "BetMax";
            this.BetMax.Size = new System.Drawing.Size(105, 28);
            this.BetMax.TabIndex = 7;
            this.BetMax.Text = "Max Bet";
            this.BetMax.UseVisualStyleBackColor = true;
            this.BetMax.Click += new System.EventHandler(this.BetMax_Click);
            // 
            // HoldLabel2
            // 
            this.HoldLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoldLabel2.AutoSize = true;
            this.HoldLabel2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldLabel2.Location = new System.Drawing.Point(159, 43);
            this.HoldLabel2.Name = "HoldLabel2";
            this.HoldLabel2.Size = new System.Drawing.Size(105, 18);
            this.HoldLabel2.TabIndex = 23;
            this.HoldLabel2.Text = "Hold";
            this.HoldLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Bet
            // 
            this.Bet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Bet.AutoSize = true;
            this.Bet.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bet.Location = new System.Drawing.Point(381, 0);
            this.Bet.Name = "Bet";
            this.Bet.Size = new System.Drawing.Size(105, 18);
            this.Bet.TabIndex = 12;
            this.Bet.Text = "Bet: 5";
            this.Bet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusInfo
            // 
            this.StatusInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusInfo.AutoEllipsis = true;
            this.StatusInfo.AutoSize = true;
            this.StatusInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusInfo.Location = new System.Drawing.Point(270, 0);
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.Size = new System.Drawing.Size(105, 18);
            this.StatusInfo.TabIndex = 24;
            this.StatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BestHold
            // 
            this.BestHold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BestHold.AutoSize = true;
            this.BestHold.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestHold.Location = new System.Drawing.Point(381, 229);
            this.BestHold.Name = "BestHold";
            this.BestHold.Size = new System.Drawing.Size(105, 28);
            this.BestHold.TabIndex = 25;
            this.BestHold.Text = "Best Hold";
            this.BestHold.UseVisualStyleBackColor = true;
            this.BestHold.Click += new System.EventHandler(this.BestHold_Click);
            // 
            // CurrentEv
            // 
            this.CurrentEv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentEv.AutoEllipsis = true;
            this.CurrentEv.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.CurrentEv, 2);
            this.CurrentEv.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentEv.Location = new System.Drawing.Point(492, 18);
            this.CurrentEv.Name = "CurrentEv";
            this.CurrentEv.Size = new System.Drawing.Size(159, 18);
            this.CurrentEv.TabIndex = 26;
            this.CurrentEv.Text = "Current EV: ";
            this.CurrentEv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Jacks or Better Trainer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Hold1;
        private System.Windows.Forms.Button Hold2;
        private System.Windows.Forms.Button Hold3;
        private System.Windows.Forms.Button Hold4;
        private System.Windows.Forms.Button Hold5;
        private System.Windows.Forms.Button Bet1;
        private System.Windows.Forms.Button BetMax;
        private System.Windows.Forms.Button Deal;
        private System.Windows.Forms.Label EV;
        private System.Windows.Forms.Label Coins;
        private System.Windows.Forms.Label Win;
        private System.Windows.Forms.Label Bet;
        private CardVectorImage.CardVector Card1;
        private CardVectorImage.CardVector Card2;
        private CardVectorImage.CardVector Card3;
        private CardVectorImage.CardVector Card4;
        private CardVectorImage.CardVector Card5;
        private System.Windows.Forms.Label HoldLabel1;
        private System.Windows.Forms.Label HoldLabel3;
        private System.Windows.Forms.Label HoldLabel4;
        private System.Windows.Forms.Label HoldLabel5;
        private System.Windows.Forms.Label HoldLabel2;
        private System.Windows.Forms.Label StatusInfo;
        private System.Windows.Forms.Button BestHold;
        private System.Windows.Forms.Label CurrentEv;



    }
}

