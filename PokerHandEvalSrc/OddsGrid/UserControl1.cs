// This control is covered by the LGPL Gnu license. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HoldemHand;

namespace OddsGrid
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OddsGrid : UserControl
    {
        private string pocket = "";
        private string board = "";

        /// <summary>
        /// 
        /// </summary>
        public string Pocket
        {
            get { return pocket; }
            set { pocket = value; UpdateContents(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Board
        {
            get { return board; }
            set { board = value; UpdateContents(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string FormatPercent(double v)
        {
            if (v != 0.0)
            {
                if (v * 100.0 >= 1.0)
                    return string.Format("{0:##0.0}%", v * 100.0);
                else
                    return "<1%";
            }
            return "n/a";
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateContents()
        {
            if (!this.DesignMode)
            {
                int count = 0;
                double playerwins = 0.0;
                double opponentwins = 0.0;
                double[] player = new double[9];
                double[] opponent = new double[9];

                if (!Hand.ValidateHand(Pocket + " " + Board))
                {
                    ClearGrid();
                    return;
                }
                Hand.ParseHand(Pocket + " " + Board, ref count);

                // Don't allow these configurations because of calculation time.
                if (count == 0 || count == 1 || count == 3 || count == 4 || count > 7)
                {
                    ClearGrid();
                    return;
                }

                Hand.HandPlayerOpponentOdds(Pocket, Board, ref player, ref opponent);

                for (int i = 0; i < 9; i++)
                {
                    switch ((Hand.HandTypes)i)
                    {
                        case Hand.HandTypes.HighCard:
                            PlayerHighCard.Text = FormatPercent(player[i]);
                            OpponentHighCard.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.Pair:
                            PlayerPair.Text = FormatPercent(player[i]);
                            OpponentPair.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.TwoPair:
                            PlayerTwoPair.Text = FormatPercent(player[i]);
                            OpponentTwoPair.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.Trips:
                            Player3ofaKind.Text = FormatPercent(player[i]);
                            Opponent3ofaKind.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.Straight:
                            PlayerStraight.Text = FormatPercent(player[i]);
                            OpponentStraight.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.Flush:
                            PlayerFlush.Text = FormatPercent(player[i]);
                            OpponentFlush.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.FullHouse:
                            PlayerFullhouse.Text = FormatPercent(player[i]);
                            OpponentFullhouse.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.FourOfAKind:
                            Player4ofaKind.Text = FormatPercent(player[i]);
                            Opponent4ofaKind.Text = FormatPercent(opponent[i]);
                            break;
                        case Hand.HandTypes.StraightFlush:
                            PlayerStraightFlush.Text = FormatPercent(player[i]);
                            OpponentStraightFlush.Text = FormatPercent(opponent[i]);
                            break;
                    }
                    playerwins += player[i] * 100.0;
                    opponentwins += opponent[i] * 100.0;
                }

                PlayerWin.Text = string.Format("{0:##0.0}%", playerwins);
                OpponentWin.Text = string.Format("{0:##0.0}%", opponentwins);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearGrid()
        {
            PlayerHighCard.Text = "";
            OpponentHighCard.Text = "";
            PlayerPair.Text = "";
            OpponentPair.Text = "";
            PlayerTwoPair.Text = "";
            OpponentTwoPair.Text = "";
            Player3ofaKind.Text = "";
            Opponent3ofaKind.Text = "";
            PlayerStraight.Text = "";
            OpponentStraight.Text = "";
            PlayerFlush.Text = "";
            OpponentFlush.Text = "";
            PlayerFullhouse.Text = "";
            OpponentFullhouse.Text = "";
            Player4ofaKind.Text = "";
            Opponent4ofaKind.Text = "";
            PlayerStraightFlush.Text = "";
            OpponentStraightFlush.Text = "";
            PlayerWin.Text = "";
            OpponentWin.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        public OddsGrid()
        {
            InitializeComponent();
        }
    }
}