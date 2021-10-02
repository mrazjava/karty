// This application is covered by the LGPL Gnu license. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HoldemHand;

namespace VideoPoker
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Stores current amount of players coins.
        /// </summary>
        private double amount = 1000.0;

        /// <summary>
        /// Stores current bet amount.
        /// </summary>
        private int bet = 0;

        /// <summary>
        /// Amount of current win
        /// </summary>
        private double win = 0.0;

        /// <summary>
        /// Contains Expected Value for the best hold settings
        /// </summary>
        private double bestev = 0.0;

        /// <summary>
        /// Contains Best mask
        /// </summary>
        private uint bestmask = 0U;

        /// <summary>
        /// Contains Expected Value for the current hold settings
        /// </summary>
        private double ev = 0.0;

        /// <summary>
        /// Contains the hold values for the current hand.
        /// </summary>
        private bool[] hold = new bool[5];

        /// <summary>
        /// Holds Shuffled Deck
        /// </summary>
        private int[] deck = new int[52];

        /// <summary>
        /// Index to the next available card in the deck.
        /// </summary>
        private int nextcard = 0;

        /// <summary>
        /// Contains cards in the current hand.
        /// </summary>
        private int[] hand = new int[5];

        /// <summary>
        /// Random instance used to shuffle cards.
        /// </summary>
        private Random rand = new Random();

        /// <summary>
        /// Current UI state.
        /// </summary>
        private enum State
        {
            /// <summary>
            /// Ready for new hand
            /// </summary>
            Start, 
            /// <summary>
            /// Allow user to toggle hold values on cards
            /// </summary>
            SetHold
        }

        /// <summary>
        /// Start ready for a new hand
        /// </summary>
        private State currentState = State.Start;

        /// <summary>
        /// 
        /// </summary>
        private int BetValue
        {
            get { return bet; }
            set { 
                bet = value;
                if (bet > 0)
                {
                    Deal.Enabled = true;
                }
                else
                {
                    Deal.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Shuffle the deck of cards.
        /// </summary>
        public void ShuffleDeck()
        {
            ulong handmask = 0UL;

            // Initialize Deck
            nextcard = 0;
            for (int i = 0; i < 52; i++)
            {
                deck[i] = i;
            }

            // Shuffle Deck
            for (int x = 0; x < 5; x++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int ix = rand.Next() % 52;
                    int tmp = deck[i];
                    deck[i] = deck[ix];
                    deck[ix] = tmp;
                }
            }

            // Put cards into card faces
            Card1.Card = (CardVectorImage.CardVector.CardType)NextCard;
            Card2.Card = (CardVectorImage.CardVector.CardType)NextCard;
            Card3.Card = (CardVectorImage.CardVector.CardType)NextCard;
            Card4.Card = (CardVectorImage.CardVector.CardType)NextCard;
            Card5.Card = (CardVectorImage.CardVector.CardType)NextCard;

            // Put in hand array
            hand[0] = (int) Card1.Card;
            hand[1] = (int) Card2.Card;
            hand[2] = (int) Card3.Card;
            hand[3] = (int) Card4.Card;
            hand[4] = (int) Card5.Card;

            // Change state to SetHold
            CurrentState = State.SetHold;

            // Determine best hold settings for this hand
            AutomaticHoldset();

            // Update labels
            UpdateLabels();

            // Create handmask
            for (int i = 0; i < 5; i++)
            {
                handmask |= (1UL << hand[i]);
            }

            StatusInfo.Text = Description(Hand.Evaluate(handmask, 5));
        }

        /// <summary>
        /// Get next available card from the Deck
        /// </summary>
        public int NextCard
        {
            get { return deck[nextcard++]; }
        }

        /// <summary>
        /// Returns current state (either Start, or SetHold)
        /// </summary>
        private State CurrentState
        {
            get { return currentState; }
            set { 
                currentState = value;
                if (currentState == State.Start)
                {
                    Hold1.Enabled = false;
                    Hold2.Enabled = false;
                    Hold3.Enabled = false;
                    Hold4.Enabled = false;
                    Hold5.Enabled = false;
                    Bet1.Enabled = true;
                    BetMax.Enabled = true;
                    Deal.Enabled = false;
                    BestHold.Enabled = false;
                }
                else
                {
                    Hold1.Enabled = true;
                    Hold2.Enabled = true;
                    Hold3.Enabled = true;
                    Hold4.Enabled = true;
                    Hold5.Enabled = true;
                    Bet1.Enabled = false;
                    BetMax.Enabled = false;
                    Deal.Enabled = true;
                    BestHold.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializer for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentState = State.Start;
            for (int i = 0; i < hold.Length; i++)
            {
                hold[i] = false;
            }
            UpdateLabels();
        }

        /// <summary>
        /// Move contents of values onto the labels
        /// </summary>
        public void UpdateLabels()
        {
            Coins.Text = string.Format("Coins: {0}", amount);

            if (win == 0)
            {
                Win.Text = "";
            }
            else
            {
                Win.Text = string.Format("Win: {0}", win);
            }

            for (int i = 0; i < hold.Length; i++)
            {
                if (hold[i])
                {
                    switch (i)
                    {
                        case 0:
                            HoldLabel1.Text = "Hold";
                            break;
                        case 1:
                            HoldLabel2.Text = "Hold";
                            break;
                        case 2:
                            HoldLabel3.Text = "Hold";
                            break;
                        case 3:
                            HoldLabel4.Text = "Hold";
                            break;
                        case 4:
                            HoldLabel5.Text = "Hold";
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            HoldLabel1.Text = "";
                            break;
                        case 1:
                            HoldLabel2.Text = "";
                            break;
                        case 2:
                            HoldLabel3.Text = "";
                            break;
                        case 3:
                            HoldLabel4.Text = "";
                            break;
                        case 4:
                            HoldLabel5.Text = "";
                            break;
                    }
                }
            }

            if (bet != 0)
                Bet.Text = string.Format("Bet: {0}", bet);
            else
                Bet.Text = "";

            if (bestev != 0.0)
            {
                EV.Text = string.Format("Best EV: {0:0.0}% ({1:0.00} Coins)", bestev / bet * 100.0, bestev);
            }
            else
            {
                EV.Text = "";
            }
            if (ev != 0.0)
            {
                CurrentEv.Text = string.Format("Current EV: {0:0.0}% ({1:0.00} Coins)", ev / bet * 100.0, ev);
            }
            else
            {
                CurrentEv.Text = "";
            }
            
            Invalidate();
        }

        /// <summary>
        /// Convert hand ranking to a descriptive string.
        /// </summary>
        /// <param name="handval">hand value</param>
        /// <returns>descriptive string</returns>
        public string Description(uint handval)
        {
            switch ((Hand.HandTypes)Hand.HandType(handval)) 
            {
                case Hand.HandTypes.StraightFlush:
                    if (Hand.CardRank((int) Hand.TopCard(handval)) == Hand.RankAce)
                    {
                        return "Royal Flush";
                    }
                    return "Straight Flush";
                case Hand.HandTypes.FourOfAKind:
                    return "Four of a Kind";
                case Hand.HandTypes.FullHouse:
                    return "Full house";
                case Hand.HandTypes.Flush:
                    return "Flush";
                case Hand.HandTypes.Straight:
                    return "Straight";
                case Hand.HandTypes.Trips:
                    return "Three of a Kind";
                case Hand.HandTypes.TwoPair:
                    return "Two Pairs";
                case Hand.HandTypes.Pair:
                    if (Hand.CardRank((int) Hand.TopCard(handval)) >= Hand.RankJack)
                    {
                        return "Jacks or Better";
                    }
                    break;
            }
            return "";
        }

        /// <summary>
        /// Calculates winnings given the passed hand value and number of coins.
        /// This function handles the payoff rules for an 8/6 version of Jacks or better.
        /// This is the function to change if you want the trainer to handle a different
        /// video poker game.
        /// </summary>
        /// <param name="handval">Hand value</param>
        /// <param name="coins">Coins bet</param>
        /// <returns>winnings</returns>
        public double CalcWinnings(uint handval, int coins)
        {
            switch ((Hand.HandTypes)Hand.HandType(handval))
            {
                case Hand.HandTypes.StraightFlush:
                    if (Hand.CardRank((int) Hand.TopCard(handval)) == Hand.RankAce)
                    {
                        if (coins < 5)
                        {
                            return 250.0 * coins;
                        }
                        else
                        {
                            return 4000.0;
                        }
                    }
                    return 40.0 * coins;
                case Hand.HandTypes.FourOfAKind:
                    return 20.0 * coins;
                case Hand.HandTypes.FullHouse:
                    return 9.0 * coins;
                case Hand.HandTypes.Flush:
                    return 6.0 * coins;
                case Hand.HandTypes.Straight:
                    return 4.0 * coins;
                case Hand.HandTypes.Trips:
                    return 3.0 * coins;
                case Hand.HandTypes.TwoPair:
                    return 2.0 * coins;
                case Hand.HandTypes.Pair:
                    if (Hand.CardRank((int) Hand.TopCard(handval)) >= Hand.RankJack)
                    {
                        return 1.0 * coins;
                    }
                    break;
            }
            return 0.0;
        }

        /// <summary>
        /// Recalculates the expected value when the hold card defintion changes.
        /// </summary>
        public void UpdateHold()
        {
            uint holdmask = 0U;

            for (int i = 0; i < 5; i++)
            {
                holdmask |= (hold[i] ? (1U << i) : 0U);
            }
             
            ev = ExpectedValue(holdmask);
       
            UpdateLabels();
        }

        /// <summary>
        /// Get the current card values from the UI
        /// </summary>
        /// <param name="index">index of card in hand</param>
        /// <returns>card value</returns>
        public int CardValue(int index)
        {
            switch (index)
            {
                case 0: return (int)Card1.Card;
                case 1: return (int)Card2.Card;
                case 2: return (int)Card3.Card;
                case 3: return (int)Card4.Card;
                case 4: return (int)Card5.Card;
            }
            return -1;
        }

        /// <summary>
        /// Sets the UI's card value
        /// </summary>
        /// <param name="index">Index of card to change</param>
        /// <param name="v">value of the new card</param>
        public void SetCardValue(int index, int v)
        {
            switch (index)
            {
                case 0: Card1.Card = (CardVectorImage.CardVector.CardType)v; break;
                case 1: Card2.Card = (CardVectorImage.CardVector.CardType)v; break;
                case 2: Card3.Card = (CardVectorImage.CardVector.CardType)v; break;
                case 3: Card4.Card = (CardVectorImage.CardVector.CardType)v; break;
                case 4: Card5.Card = (CardVectorImage.CardVector.CardType)v; break;
            }
        }

        /// <summary>
        /// Given a hold mask, return the expected value for the current hand.
        /// </summary>
        /// <param name="holdmask">mask of the cards to hold</param>
        /// <returns>expected value</returns>
        public double ExpectedValue(uint holdmask)
        {
            ulong handmask = 0UL;
            ulong deadcards = 0UL;
            double winnings = 0.0;
            long count = 0;

            // Create handmask for cards that aren't held
            // and create deadcards for the cards that are
            // held.
            for (int i = 0; i < 5; i++)
            {
                if ((holdmask & (1UL << i)) != 0)
                {
                    handmask |= (1UL << hand[i]);
                }
                else
                {
                    deadcards |= (1UL << hand[i]);
                }
            }

            // Loop through all possible hand possiblities
            foreach (ulong mask in Hand.Hands(handmask, deadcards, 5))
            {
                winnings += CalcWinnings(Hand.Evaluate(mask, 5), bet);
                count++;
            }

            return (count > 0 ? winnings / count : 0.0);
        }

        /// <summary>
        /// Determines the best hold settings for the current hand.
        /// </summary>
        public void AutomaticHoldset()
        {
            double  expectedValue = 0.0;
            
            ev = bestev = ExpectedValue(0U);
            bestmask = 0U;

            // Try all hold possiblities
            for (uint holdmask = 1; holdmask < 32; holdmask++)
            {
                expectedValue = ExpectedValue(holdmask);
                if (expectedValue > bestev)
                {
                    bestev = expectedValue;
                    bestmask = holdmask;
                }
            }

            // Clear hold flags
            for (int i = 0; i < 5; i++)
            {
                hold[i] = false;
            }
        }

        /// <summary>
        /// Fill cards that aren't held with the next available cards in the Deck.
        /// </summary>
        public void FillUnHeldCards()
        {
            // Draw new cards for non-held cards.
            for (int i = 0; i < 5; i++)
            {
                if (!hold[i])
                {
                    int newcard = NextCard;
                    hand[i] = newcard;
                    SetCardValue(i, (int) newcard);
                }
            }

            // Clear hold flags
            for (int i = 0; i < hold.Length; i++)
            {
                hold[i] = false;
            }

            // Reset Expected Value
            ev = 0.0;
            bestev = 0.0;
        }

        /// <summary>
        /// We've drawn our cards, what's it worth?
        /// </summary>
        public void CalculateWinnings()
        {
            ulong handmask = 0UL;

            for (int i = 0; i < 5; i++)
            {
                handmask |= (1UL << hand[i]);
            }
            win = CalcWinnings(Hand.Evaluate(handmask, 5), bet);
            amount += win;
            bet = 0;
            StatusInfo.Text = Description(Hand.Evaluate(handmask, 5));
        }


        /// <summary>
        /// Display card backs
        /// </summary>
        public void CardBacks()
        {
            Card1.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            Card2.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            Card3.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            Card4.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            Card5.Card = CardVectorImage.CardVector.CardType.BackRedFlower;
            Invalidate();
        }

        /// <summary>
        /// Handle Hold Button Click for card 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hold1_Click(object sender, EventArgs e)
        {
            ToggleHold(0);
        }

        /// <summary>
        /// Handle Hold Button Click for card 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hold2_Click(object sender, EventArgs e)
        {
            ToggleHold(1);
        }

        /// <summary>
        /// Handle Hold Button Click for card 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hold3_Click(object sender, EventArgs e)
        {
            ToggleHold(2);
        }

        /// <summary>
        /// Handle Hold Button Click for card 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hold4_Click(object sender, EventArgs e)
        {
            ToggleHold(3);
        }

        /// <summary>
        /// Handle Hold Button Click for card 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hold5_Click(object sender, EventArgs e)
        {
            ToggleHold(4);
        }

        /// <summary>
        /// Handle Bet 1 button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bet1_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.Start)
            {
                win = 0.0;
                this.CardBacks();
                if (BetValue < 5)
                {
                    BetValue++;
                    amount--;
                }
                UpdateLabels();
                StatusInfo.Text = "";
            }
        }


        /// <summary>
        /// Handle Max Bet Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BetMax_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.Start)
            {
                win = 0.0;
                amount -= (5 - BetValue);
                BetValue = 5;
                UpdateLabels();             
                ShuffleDeck();
            }
        }

        /// <summary>
        /// Handle deal button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deal_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.Start && bet > 0)
            {
                ShuffleDeck();
            }
            else if (currentState == State.SetHold)
            {
                FillUnHeldCards();
                CalculateWinnings();
                UpdateLabels();
                CurrentState = State.Start;
            }
        }

        /// <summary>
        /// Toggle hold state for the specified card.
        /// </summary>
        /// <param name="index"></param>
        private void ToggleHold(int index)
        {
            if (CurrentState == State.SetHold)
            {
                hold[index] = !hold[index];
                UpdateHold();
                UpdateLabels();
            }
        }

        /// <summary>
        /// Handle Click or Double Click for a card 1 by toggling the hold state.
        /// </summary>
        private void Card1_CardClick()
        {
            ToggleHold(0);
        }

        /// <summary>
        /// Handle Click or Double Click for a card 2 by toggling the hold state.
        /// </summary>
        private void Card2_CardClick()
        {
            ToggleHold(1);
        }

        /// <summary>
        /// Handle Click or Double Click for a card 3 by toggling the hold state.
        /// </summary>
        private void Card3_CardClick()
        {
            ToggleHold(2);
        }

        /// <summary>
        /// Handle Click or Double Click for a card 4 by toggling the hold state.
        /// </summary>
        private void Card4_CardClick()
        {
            ToggleHold(3);
        }

        /// <summary>
        /// Handle Click or Double Click for a card 5 by toggling the hold state.
        /// </summary>
        private void Card5_CardClick()
        {
            ToggleHold(4);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BestHold_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.SetHold)
            {
                for (int i = 0; i < 5; i++)
                {
                    hold[i] = (bestmask & (1UL << i)) != 0;
                }
                ev = ExpectedValue(bestmask);
                UpdateLabels();
            }
        }
    }
}