// This application is covered by the LGPL Gnu license. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OddsGridApp
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketCards_TextChanged(object sender, EventArgs e)
        {
            this.oddsGrid1.Pocket = this.PocketCards.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Board_TextChanged(object sender, EventArgs e)
        {
            this.oddsGrid1.Board = this.Board.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.oddsGrid1.Pocket = this.PocketCards.Text;
            this.oddsGrid1.Board = this.Board.Text;
        }
    }
}