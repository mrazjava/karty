using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using HoldemHand;
using System.Diagnostics;

namespace Benchmark
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        /// <exclude/>
		private Thread tid1 = null;
        /// <exclude/>
		private object lockValue = new object();
       
        /// <exclude/>
        private delegate void SetLabelTextDelegate(string s);
        /// <exclude/>
		private System.Windows.Forms.Button Benchmark;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label FiveCardHandType;
        private Label label4;
        private Label FiveCardHandTypeInline;
        private Label label5;
        private Label label6;
        private Label SevenCardHandType;
        private Label SevenCardHandTypeInlined;
        private Label label7;
        private Label FiveCardEvaluate;
        private Label label8;
        private Label SevenCardEvaluate;
        private Label label9;
        private Label FiveCardEvaluteInlined;
        private Label label11;
        private Label SevenCardEvaluteInlined;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <exclude/>
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.Benchmark = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FiveCardHandType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FiveCardHandTypeInline = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SevenCardHandType = new System.Windows.Forms.Label();
            this.SevenCardHandTypeInlined = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FiveCardEvaluate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SevenCardEvaluate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FiveCardEvaluteInlined = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SevenCardEvaluteInlined = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Benchmark
            // 
            this.Benchmark.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Benchmark.Location = new System.Drawing.Point(168, 204);
            this.Benchmark.Name = "Benchmark";
            this.Benchmark.Size = new System.Drawing.Size(75, 23);
            this.Benchmark.TabIndex = 1;
            this.Benchmark.Text = "Start";
            this.Benchmark.Click += new System.EventHandler(this.Benchmark_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FiveCardHandType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FiveCardHandTypeInline, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.SevenCardHandType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SevenCardHandTypeInlined, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.FiveCardEvaluate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.SevenCardEvaluate, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.FiveCardEvaluteInlined, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.SevenCardEvaluteInlined, 1, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 189);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benchmark Test";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Result";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "5-Card HandType (Hands Iterator)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FiveCardHandType
            // 
            this.FiveCardHandType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiveCardHandType.AutoSize = true;
            this.FiveCardHandType.Location = new System.Drawing.Point(207, 21);
            this.FiveCardHandType.Name = "FiveCardHandType";
            this.FiveCardHandType.Size = new System.Drawing.Size(197, 19);
            this.FiveCardHandType.TabIndex = 3;
            this.FiveCardHandType.Text = "N/A";
            this.FiveCardHandType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "5-Card HandType (Inlined Interation)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FiveCardHandTypeInline
            // 
            this.FiveCardHandTypeInline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiveCardHandTypeInline.AutoSize = true;
            this.FiveCardHandTypeInline.Location = new System.Drawing.Point(207, 41);
            this.FiveCardHandTypeInline.Name = "FiveCardHandTypeInline";
            this.FiveCardHandTypeInline.Size = new System.Drawing.Size(197, 19);
            this.FiveCardHandTypeInline.TabIndex = 5;
            this.FiveCardHandTypeInline.Text = "N/A";
            this.FiveCardHandTypeInline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "7-Card HandType (Hands Iterator)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "7-Card HandType (Inlined Iteration)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenCardHandType
            // 
            this.SevenCardHandType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenCardHandType.AutoSize = true;
            this.SevenCardHandType.Location = new System.Drawing.Point(207, 61);
            this.SevenCardHandType.Name = "SevenCardHandType";
            this.SevenCardHandType.Size = new System.Drawing.Size(197, 19);
            this.SevenCardHandType.TabIndex = 8;
            this.SevenCardHandType.Text = "N/A";
            this.SevenCardHandType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenCardHandTypeInlined
            // 
            this.SevenCardHandTypeInlined.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenCardHandTypeInlined.AutoSize = true;
            this.SevenCardHandTypeInlined.Location = new System.Drawing.Point(207, 81);
            this.SevenCardHandTypeInlined.Name = "SevenCardHandTypeInlined";
            this.SevenCardHandTypeInlined.Size = new System.Drawing.Size(197, 19);
            this.SevenCardHandTypeInlined.TabIndex = 9;
            this.SevenCardHandTypeInlined.Text = "N/A";
            this.SevenCardHandTypeInlined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "5-Card Evaluate() (Hands Iterator)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FiveCardEvaluate
            // 
            this.FiveCardEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiveCardEvaluate.AutoSize = true;
            this.FiveCardEvaluate.Location = new System.Drawing.Point(207, 101);
            this.FiveCardEvaluate.Name = "FiveCardEvaluate";
            this.FiveCardEvaluate.Size = new System.Drawing.Size(197, 19);
            this.FiveCardEvaluate.TabIndex = 11;
            this.FiveCardEvaluate.Text = "N/A";
            this.FiveCardEvaluate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "7-Card Evaluate() (Hands Iterator)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenCardEvaluate
            // 
            this.SevenCardEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenCardEvaluate.AutoSize = true;
            this.SevenCardEvaluate.Location = new System.Drawing.Point(207, 141);
            this.SevenCardEvaluate.Name = "SevenCardEvaluate";
            this.SevenCardEvaluate.Size = new System.Drawing.Size(197, 19);
            this.SevenCardEvaluate.TabIndex = 13;
            this.SevenCardEvaluate.Text = "N/A";
            this.SevenCardEvaluate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "5-Card Evaluate() (Inlined Iteration)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FiveCardEvaluteInlined
            // 
            this.FiveCardEvaluteInlined.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FiveCardEvaluteInlined.AutoSize = true;
            this.FiveCardEvaluteInlined.Location = new System.Drawing.Point(207, 121);
            this.FiveCardEvaluteInlined.Name = "FiveCardEvaluteInlined";
            this.FiveCardEvaluteInlined.Size = new System.Drawing.Size(197, 19);
            this.FiveCardEvaluteInlined.TabIndex = 15;
            this.FiveCardEvaluteInlined.Text = "N/A";
            this.FiveCardEvaluteInlined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 27);
            this.label11.TabIndex = 16;
            this.label11.Text = "7-Card Evaluate() (Inlined Iteration)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SevenCardEvaluteInlined
            // 
            this.SevenCardEvaluteInlined.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SevenCardEvaluteInlined.AutoSize = true;
            this.SevenCardEvaluteInlined.Location = new System.Drawing.Point(207, 161);
            this.SevenCardEvaluteInlined.Name = "SevenCardEvaluteInlined";
            this.SevenCardEvaluteInlined.Size = new System.Drawing.Size(197, 27);
            this.SevenCardEvaluteInlined.TabIndex = 17;
            this.SevenCardEvaluteInlined.Text = "N/A";
            this.SevenCardEvaluteInlined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(410, 239);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Benchmark);
            this.Name = "Form1";
            this.Text = "Benchmark";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        /// <exclude/>
		private void FiveCardHandTypeLabel(string s)
		{
			// Check if we need to call BeginInvoke.
			if (InvokeRequired)
			{
                BeginInvoke(new SetLabelTextDelegate(FiveCardHandTypeLabel), new object[] { s });
				return;
			}
			FiveCardHandType.Text = s;
		}

        /// <exclude/>
        private void FiveCardHandTypeInlineLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(FiveCardHandTypeInlineLabel), new object[] { s });
                return;
            }
            FiveCardHandTypeInline.Text = s;
        }

        /// <exclude/>
        private void SevenCardHandTypeLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(SevenCardHandTypeLabel), new object[] { s });
                return;
            }
            SevenCardHandType.Text = s;
        }

        /// <exclude/>
        private void SevenCardHandTypeInlinedLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(SevenCardHandTypeInlinedLabel), new object[] { s });
                return;
            }
            SevenCardHandTypeInlined.Text = s;
        }

        /// <exclude/>
        private void FiveCardEvaluateLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(FiveCardEvaluateLabel), new object[] { s });
                return;
            }
            FiveCardEvaluate.Text = s;
        }

        /// <exclude/>
        private void FiveCardEvaluateInlinedLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(FiveCardEvaluateInlinedLabel), new object[] { s });
                return;
            }
            FiveCardEvaluteInlined.Text = s;
        }

        /// <exclude/>
        private void SevenCardEvaluateLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(SevenCardEvaluateLabel), new object[] { s });
                return;
            }
            SevenCardEvaluate.Text = s;
        }

        /// <exclude/>
        private void SevenCardEvaluateInlinedLabel(string s)
        {
            // Check if we need to call BeginInvoke.
            if (InvokeRequired)
            {
                BeginInvoke(new SetLabelTextDelegate(SevenCardEvaluateInlinedLabel), new object[] { s });
                return;
            }
            SevenCardEvaluteInlined.Text = s;
        }

        /// <exclude/>
		public void TestThread()
		{
			lock (lockValue)
			{
				HiPerfTimer timer = new HiPerfTimer();
				string output = "";

                timer.Start();
                long count1 = ValidateEnumerate5();
                double duration1 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count1 / duration1);
                FiveCardHandTypeLabel(output);

                timer.Start();
                long count2 = InlineValidateEnumerate5();
                double duration2 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count2 / duration2);
                FiveCardHandTypeInlineLabel(output);

                timer.Start();
                long count3 = ValidateEnumerate7();
                double duration3 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count3 / duration3);
                SevenCardHandTypeLabel(output);

                timer.Start();
                long count4 = InlineValidateEnumerate7();
                double duration4 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count4 / duration4);
                SevenCardHandTypeInlinedLabel(output);

                timer.Start();
                count4 = FiveCardEvaluateBenchmark();
                duration4 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count4 / duration4);
                FiveCardEvaluateLabel(output);

                timer.Start();
                count4 = FiveCardEvaluateBenchmarkInline();
                duration4 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count4 / duration4);
                FiveCardEvaluateInlinedLabel(output);

                timer.Start();
                count4 = SevenCardEvaluateBenchmark();
                duration4 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count4 / duration4);
                SevenCardEvaluateLabel(output);

                timer.Start();
                count4 = SevenCardEvaluateInlinedBenchmark();
                duration4 = timer.Duration;
                output = string.Format("{0:###,###,###,###} hands per second", count4 / duration4);
                SevenCardEvaluateInlinedLabel(output);
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private long FiveCardEvaluateBenchmark()
        {
            long count = 0;
            uint handval = 0U;
            foreach (ulong handmask in Hand.Hands(5))
            {
                handval = Hand.Evaluate(handmask, 5);
                count++;
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long FiveCardEvaluateBenchmarkInline()
        {
            int _i1, _i2, _i3, _i4, _i5;
            ulong _card1, _n2, _n3, _n4;
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;
            uint handval;

            // Iterate through all possible 5 card hands.
            for (_i1 = Hand.NumberOfCards - 1; _i1 >= 0; _i1--)
            {
                _card1 = Hand.CardMasksTable[_i1];
                for (_i2 = _i1 - 1; _i2 >= 0; _i2--)
                {
                    _n2 = _card1 | Hand.CardMasksTable[_i2];
                    for (_i3 = _i2 - 1; _i3 >= 0; _i3--)
                    {
                        _n3 = _n2 | Hand.CardMasksTable[_i3];
                        for (_i4 = _i3 - 1; _i4 >= 0; _i4--)
                        {
                            _n4 = _n3 | Hand.CardMasksTable[_i4];
                            for (_i5 = _i4 - 1; _i5 >= 0; _i5--)
                            {
                                handval = Hand.Evaluate(_n4 | Hand.CardMasksTable[_i5], 5);
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        private long SevenCardEvaluateBenchmark()
        {
            long count = 0;
            uint handval = 0U;
            foreach (ulong handmask in Hand.Hands(7))
            {
                handval = Hand.Evaluate(handmask);
                count++;
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long SevenCardEvaluateInlinedBenchmark()
        {
            int _i1, _i2, _i3, _i4, _i5, _i6, _i7;
            ulong _card1, _n2, _n3, _n4, _n5, _n6;
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;
            uint handval;

            // Iterate through all possible 7 card hands
            for (_i1 = Hand.NumberOfCards - 1; _i1 >= 0; _i1--)
            {
                _card1 = Hand.CardMasksTable[_i1];
                for (_i2 = _i1 - 1; _i2 >= 0; _i2--)
                {
                    _n2 = _card1 | Hand.CardMasksTable[_i2];
                    for (_i3 = _i2 - 1; _i3 >= 0; _i3--)
                    {
                        _n3 = _n2 | Hand.CardMasksTable[_i3];
                        for (_i4 = _i3 - 1; _i4 >= 0; _i4--)
                        {
                            _n4 = _n3 | Hand.CardMasksTable[_i4];
                            for (_i5 = _i4 - 1; _i5 >= 0; _i5--)
                            {
                                _n5 = _n4 | Hand.CardMasksTable[_i5];
                                for (_i6 = _i5 - 1; _i6 >= 0; _i6--)
                                {
                                    _n6 = _n5 | Hand.CardMasksTable[_i6];
                                    for (_i7 = _i6 - 1; _i7 >= 0; _i7--)
                                    {
                                        handval = Hand.Evaluate(_n6 | Hand.CardMasksTable[_i7], 7);
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }

        /// <exclude/>
		private void Benchmark_Click(object sender, System.EventArgs e)
		{
            if (tid1 != null && tid1.IsAlive) return;

            FiveCardHandType.Text = "";
            FiveCardHandTypeInline.Text = "";
            SevenCardHandType.Text = "";
            SevenCardHandTypeInlined.Text = "";
            FiveCardEvaluate.Text = "";
            FiveCardEvaluteInlined.Text = "";
            SevenCardEvaluate.Text = "";
            this.SevenCardEvaluteInlined.Text = "";
			
			tid1 = new Thread(new ThreadStart(TestThread));
            tid1.IsBackground = true;
            tid1.Priority = ThreadPriority.Highest;
			tid1.Start();
		
		}

        /// <exclude/>
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

        #region Validation Functions
        /// <summary>
        /// Equivent to ValidateEnumerate5 with much of the code manually inlined.
        /// Surprisingly this makes about a significant difference is speed. 
        /// </summary>
        /// <returns>count of hands evaluated</returns>
        public static long InlineValidateEnumerate5()
        {
            int _i1, _i2, _i3, _i4, _i5;
            ulong _card1, _n2, _n3, _n4, _n5;
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;

            // Iterate through all possible 5 card hands.
            for (_i1 = Hand.NumberOfCards - 1; _i1 >= 0; _i1--)
            {
                _card1 = Hand.CardMasksTable[_i1];
                for (_i2 = _i1 - 1; _i2 >= 0; _i2--)
                {
                    _n2 = _card1 | Hand.CardMasksTable[_i2];
                    for (_i3 = _i2 - 1; _i3 >= 0; _i3--)
                    {
                        _n3 = _n2 | Hand.CardMasksTable[_i3];
                        for (_i4 = _i3 - 1; _i4 >= 0; _i4--)
                        {
                            _n4 = _n3 | Hand.CardMasksTable[_i4];
                            for (_i5 = _i4 - 1; _i5 >= 0; _i5--)
                            {
                                _n5 = _n4 | Hand.CardMasksTable[_i5];
                                handtypes[(int)Hand.EvaluateType(_n5, 5)]++;
                                count++;
                            }
                        }
                    }
                }
            }

            // Validate Results
            Debug.Assert(handtypes[(int)Hand.HandTypes.HighCard] == 1302540 &&
                handtypes[(int)Hand.HandTypes.Pair] == 1098240 &&
                handtypes[(int)Hand.HandTypes.TwoPair] == 123552 &&
                handtypes[(int)Hand.HandTypes.Trips] == 54912 &&
                handtypes[(int)Hand.HandTypes.Straight] == 10200 &&
                handtypes[(int)Hand.HandTypes.Flush] == 5108 &&
                handtypes[(int)Hand.HandTypes.FullHouse] == 3744 &&
                handtypes[(int)Hand.HandTypes.FourOfAKind] == 624 &&
                handtypes[(int)Hand.HandTypes.StraightFlush] == 40 &&
                count == 2598960);
            return count;
        }

        /// <summary>
        /// This method iterates through all possible 5 card hands and validates the
        /// result with known hand distributions. This is used to validate the hand evaluation
        /// functions.
        /// </summary>
        /// <returns>count of hands evaluated</returns>
        public static long ValidateEnumerate5()
        {
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;

            // Iterate through all possible 5 card hands
            foreach (ulong mask in Hand.Hands(5))
            {
                handtypes[(int)Hand.EvaluateType(mask, 5)]++;
                count++;
            }

            // Validate results.
            Debug.Assert(handtypes[(int)Hand.HandTypes.HighCard] == 1302540);
            Debug.Assert(handtypes[(int)Hand.HandTypes.Pair] == 1098240);
            Debug.Assert(handtypes[(int)Hand.HandTypes.TwoPair] == 123552);
            Debug.Assert(handtypes[(int)Hand.HandTypes.Trips] == 54912);
            Debug.Assert(handtypes[(int)Hand.HandTypes.Straight] == 10200);
            Debug.Assert(handtypes[(int)Hand.HandTypes.Flush] == 5108);
            Debug.Assert(handtypes[(int)Hand.HandTypes.FullHouse] == 3744);
            Debug.Assert(handtypes[(int)Hand.HandTypes.FourOfAKind] == 624);
            Debug.Assert(handtypes[(int)Hand.HandTypes.StraightFlush] == 40);
            Debug.Assert(count == 2598960);
            return count;
        }


        /// <summary>
        /// This method iterates through all possible 7 card hands and validates the
        /// result with known hand distributions. This is used to validate the hand evaluation
        /// functions.
        /// </summary>
        /// <returns>count of hands evaluated</returns>
        public static long ValidateEnumerate7()
        {
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;

            // Iterate through all possible 7 card hands
            foreach (ulong mask in Hand.Hands(7))
            {
                handtypes[(int)Hand.EvaluateType(mask, 7)]++;
                count++;
            }

            // Validate results.
            Debug.Assert(handtypes[(int)Hand.HandTypes.HighCard] == 23294460 &&
                handtypes[(int)Hand.HandTypes.Pair] == 58627800 &&
                handtypes[(int)Hand.HandTypes.TwoPair] == 31433400 &&
                handtypes[(int)Hand.HandTypes.Trips] == 6461620 &&
                handtypes[(int)Hand.HandTypes.Straight] == 6180020 &&
                handtypes[(int)Hand.HandTypes.Flush] == 4047644 &&
                handtypes[(int)Hand.HandTypes.FullHouse] == 3473184 &&
                handtypes[(int)Hand.HandTypes.FourOfAKind] == 224848 &&
                handtypes[(int)Hand.HandTypes.StraightFlush] == 41584 &&
                count == 133784560);
            return count;
        }

        /// <summary>
        /// Equivent to ValidateEnumerate7 with much of the code manually inlined.
        /// Surprisingly this makes about a significant difference is speed.
        /// </summary>
        public static long InlineValidateEnumerate7()
        {
            int _i1, _i2, _i3, _i4, _i5, _i6, _i7;
            ulong _card1, _n2, _n3, _n4, _n5, _n6;
            int[] handtypes = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int count = 0;

            // Iterate through all possible 7 card hands
            for (_i1 = Hand.NumberOfCards - 1; _i1 >= 0; _i1--)
            {
                _card1 = Hand.CardMasksTable[_i1];
                for (_i2 = _i1 - 1; _i2 >= 0; _i2--)
                {
                    _n2 = _card1 | Hand.CardMasksTable[_i2];
                    for (_i3 = _i2 - 1; _i3 >= 0; _i3--)
                    {
                        _n3 = _n2 | Hand.CardMasksTable[_i3];
                        for (_i4 = _i3 - 1; _i4 >= 0; _i4--)
                        {
                            _n4 = _n3 | Hand.CardMasksTable[_i4];
                            for (_i5 = _i4 - 1; _i5 >= 0; _i5--)
                            {
                                _n5 = _n4 | Hand.CardMasksTable[_i5];
                                for (_i6 = _i5 - 1; _i6 >= 0; _i6--)
                                {
                                    _n6 = _n5 | Hand.CardMasksTable[_i6];
                                    for (_i7 = _i6 - 1; _i7 >= 0; _i7--)
                                    {
                                        handtypes[(int)Hand.EvaluateType(_n6 | Hand.CardMasksTable[_i7], 7)]++;
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Validate results
            Debug.Assert(handtypes[(int)Hand.HandTypes.HighCard] == 23294460 &&
                handtypes[(int)Hand.HandTypes.Pair] == 58627800 &&
                handtypes[(int)Hand.HandTypes.TwoPair] == 31433400 &&
                handtypes[(int)Hand.HandTypes.Trips] == 6461620 &&
                handtypes[(int)Hand.HandTypes.Straight] == 6180020 &&
                handtypes[(int)Hand.HandTypes.Flush] == 4047644 &&
                handtypes[(int)Hand.HandTypes.FullHouse] == 3473184 &&
                handtypes[(int)Hand.HandTypes.FourOfAKind] == 224848 &&
                handtypes[(int)Hand.HandTypes.StraightFlush] == 41584 &&
                count == 133784560);

            return count;
        }
        #endregion
	}
}
