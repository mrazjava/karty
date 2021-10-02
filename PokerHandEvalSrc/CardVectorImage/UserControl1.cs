// This control is based on the SVG Cards 1.1 created by 
// David BELLOT (http://david.bellot.free.fr/svg-cards/).
// His card files are covered by the LGPL Gnu license. 
// Since this control is derived from David Bellot's card image set, 
// it too is licensed by LGPL. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CardVectorImage
{
    /// <summary>
    /// Card Vector Control.
    /// </summary>
    public partial class CardVector : UserControl
    {
        /// <exclude/>
        private SVGCards.Deck image = new SVGCards.Deck();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public CardVector()
        {
            InitializeComponent();
        }

        /// <exclude/>
        private CardType card = CardType.BackRedFlower;

        /// <summary>
        /// Used to set or get the current card displayed
        /// </summary>
        public CardType Card
        {
            get { return card; }
            set
            {
                card = value;
                // Clear previous state
                for (int i = 0; i < 60; i++)
                {
                    this.SetCardVisiblity((CardType)i, false);
                }
                SetCardVisiblity(value, true);
                Invalidate();
            }
        }

        /// <summary>
        /// Load the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardVector_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Paint the card into the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardVector_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush bkg = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(bkg, ClientRectangle);
            bkg.Dispose();
            if (ClientRectangle.Width > 10 && ClientRectangle.Height > 10)
                image.Paint(e.Graphics, ClientRectangle);
        }

        /// <summary>
        /// The enumeration value used to set which card (or card back)
        /// is to be painted.
        /// </summary>
        public enum CardType
        {
            /// <exclude/>
            TwoOfHearts = 0,
            /// <exclude/>
            ThreeOfHearts = 1,
            /// <exclude/>
            FourOfHearts = 2,
            /// <exclude/>
            FiveOfHearts = 3,
            /// <exclude/>
            SixOfHearts = 4,
            /// <exclude/>
            SevenOfHearts = 5,
            /// <exclude/>
            EigthOfHearts = 6,
            /// <exclude/>
            NineOfHearts = 7,
            /// <exclude/>
            TenOfHearts = 8,
            /// <exclude/>
            JackOfHearts = 9,
            /// <exclude/>
            QueenOfHearts = 10,
            /// <exclude/>
            KingOfHearts = 11,
            /// <exclude/>
            AceOfHearts = 12,
            /// <exclude/>
            TwoOfDiamonds = 13,
            /// <exclude/>
            ThreeOfDiamonds = 14,
            /// <exclude/>
            FourOfDiamonds = 15,
            /// <exclude/>
            FiveOfDiamonds = 16,
            /// <exclude/>
            SixOfDiamonds = 17,
            /// <exclude/>
            SevenOfDiamonds = 18,
            /// <exclude/>
            EightOfDiamonds = 19,
            /// <exclude/>
            NineOfDiamonds = 20,
            /// <exclude/>
            TenOfDiamonds = 21,
            /// <exclude/>
            JackOfDiamonds = 22,
            /// <exclude/>
            QueenOfDiamonds = 23,
            /// <exclude/>
            KingOfDiamonds = 24,
            /// <exclude/>
            AceOfDiamonds = 25,
            /// <exclude/>
            TwoOfClubs = 26,
            /// <exclude/>
            ThreeOfClubs = 27,
            /// <exclude/>
            FourOfClubs = 28,
            /// <exclude/>
            FiveOfClubs = 29,
            /// <exclude/>
            SixOfClubs = 30,
            /// <exclude/>
            SevenOfClubs = 31,
            /// <exclude/>
            EightOfClubs = 32,
            /// <exclude/>
            NineOfClubs = 33,
            /// <exclude/>
            TenOfClubs = 34,
            /// <exclude/>
            JackOfClubs = 35,
            /// <exclude/>
            QueenOfClubs = 36,
            /// <exclude/>
            KingOfClubs = 37,
            /// <exclude/>
            AceOfClubs = 38,
            /// <exclude/>
            TwoOfSpades = 39,
            /// <exclude/>
            ThreeOfSpades = 40,
            /// <exclude/>
            FourOfSpades = 41,
            /// <exclude/>
            FiveOfSpades = 42,
            /// <exclude/>
            SixOfSpades = 43,
            /// <exclude/>
            SevenOfSpades = 44,
            /// <exclude/>
            EightOfSpades = 45,
            /// <exclude/>
            NineOfSpades = 46,
            /// <exclude/>
            TenOfSpades = 47,
            /// <exclude/>
            JackOfSpades = 48,
            /// <exclude/>
            QueenOfSpades = 49,
            /// <exclude/>
            KingOfSpades = 50,
            /// <exclude/>
            AceOfSpades = 51,
            /// <exclude/>
            JokerRed = 52,
            /// <exclude/>
            JokerBlack = 53,
            /// <exclude/>
            BackBlueHelix = 54,
            /// <exclude/>
            BackBlueStrip = 55,
            /// <exclude/>
            BackRedStrip = 56,
            /// <exclude/>
            BackRedFlower = 57
        }

        /// <exclude/>
        private void SetCardVisiblity(CardType type, bool bvisible)
        {
            switch (type) {
                case CardType.TwoOfHearts:
                    image.Deck_Alt.Hearts.Two.IsVisible = bvisible;
                    break;
                case CardType.ThreeOfHearts:
                    image.Deck_Alt.Hearts.Three.IsVisible = bvisible;
                    break;
                case CardType.FourOfHearts:
                    image.Deck_Alt.Hearts.Four.IsVisible = bvisible;
                    break;
                case CardType.FiveOfHearts:
                    image.Deck_Alt.Hearts.Five.IsVisible = bvisible;
                    break;
                case CardType.SixOfHearts:
                    image.Deck_Alt.Hearts.Six.IsVisible = bvisible;
                    break;
                case CardType.SevenOfHearts:
                    image.Deck_Alt.Hearts.Seven.IsVisible = bvisible;
                    break;
                case CardType.EigthOfHearts:
                    image.Deck_Alt.Hearts.Eight.IsVisible = bvisible;
                    break;
                case CardType.NineOfHearts:
                    image.Deck_Alt.Hearts.Nine.IsVisible = bvisible;
                    break;
                case CardType.TenOfHearts:
                    image.Deck_Alt.Hearts.Ten.IsVisible = bvisible;
                    break;
                case CardType.JackOfHearts:
                    image.Deck_Alt.Hearts.Jack.IsVisible = bvisible;
                    break;
                case CardType.QueenOfHearts:
                    image.Deck_Alt.Hearts.Queen.IsVisible = bvisible;
                    break;
                case CardType.KingOfHearts:
                    image.Deck_Alt.Hearts.King.IsVisible = bvisible;
                    break;
                case CardType.AceOfHearts:
                    image.Deck_Alt.Hearts.Ace.IsVisible = bvisible;
                    break;
                case CardType.TwoOfDiamonds:
                    image.Deck_Alt.Diamonds.Two.IsVisible = bvisible;
                    break;
                case CardType.ThreeOfDiamonds:
                    image.Deck_Alt.Diamonds.Three.IsVisible = bvisible;
                    break;
                case CardType.FourOfDiamonds:
                    image.Deck_Alt.Diamonds.Four.IsVisible = bvisible;
                    break;
                case CardType.FiveOfDiamonds:
                    image.Deck_Alt.Diamonds.Five.IsVisible = bvisible;
                    break;
                case CardType.SixOfDiamonds:
                    image.Deck_Alt.Diamonds.Six.IsVisible = bvisible;
                    break;
                case CardType.SevenOfDiamonds:
                    image.Deck_Alt.Diamonds.Seven.IsVisible = bvisible;
                    break;
                case CardType.EightOfDiamonds:
                    image.Deck_Alt.Diamonds.Eight.IsVisible = bvisible;
                    break;
                case CardType.NineOfDiamonds:
                    image.Deck_Alt.Diamonds.Nine.IsVisible = bvisible;
                    break;
                case CardType.TenOfDiamonds:
                    image.Deck_Alt.Diamonds.Ten.IsVisible = bvisible;
                    break;
                case CardType.JackOfDiamonds:
                    image.Deck_Alt.Diamonds.Jack.IsVisible = bvisible;
                    break;
                case CardType.QueenOfDiamonds:
                    image.Deck_Alt.Diamonds.Queen.IsVisible = bvisible;
                    break;
                case CardType.KingOfDiamonds:
                    image.Deck_Alt.Diamonds.King.IsVisible = bvisible;
                    break;
                case CardType.AceOfDiamonds:
                    image.Deck_Alt.Diamonds.Ace.IsVisible = bvisible;
                    break;
                case CardType.TwoOfClubs:
                    image.Deck_Alt.Clubs.Two.IsVisible = bvisible;
                    break;
                case CardType.ThreeOfClubs:
                    image.Deck_Alt.Clubs.Three.IsVisible = bvisible;
                    break;
                case CardType.FourOfClubs:
                    image.Deck_Alt.Clubs.Four.IsVisible = bvisible;
                    break;
                case CardType.FiveOfClubs:
                    image.Deck_Alt.Clubs.Five.IsVisible = bvisible;
                    break;
                case CardType.SixOfClubs:
                    image.Deck_Alt.Clubs.Six.IsVisible = bvisible;
                    break;
                case CardType.SevenOfClubs:
                    image.Deck_Alt.Clubs.Seven.IsVisible = bvisible;
                    break;
                case CardType.EightOfClubs:
                    image.Deck_Alt.Clubs.Eight.IsVisible = bvisible;
                    break;
                case CardType.NineOfClubs:
                    image.Deck_Alt.Clubs.Nine.IsVisible = bvisible;
                    break;
                case CardType.TenOfClubs:
                    image.Deck_Alt.Clubs.Ten.IsVisible = bvisible;
                    break;
                case CardType.JackOfClubs:
                    image.Deck_Alt.Clubs.Jack.IsVisible = bvisible;
                    break;
                case CardType.QueenOfClubs:
                    image.Deck_Alt.Clubs.Queen.IsVisible = bvisible;
                    break;
                case CardType.KingOfClubs:
                    image.Deck_Alt.Clubs.King.IsVisible = bvisible;
                    break;
                case CardType.AceOfClubs:
                    image.Deck_Alt.Clubs.Ace.IsVisible = bvisible;
                    break;
                case CardType.TwoOfSpades:
                    image.Deck_Alt.Spades.Two.IsVisible = bvisible;
                    break;
                case CardType.ThreeOfSpades:
                    image.Deck_Alt.Spades.Three.IsVisible = bvisible;
                    break;
                case CardType.FourOfSpades:
                    image.Deck_Alt.Spades.Four.IsVisible = bvisible;
                    break;
                case CardType.FiveOfSpades:
                    image.Deck_Alt.Spades.Five.IsVisible = bvisible;
                    break;
                case CardType.SixOfSpades:
                    image.Deck_Alt.Spades.Six.IsVisible = bvisible;
                    break;
                case CardType.SevenOfSpades:
                    image.Deck_Alt.Spades.Seven.IsVisible = bvisible;
                    break;
                case CardType.EightOfSpades:
                    image.Deck_Alt.Spades.Eight.IsVisible = bvisible;
                    break;
                case CardType.NineOfSpades:
                    image.Deck_Alt.Spades.Nine.IsVisible = bvisible;
                    break;
                case CardType.TenOfSpades:
                    image.Deck_Alt.Spades.Ten.IsVisible = bvisible;
                    break;
                case CardType.JackOfSpades:
                    image.Deck_Alt.Spades.Jack.IsVisible = bvisible;
                    break;
                case CardType.QueenOfSpades:
                    image.Deck_Alt.Spades.Queen.IsVisible = bvisible;
                    break;
                case CardType.KingOfSpades:
                    image.Deck_Alt.Spades.King.IsVisible = bvisible;
                    break;
                case CardType.AceOfSpades:
                    image.Deck_Alt.Spades.Ace.IsVisible = bvisible;
                    break;
                case CardType.JokerRed:
                    image.Deck_Alt.Joker.Red.IsVisible = bvisible;
                    break;
                case CardType.JokerBlack:
                    image.Deck_Alt.Joker.Black.IsVisible = bvisible;
                    break;
                case CardType.BackBlueHelix:
                    image.Deck_Alt.Backs.BlueHelix.IsVisible = bvisible;
                    break;
                case CardType.BackBlueStrip:
                    image.Deck_Alt.Backs.BlueStripe.IsVisible = bvisible;
                    break;
                case CardType.BackRedStrip:
                    image.Deck_Alt.Backs.RedStripe.IsVisible = bvisible;
                    break;
                case CardType.BackRedFlower:
                    image.Deck_Alt.Backs.RedFlower.IsVisible = bvisible;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public delegate void CardClickHandler();

        /// <summary>
        /// 
        /// </summary>
        public event CardClickHandler CardClick;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardVector_MouseClick(object sender, MouseEventArgs e)
        {
            if (image.BoundingBox(image.StandardTransform(ClientRectangle)).Contains(new PointF(e.X, e.Y)))
            {
                if (CardClick != null)
                    CardClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardVector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (image.BoundingBox(image.StandardTransform(ClientRectangle)).Contains(new PointF(e.X, e.Y)))
            {
                if (CardClick != null)
                    CardClick();
            }
        }
    }
}