// This application is covered by the LGPL Gnu license. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HoldemHand;

namespace HandOdds
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private string[] PlayerText
        {
            get
            {
                string[] player = new string[4];
                player[0] = Player1Pocket.Text;
                player[1] = Player2Pocket.Text;
                player[2] = Player3Pocket.Text;
                player[3] = Player4Pocket.Text;
                return player;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void SetPlayerValue(int index, double value)
        {
            switch (index)
            {
                case 0:
                    Player1Value.Text = string.Format("{0:#0.0}%", value * 100.0);
                    break;
                case 1:
                    Player2Value.Text = string.Format("{0:#0.0}%", value * 100.0);
                    break;
                case 2:
                    Player3Value.Text = string.Format("{0:#0.0}%", value * 100.0);
                    break;
                case 3:
                    Player4Value.Text = string.Format("{0:#0.0}%", value * 100.0);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_Click(object sender, EventArgs e)
        {
            HiPerfTimer timer = new HiPerfTimer();
            int count = 0, index = 0;
            int[] playerIndex = { -1, -1, -1, -1 };
            int[] pocketIndex = { -1, -1, -1, -1 };

            foreach (string pocket in PlayerText)
            {
                if (pocket != "")
                {
                    playerIndex[count] = count;
                    pocketIndex[count++] = index;
                }
                index++;
            }

            string[] pocketCards = new string[count];

            for (int i = 0; i < count; i++)
            {
                pocketCards[i] = PlayerText[pocketIndex[i]];
            }

            long[] wins = new long[count];
            long[] losses = new long[count];
            long[] ties = new long[count];
            long totalhands = 0;

            try
            {
                timer.Start();
                Hand.HandOdds(pocketCards, Board.Text, DeadCards.Text, wins, ties, losses, ref totalhands);
                double duration = timer.Duration;

                System.Diagnostics.Debug.Assert(totalhands != 0);

                if (totalhands != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        SetPlayerValue(pocketIndex[i], (((double)wins[i]) + ((double) ties[i])/2.0) / ((double)totalhands));
                    }
                }

                ErrorInfo.Text = string.Format("{0:###,###,###,###} hands evaluated in {1:#0.###} seconds.", totalhands, duration);
                ErrorInfo.ForeColor = Color.Black;

            }
            catch (ArgumentException ae)
            {
                ErrorInfo.Text = "Unable to process: " + ae.Message + ".";
                ErrorInfo.ForeColor = Color.Red;
            }
            catch
            {
                ErrorInfo.Text = "Unable to process: Please check pocket, board, and dead card definitions for errors.";
                ErrorInfo.ForeColor = Color.Red;
            }
        }

    }
}