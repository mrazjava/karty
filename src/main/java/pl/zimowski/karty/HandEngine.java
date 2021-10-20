package pl.zimowski.karty;

import java.util.HashMap;
import java.util.Map;
import java.util.Random;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import pl.zimowski.karty.tables.BitAndStrTable;
import pl.zimowski.karty.tables.BitCountTable;
import pl.zimowski.karty.tables.BitsTable;
import pl.zimowski.karty.tables.CardMasksTable;
import pl.zimowski.karty.tables.CardTable;
import pl.zimowski.karty.tables.OpponentOddsTable;
import pl.zimowski.karty.tables.PlayerOddsTable;
import pl.zimowski.karty.tables.Pocket169Table;
import pl.zimowski.karty.tables.RankCharTable;
import pl.zimowski.karty.tables.RankTable;
import pl.zimowski.karty.tables.StraightTable;
import pl.zimowski.karty.tables.SuitCharTable;
import pl.zimowski.karty.tables.SuitTable;
import pl.zimowski.karty.tables.TopCardTable;
import pl.zimowski.karty.tables.TopFiveCardsTable;
import pl.zimowski.karty.tables.TwoCardTable;

public class HandEngine {

	private static final Logger log = LoggerFactory.getLogger(HandEngine.class);

	/**
	 * Possible types of hands in a texas holdem game.
	 */
	public enum HandTypes {
		HighCard,
		Pair,
		TwoPair,
		Trips,
		Straight,
		Flush,
		FullHouse,
		FourOfAKind,
		StraightFlush
	}

	public static final int CARD_JOKER = 52;

	// The total number of cards in a deck
	public static final int NUMBER_OF_CARDS = 52;

	public static final int NUMBER_OF_CARDS_WITHOUT_JOKER = 53;

	private static final int HANDTYPE_SHIFT = 24;

	private static final int TOP_CARD_SHIFT = 16;

	private static final int TOP_CARD_MASK = 0x000F0000;

	private static final int SECOND_CARD_SHIFT = 12;

	private static final int SECOND_CARD_MASK = 0x0000F000;

	private static final int THIRD_CARD_SHIFT = 8;

	private static final int FOURTH_CARD_SHIFT = 4;

	private static final int FIFTH_CARD_SHIFT = 0;

	private static final int FIFTH_CARD_MASK = 0x0000000F;

	private static final int CARD_WIDTH = 4;

	private static final int CARD_MASK = 0x0F;

	/* ~~~~~~~~~~~~~~~~~~~ Lookup Tables ~~~~~~~~~~~~~~~~~~~ */

	// Bit count table from snippets.org
	private static final byte[] _bitCountTable = BitCountTable.TABLE;

	private static final short[] _bitsAndStrTable = BitAndStrTable.TABLE;

	// A table representing the bit count for a 13 bit integer.
	public static final short[] _bitsTable = BitsTable.TABLE;

	// This table returns a straights starting card (0 if not a straight)
	private static final short[] _straightTable = StraightTable.TABLE;

	private static final int[] _topFiveCardsTable = TopFiveCardsTable.TABLE;

	private static final short[] _topCardTable = TopCardTable.TABLE;

	/**
	 * This table is equivalent to 1UL left shifted by the index. The lookup is
	 * faster than the left shift operator.
	 */
	public static final long[] _cardMasksTable = CardMasksTable.TABLE;

	// converts card number into the equivalent text string.
	public static final String[] _cardTable = CardTable.TABLE;

	// Converts card number into the card rank text string
	public static final String[] _rankTable = RankTable.TABLE;

	// Converts card number into the card suit text string
	private static final String[] _suitTable = SuitTable.TABLE;

	// Converts card number into the card rank char
	private static final char[] _rankCharTable = RankCharTable.TABLE;

	// Converts card number into the card suit text string
	private static final char[] _suitCharTable = SuitCharTable.TABLE;

	/**
	 * 1326 ulong cards masks for all hold cards.
	 * FROM:HandIterator.cs
	 */
	static final long[] _twoCardTable = TwoCardTable.TABLE;

	/**
	 * The 1326 possible pocket cards ordered by the 169 unique holdem
	 * combinations. The index is equivalent to the number value of
	 * Hand.PocketPairType.
	 * FROM:HandIterator.cs
	 */
	private static final long[][] _pocket169Table = Pocket169Table.TABLE;

	// quick lookup by mask to return enumerated type
	private static Map<Long, PocketHand169Enum> _pocketDictionary = new HashMap<Long, PocketHand169Enum>();

	private static final double[][] _preCalcPlayerOddsTable = PlayerOddsTable.TABLE;

	private static double[][] _preCalcOppOddsTable = OpponentOddsTable.TABLE;

	/**
	 * As a utility class, no instances are allowed therefore constructor is
	 * disabled.
	 */
	private HandEngine() {
	}

	/**
	 * Takes a string representing a full or partial holdem hand and validates
	 * that the text represents valid cards and that no card is duplicated.
	 *
	 * @param aHand hand to validate
	 * @return true of a valid hand, false otherwise
	 */
	public static boolean validateHand(String aHand) {

		if(StringUtils.isEmpty(aHand)) return false;

        long handmask = 0L;
        int cards = 0;
        int card = 0;

        if(log.isTraceEnabled()) log.trace("hand: " + aHand);

        try {
        	IntegerRef index = new IntegerRef(0);
            for(card = nextCard(aHand, index);
            	card >= 0;
            	card = nextCard(aHand, index)) {

            	if(log.isTraceEnabled()) log.trace("index: " + index);

            	if ((handmask & (1L << card)) != 0)
                    return false;
                handmask |= (1L << card);
                cards++;
            }

            return card == -1 && cards > 0 && index.get() >= aHand.length();
        }
        catch(Exception e) {
        	log.error(e.getMessage());
        }

        return false;
	}

	/**
	 * Takes a string representing pocket cards and a board and then validates
	 * that the text represents a valid hand.
	 *
	 * @param aPocket Pocket cards as a string
	 * @param aBoard Board cards as a string
	 * @return true of a valid hand, false otherwise
	 */
	public static boolean validateHand(String aPocket, String aBoard) {

		if(StringUtils.isEmpty(aPocket))
			throw new IllegalArgumentException("pocket");

		if(StringUtils.isEmpty(aBoard))
			throw new IllegalArgumentException("board");

		return validateHand(aPocket + " " + aBoard);
	}

	/**
	 * Parses a string description of a hand and returns a hand mask.
	 *
	 * @param aHand string descripton of a hand
	 * @return a hand mask representing the hand
	 */
	public static long parseHand(String aHand) {
        return parseHand(aHand, null);
	}

	/**
	 * Parses a string description of a hand and returns a hand mask.
	 * Optionally, can also return number of cards parsed through the second
	 * argument.
	 *
	 * @param aHand string description of a hand
	 * @param aCards valid integer instance to retrieve number of cards that
	 * 	have been parsed; may be null if not interested
	 * @return a hand mask representing the hand
	 */
	public static long parseHand(String aHand, IntegerRef aCards) {

        if(StringUtils.isEmpty(aHand))
        	throw new IllegalArgumentException("hand");

        // Hand contains either invalid strings or duplicate entries
        if(!HandEngine.validateHand(aHand))
        	throw new IllegalArgumentException("Bad hand definition: [" + aHand + "]");

		IntegerRef index = new IntegerRef(0);
        long handmask = 0L;

        // Parse the hand
        if(aCards != null) aCards.set(0);
        for(int card = nextCard(aHand, index); card >= 0;
        	card = nextCard(aHand, index)) {

            handmask |= (1L << card);
            if(aCards != null) aCards.increment();
        }
        return handmask;
	}

	/**
	 * Parses the passed pocket cards and board and produces a card mask.
	 * Optionally, can also return number of cards parsed through the second
	 * argument.
	 *
	 * @param aPocket string description representing pocket cards
	 * @param aBoard string description representing board cards; may be null
	 * 	or empty if board is empty
	 * @param aCards valid integer instance to retrieve number of cards that
	 * 	have been parsed; may be null if not interested
	 * @return a hand mask representing the hand
	 * @throws IllegalArgumentException if pocket card string is empty or null
	 */
	public static long parseHand(String aPocket, String aBoard, IntegerRef aCards) {

		if(StringUtils.isEmpty(aPocket))
			throw new IllegalArgumentException("pocket");

		StringBuilder hand = new StringBuilder(aPocket);
		if(StringUtils.isNotEmpty(aBoard)) hand.append(" " + aBoard);

		return parseHand(hand.toString(), aCards);
	}

	/**
	 * Reads an string definition of a card and returns the Card value. Card
	 * value range is 0 (inclusive) to 52 (exclusive). Note that value is not
	 * the same as rank. It is a unique numeric representation of a card in a
	 * deck.
	 *
	 * @param aCard card string
	 * @return numerica value representing a card
	 * @throws IllegalArgumentException if card string is null or empty
	 */
	public static int parseCard(String aCard) {

        if(StringUtils.isEmpty(aCard))
            throw new IllegalArgumentException("card");

        return nextCard(aCard, new IntegerRef(0));
	}

	/**
	 * Parses string representing multiple cards and returns a single card
	 * value for a card defined by iterator argument. value range is 0
	 * (inclusive) to 52 (exclusive). This function is iterative in nature in
	 * that it is meant to be called in the iterative way to extract one card
	 * per call from a string, since iterator is updated by reference.
	 *
	 * @param aCards string containing hand definition
	 * @param aCardIterator iterator into card string
	 * @return card value for a card defined by the iterator
	 * @throws IllegalArgumentException if either argument is null
	 */
	public static int nextCard(String aCards, IntegerRef aCardIterator) {

		int rank = 0, suit = 0;

		if(aCards == null)
			throw new IllegalArgumentException("cards");

		if(aCardIterator == null)
			throw new IllegalArgumentException("itrator");

		if(log.isTraceEnabled()) log.trace("index: " + aCardIterator);

        // Remove whitespace
		while (aCardIterator.get() < aCards.length() &&
				aCards.charAt(aCardIterator.get()) == ' ') {
            aCardIterator.increment();
		}

        if(aCardIterator.get() >= aCards.length())
            return -1;

        // Parse cards
        if(aCardIterator.get() < aCards.length()) {
        	char charAt = aCards.charAt(aCardIterator.increment());
        	if(log.isTraceEnabled()) log.trace("switch val: " + charAt);
        	switch(charAt) {
                case '1':
                    try {
                        if (aCards.charAt(aCardIterator.get()) == '0') {
                            aCardIterator.increment();
                            rank = Rank.Ten.ordinal();
                        }
                        else { return -1; }
                    }
                    catch(Exception e) {
                        throw new IllegalArgumentException("Bad hand string");
                    }
                    break;
                case '2':
                    rank = Rank.Two.ordinal();
                    break;
                case '3':
                    rank = Rank.Three.ordinal();
                    break;
                case '4':
                    rank = Rank.Four.ordinal();
                    break;
                case '5':
                    rank = Rank.Five.ordinal();
                    break;
                case '6':
                    rank = Rank.Six.ordinal();
                    break;
                case '7':
                    rank = Rank.Seven.ordinal();
                    break;
                case '8':
                    rank = Rank.Eight.ordinal();
                    break;
                case '9':
                    rank = Rank.Nine.ordinal();
                    break;
                case 'T':
                case 't':
                    rank = Rank.Ten.ordinal();
                    break;
                case 'J':
                case 'j':
                    rank = Rank.Jack.ordinal();
                    break;
                case 'Q':
                case 'q':
                    rank = Rank.Queen.ordinal();
                    break;
                case 'K':
                case 'k':
                    rank = Rank.King.ordinal();
                    break;
                case 'A':
                case 'a':
                    rank = Rank.Ace.ordinal();
                    break;
                default:
                    return -2;
            }
        }
        else { return -2; }

        if(log.isTraceEnabled()) log.trace("rank: " + rank);

        if(aCardIterator.get() < aCards.length()) {
            switch (aCards.charAt(aCardIterator.increment())) {
                case 'H':
                case 'h':
                    suit = Suit.Hearts.ordinal();
                    break;
                case 'D':
                case 'd':
                    suit = Suit.Diamonds.ordinal();
                    break;
                case 'C':
                case 'c':
                    suit = Suit.Clubs.ordinal();
                    break;
                case 'S':
                case 's':
                    suit = Suit.Spades.ordinal();
                    break;
                default:
                    return -2;
            }
        }
        else { return -2; }

        if(log.isTraceEnabled()) log.trace("suit: " + suit);

        return rank + (suit * 13);
	}

	/**
	 * Given a card value, returns it's rank.
	 *
	 * @param aCard card value
	 * @return rank of a card
	 * @throws ArgumentOutOfRangeException if card value is out of valid range;
	 * 	must be greater or equal to zero and less than 52
	 */
	public static int cardRank(int aCard) {

        // Legal values are 0 - 52.
        if (aCard < 0 || aCard > 52)
            throw new ArgumentOutOfRangeException("card");

        return aCard % 13;
	}

	/**
	 * Given a card value, returns it's suit
	 *
	 * @param aCard Card value
	 * @return numeric value dentoting a suit
	 * @throws ArgumentOutOfRangeException if card value is out of valid range;
	 * 	must be greater or equal to zero and less than 52
	 */
	public static int cardSuit(int aCard) {

        // Legal values are 0 - 52.
        if (aCard < 0 || aCard > 52)
            throw new ArgumentOutOfRangeException("card");

        return aCard / 13;
	}

	/**
	 * Takes a hand value and returns a description string. This is useful when
	 * needing to convert hand into a readable format.
	 *
	 * @param handValue A hand value as returned by one of the Evalute(..)
	 * 	functions
	 * @return A description string of the value of the hand
	 */
	public static String descriptionFromHandValue(int handValue) {

        StringBuilder b = new StringBuilder();
        int handType = computeHandType(handValue);

        switch(HandTypes.values()[handType]) {
            case HighCard:
                b.append("High card: ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                return b.toString();
            case Pair:
                b.append("One pair, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append("'s");
                return b.toString();
            case TwoPair:
                b.append("Two pair, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append("'s and ");
                b.append(_rankTable[extractSecondRankedCard(handValue)]);
                b.append("'s with a ");
                b.append(_rankTable[extractThirdRankedCard(handValue)]);
                b.append(" for a kicker");
                return b.toString();
            case Trips:
                b.append("Three of a kind, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append("'s");
                return b.toString();
            case Straight:
                b.append("A straight, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append(" high");
                return b.toString();
            case Flush:
                b.append("A flush");
                return b.toString();
            case FullHouse:
                b.append("A fullhouse, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append("'s and ");
                b.append(_rankTable[extractSecondRankedCard(handValue)]);
                b.append("'s");
                return b.toString();
            case FourOfAKind:
                b.append("Four of a kind, ");
                b.append(_rankTable[extractTopRankedCard(handValue)]);
                b.append("'s");
                return b.toString();
            case StraightFlush:
                b.append("A straight flush");
                return b.toString();
        }

        log.error("could not determine hand description from [" +
        		handValue + "]");

        return "";
	}

	/**
	 * Given a card mask (like the ones that come out or the parse functions)
	 * returns card description.
	 *
	 * @param aCardMask
	 * @return description of the hand value
	 * @throws ArgumentOutOfRangeException if mask represents invalid card
	 * 	count, which should be at least one and no more than seven
	 */
	public static String descriptionFromMask(long aCardMask) {

		int numberOfCards = BitCount(aCardMask);

		if(log.isDebugEnabled())
			log.debug("mask: " + aCardMask);

        // This functions supports 1-7 cards
        if (numberOfCards < 1 || numberOfCards > 7)
            throw new ArgumentOutOfRangeException("numberOfCards");

        // Seperate out by suit
        int sc = (int)((aCardMask >> (CLUB_OFFSET)) & 0x1fffL);
        int sd = (int)((aCardMask >> (DIAMOND_OFFSET)) & 0x1fffL);
        int sh = (int)((aCardMask >> (HEART_OFFSET)) & 0x1fffL);
        int ss = (int)((aCardMask >> (SPADE_OFFSET)) & 0x1fffL);

        int handvalue = Evaluate(aCardMask, numberOfCards);
        if(log.isDebugEnabled()) log.debug("handvalue: " + handvalue);

        switch(HandTypes.values()[computeHandType(handvalue)])
        {
            case HighCard:
            case Pair:
            case TwoPair:
            case Trips:
            case Straight:
            case FullHouse:
            case FourOfAKind:
                return descriptionFromHandValue(handvalue);
            case Flush:
                if(_bitsTable[ss] >= 5) {
                    return "Flush (Spades) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sc] >= 5) {
                    return "Flush (Clubs) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sd] >= 5) {
                    return "Flush (Diamonds) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sh] >= 5) {
                    return "Flush (Hearts) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                break;
            case StraightFlush:
                if(_bitsTable[ss] >= 5) {
                    return "Straight Flush (Spades) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sc] >= 5) {
                    return "Straight (Clubs) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sd] >= 5) {
                    return "Straight (Diamonds) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                else if(_bitsTable[sh] >= 5) {
                    return "Straight  (Hearts) with " +
                    	_rankTable[extractTopRankedCard(handvalue)] + " high";
                }
                break;
        }

        log.error("could not produce " +
        		"description given mask [" + aCardMask + "]");

        return "";
	}

	/**
	 * @param aCardValue
	 * @return description of a card given its value
	 */
	public static String descriptionFromCardValue(int aCardValue) {
		try {
			return _rankTable[aCardValue];
		}
		catch(ArrayIndexOutOfBoundsException e) {
			throw new IllegalArgumentException("invalid card value");
		}
	}

	/**
	 * Given a string describing hand card values, returns hand description.
	 * For example: if input were "Ah 2d 9h 10s 5d Kh 6h", return value would
	 * be "High card: Ace".
	 *
	 * @param aHand the string describing cards in the hand
	 * @return hand description
	 * @throws IllegalArgumentException if input is null or empty
	 */
	public static String descriptionFromHand(String aHand) {

        if(StringUtils.isEmpty(aHand))
            throw new IllegalArgumentException("hand");

        long mask = parseHand(aHand, null);
        return descriptionFromMask(mask);
	}

	/**
	 * Convinience function for a fast look up to get mask given table index.
	 *
	 * @param index index of mask with respect to a lookup table
	 * @return card mask value
	 */
	public static long lookupMaskByIndex(int index) {
		return _cardMasksTable[index];
	}

	/**
	 * Convinience function to compute hand type given hand value.
	 *
	 * @param aHandValue
	 * @return hand type
	 */
	public static int computeHandType(int aHandValue) {
		return (aHandValue >> HANDTYPE_SHIFT);
	}

	/**
	 * Computes value of a card which is top ranked when evaluating a 5 card
	 * hand out of maximum 7 cards. Returned value is always the code of only
	 * one card without a suit (Ace, Jack, Two, etc). Top rank is determined as
	 * card which makes a top rank, so in case of high card return value would
	 * represent a single card; in case of two pair, return value would
	 * represent a card which makes up a higher pair; three of a kind, a card
	 * representing the trips, etc.
	 *
	 * @param aHandValue
	 * @return card value
	 */
	public static int extractTopRankedCard(int aHandValue) {
		return ((aHandValue >> TOP_CARD_SHIFT) & CARD_MASK);
	}

	/**
	 * Computes value of a second-highest ranked card when evaluating a hand.
	 * Returned value is always the code of only one card without a suit (Ace,
	 * Jack, Two, etc). Second rank is determined as a stand-alone (kicker)
	 * card which is second-best to a top-ranked card. For example, for a two
	 * pair Aces and Jacks, the return value would be Jack. If a hand as a whole
	 * takes all 5 cards (straight & straight flush), the second is irrelevant
	 * and return value will be two.
	 *
	 * @param aHandValue
	 * @return card value
	 */
	public static int extractSecondRankedCard(int aHandValue) {
		return (((aHandValue) >> SECOND_CARD_SHIFT) & CARD_MASK);
	}

	/**
	 * Computes value of a third-highest ranked card when evaluating a hand.
	 * Returned value is always the code of only one card without a suit (Ace,
	 * Jack, Two, etc). Third rank is determined as card which is third-best
	 * after top-ranked and second-best cards. For example, for a two pair
	 * Aces and Jacks, with King, Ten and Two, the return value would a King
	 * since it is the strongest kicker, thus third-best card.
	 *
	 * @param aHandValue
	 * @return card value
	 */
	public static int extractThirdRankedCard(int aHandValue) {
		return (((aHandValue) >> THIRD_CARD_SHIFT) & CARD_MASK);
	}

	public static int extractFourthRankedCard(int aHandValue) {
		return (((aHandValue) >> FOURTH_CARD_SHIFT) & CARD_MASK);
	}

	public static int extractFifthRankedCard(int aHandValue) {
		return (((aHandValue) >> FIFTH_CARD_SHIFT) & CARD_MASK);
	}

	private static int HANDTYPE_VALUE(HandTypes ht) {

		if(ht == null)
			throw new IllegalArgumentException("null hand type");

		return ((ht.ordinal()) << HANDTYPE_SHIFT);
	}

	private static int TOP_CARD_VALUE(int c) {
		return ((c) << TOP_CARD_SHIFT);
	}

	private static int SECOND_CARD_VALUE(int c) {
		return ((c) << SECOND_CARD_SHIFT);
	}

	private static int THIRD_CARD_VALUE(int c) {
		return ((c) << THIRD_CARD_SHIFT);
	}

	private static int CardMask(long cards, int suit) {
		return (int)((cards >> (13 * suit)) & 0x1fffL);
	}

	public static String MaskToString(long mask) {

		StringBuilder builder = new StringBuilder();

		int count = 0;
        for (int i = 51; i >= 0; i--)
        {
            if (((1L << i) & mask) != 0)
            {
                if (count != 0)
                {
                    builder.append(" ");
                }
                builder.append(HandEngine._cardTable[i]);
                count++;
            }
        }
        return builder.toString();
	}

	public static HandTypes EvaluateType(long mask) {
        int cards = BitCount(mask);
        if (cards <= 0 || cards > 7) throw new IllegalArgumentException("mask");
        return EvaluateType(mask, cards);
	}

	/**
	 * This function is faster (but provides less information) than Evaluate.
	 *
	 * @param mask card mask
	 * @param cards number of cards in mask
	 * @return HandType enum that describes the rank of the hand
	 */
	public static HandTypes EvaluateType(long mask, int cards) {

		HandTypes is_st_or_fl = HandTypes.HighCard;

        int ss = (int)((mask >> (SPADE_OFFSET)) & 0x1fffL);
        int sc = (int)((mask >> (CLUB_OFFSET)) & 0x1fffL);
        int sd = (int)((mask >> (DIAMOND_OFFSET)) & 0x1fffL);
        int sh = (int)((mask >> (HEART_OFFSET)) & 0x1fffL);

        int ranks = sc | sd | sh | ss;
        int rankinfo = _bitsAndStrTable[ranks];
        int n_dups = cards - (rankinfo >> 2);

        if ((rankinfo & 0x01) != 0) {
            if ((rankinfo & 0x02) != 0)
                is_st_or_fl = HandTypes.Straight;

            int t = _bitsAndStrTable[ss] | _bitsAndStrTable[sc] | _bitsAndStrTable[sd] | _bitsAndStrTable[sh];

            if ((t & 0x01) != 0)
            {
                if ((t & 0x02) != 0)
                    return HandTypes.StraightFlush;
                else
                    is_st_or_fl = HandTypes.Flush;
            }

            if (is_st_or_fl.ordinal() != 0 && n_dups < 3)
                return is_st_or_fl;
        }

        switch (n_dups)
        {
            case 0:
                return HandTypes.HighCard;
            case 1:
                return HandTypes.Pair;
            case 2:
                return ((ranks ^ (sc ^ sd ^ sh ^ ss)) != 0) ? HandTypes.TwoPair : HandTypes.Trips;
            default:
                if (((sc & sd) & (sh & ss)) != 0) return HandTypes.FourOfAKind;
                else if ((((sc & sd) | (sh & ss)) & ((sc & sh) | (sd & ss))) != 0) return HandTypes.FullHouse;
                else if (is_st_or_fl.ordinal() != 0) return is_st_or_fl;
                else return HandTypes.TwoPair;
        }
	}

	/**
	 * Evaluates a hand (passed as a hand mask) and returns a hand value.
	 * A hand value can be compared against another hand value to determine
	 * which has the higher value.
	 *
	 * @param cards hand mask
	 * @return Hand Value bit field
	 */
	public static int Evaluate(long cards) {
		return Evaluate(cards, BitCount(cards));
	}

	/**
	 * Evaluates a hand (passed as a string) and returns a hand value.
	 * A hand value can be compared against another hand value to determine
	 * which has the higher value.
	 *
	 * @param hand
	 * @return
	 */
	public static int Evaluate(String hand) {
		return Evaluate(HandEngine.parseHand(hand));
	}

	private static final int HANDTYPE_VALUE_STRAIGHTFLUSH =
		((HandTypes.StraightFlush.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_STRAIGHT =
		((HandTypes.Straight.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_FLUSH =
		((HandTypes.Flush.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_FULLHOUSE =
		((HandTypes.FullHouse.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_FOUR_OF_A_KIND =
		((HandTypes.FourOfAKind.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_TRIPS =
		((HandTypes.Trips.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_TWOPAIR =
		((HandTypes.TwoPair.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_PAIR =
		((HandTypes.Pair.ordinal()) << HANDTYPE_SHIFT);

	private static final int HANDTYPE_VALUE_HIGHCARD =
		((HandTypes.HighCard.ordinal()) << HANDTYPE_SHIFT);

	public static final int SPADE_OFFSET = 13 * Suit.Spades.ordinal();

	public static final int CLUB_OFFSET = 13 * Suit.Clubs.ordinal();

	public static final int DIAMOND_OFFSET = 13 * Suit.Diamonds.ordinal();

	public static final int HEART_OFFSET = 13 * Suit.Hearts.ordinal();

	/**
	 * Evaluates a hand (passed as a hand mask) and returns a hand value.
	 * A hand value can be compared against another hand value to determine
	 * which has the higher value.
	 *
	 * @param cards hand mask
	 * @param numberOfCards number of cards in the hand
	 * @return hand value
	 */
	public static int Evaluate(long cards, int numberOfCards) {

		int retval = 0, four_mask, three_mask, two_mask;

		// This functions supports 1-7 cards
		if(numberOfCards < 1 || numberOfCards > 7)
			throw new ArgumentOutOfRangeException("numberOfCards");

        // Seperate out by suit
        int sc = (int)((cards >> (CLUB_OFFSET)) & 0x1fffL);
        int sd = (int)((cards >> (DIAMOND_OFFSET)) & 0x1fffL);
        int sh = (int)((cards >> (HEART_OFFSET)) & 0x1fffL);
        int ss = (int)((cards >> (SPADE_OFFSET)) & 0x1fffL);

        int ranks = sc | sd | sh | ss;
        int n_ranks = _bitsTable[ranks];
        int n_dups = numberOfCards - n_ranks;

        // Check for straight, flush, or straight flush, and return if we can
        // determine immediately that this is the best possible hand
        if(n_ranks >= 5) {
            if(_bitsTable[ss] >= 5) {
                if(_straightTable[ss] != 0) {
                    return HANDTYPE_VALUE_STRAIGHTFLUSH +
                    	(_straightTable[ss] << TOP_CARD_SHIFT);
                }
                else
                    retval = HANDTYPE_VALUE_FLUSH + _topFiveCardsTable[ss];
            }
            else if(_bitsTable[sc] >= 5) {
                if(_straightTable[sc] != 0) {
                    return HANDTYPE_VALUE_STRAIGHTFLUSH +
                    	(_straightTable[sc] << TOP_CARD_SHIFT);
                }
                else
                    retval = HANDTYPE_VALUE_FLUSH + _topFiveCardsTable[sc];
            }
            else if(_bitsTable[sd] >= 5)
            {
                if(_straightTable[sd] != 0) {
                    return HANDTYPE_VALUE_STRAIGHTFLUSH +
                    	(_straightTable[sd] << TOP_CARD_SHIFT);
                }
                else
                    retval = HANDTYPE_VALUE_FLUSH + _topFiveCardsTable[sd];
            }
            else if(_bitsTable[sh] >= 5)
            {
                if(_straightTable[sh] != 0) {
                    return HANDTYPE_VALUE_STRAIGHTFLUSH +
                    	(_straightTable[sh] << TOP_CARD_SHIFT);
                }
                else
                    retval = HANDTYPE_VALUE_FLUSH + _topFiveCardsTable[sh];
            }
            else
            {
                int st = _straightTable[ranks];
                if(st != 0)
                    retval = HANDTYPE_VALUE_STRAIGHT + (st << TOP_CARD_SHIFT);
            };

            /*
               Another win -- if there can't be a FH/Quads (n_dups < 3),
               which is true most of the time when there is a made hand, then if we've
               found a five card hand, just return.  This skips the whole process of
               computing two_mask/three_mask/etc.
            */
            if(retval != 0 && n_dups < 3)
                return retval;
        }

        /*
         * By the time we're here, either:
           1) there's no five-card hand possible (flush or straight), or
           2) there's a flush or straight, but we know that there are enough
              duplicates to make a full house / quads possible.
         */
        switch (n_dups)
        {
            case 0:
                /* It's a no-pair hand */
                return HANDTYPE_VALUE_HIGHCARD + _topFiveCardsTable[ranks];
            case 1:
                {
                    /* It's a one-pair hand */
                    int t, kickers;

                    two_mask = ranks ^ (sc ^ sd ^ sh ^ ss);

                    retval = HANDTYPE_VALUE_PAIR + (_topCardTable[two_mask] << TOP_CARD_SHIFT);
                    t = ranks ^ two_mask;  /* Only one bit set in two_mask */
                    /* Get the top five cards in what is left, drop all but the top three
                     * cards, and shift them by one to get the three desired kickers */
                    kickers = (_topFiveCardsTable[t] >> CARD_WIDTH) & ~FIFTH_CARD_MASK;
                    retval += kickers;
                    return retval;
                }

            case 2:
                /* Either two pair or trips */
                two_mask = ranks ^ (sc ^ sd ^ sh ^ ss);
                if(two_mask != 0)
                {
                    int t = ranks ^ two_mask; /* Exactly two bits set in two_mask */
                    retval = HANDTYPE_VALUE_TWOPAIR
                        + (_topFiveCardsTable[two_mask]
                        & (TOP_CARD_MASK | SECOND_CARD_MASK))
                        + (_topCardTable[t] << THIRD_CARD_SHIFT);

                    return retval;
                }
                else
                {
                    int t, second;
                    three_mask = ((sc & sd) | (sh & ss)) & ((sc & sh) | (sd & ss));
                    retval = HANDTYPE_VALUE_TRIPS + (_topCardTable[three_mask] << TOP_CARD_SHIFT);
                    t = ranks ^ three_mask; /* Only one bit set in three_mask */
                    second = _topCardTable[t];
                    retval += (second << SECOND_CARD_SHIFT);
                    t ^= (1 << second);
                    retval += _topCardTable[t] << THIRD_CARD_SHIFT;
                    return retval;
                }

            default:
                /* Possible quads, fullhouse, straight or flush, or two pair */
                four_mask = sh & sd & sc & ss;
                if(four_mask != 0)
                {
                    int tc = _topCardTable[four_mask];
                    retval = HANDTYPE_VALUE_FOUR_OF_A_KIND
                        + (tc << TOP_CARD_SHIFT)
                        + ((_topCardTable[ranks ^ (1 << tc)]) << SECOND_CARD_SHIFT);
                    return retval;
                };

                /* Technically, three_mask as defined below is really the set of
                   bits which are set in three or four of the suits, but since
                   we've already eliminated quads, this is OK */
                /* Similarly, two_mask is really two_or_four_mask, but since we've
                   already eliminated quads, we can use this shortcut */

                two_mask = ranks ^ (sc ^ sd ^ sh ^ ss);
                if(_bitsTable[two_mask] != n_dups)
                {
                    /* Must be some trips then, which really means there is a
                       full house since n_dups >= 3 */
                    int tc, t;
                    three_mask = ((sc & sd) | (sh & ss)) & ((sc & sh) | (sd & ss));
                    retval = HANDTYPE_VALUE_FULLHOUSE;
                    tc = _topCardTable[three_mask];
                    retval += (tc << TOP_CARD_SHIFT);
                    t = (two_mask | three_mask) ^ (1 << tc);
                    retval += _topCardTable[t] << SECOND_CARD_SHIFT;
                    return retval;
                };

                if(retval != 0) /* flush and straight */
                    return retval;
                else
                {
                    /* Must be two pair */
                    int top, second;

                    retval = HANDTYPE_VALUE_TWOPAIR;
                    top = _topCardTable[two_mask];
                    retval += (top << TOP_CARD_SHIFT);
                    second = _topCardTable[two_mask ^ (1 << top)];
                    retval += (second << SECOND_CARD_SHIFT);
                    retval += (_topCardTable[ranks ^ (1 << top) ^ (1 << second)]) << THIRD_CARD_SHIFT;
                    return retval;
                }
        }
	}

	/**
	 * @return positive value if first hand is better, zero if two hands are
	 * 	equivalent, negative value if second hand is better
	 */
	public static int compareTwoHands(int aHandValue1, int aHandValue2) {
		return aHandValue1 - aHandValue2;
	}

    /**
     * Given a pocket pair mask, returns the PocketPairType corresponding to this mask.
     */
    public static PocketHand169Enum PocketHand169Type(long mask) {

    	if(BitCount(mask) != 2)
    		throw new ArgumentOutOfRangeException(
    				"mask must contain exactly 2 cards");

    	// Fill in dictionary
    	if(_pocketDictionary.size() == 0) {
            for(int i = 0; i < _pocket169Table.length; i++) {
                for(long tmask : _pocket169Table[i]) {
                    _pocketDictionary.put(tmask, PocketHand169Enum.values()[i]);
                }
            }
        }

    	if(_pocketDictionary.containsKey(mask))
            return _pocketDictionary.get(mask);

        return PocketHand169Enum.None;
    }

    /**
     * Enables a foreach to enumerate all possible ncard hands.
     *
     * @param numberOfCards the number of cards in the hand
     * 	(must be between 1 and 7)
     * @return enumeration with a valid iterator
     * FROM:HandIterator.cs
     */
    public static Iterable<Long> Hands(final int numberOfCards) {
    	return new Iterable<Long>() {
    		@Override
            public HandIterator iterator() {
    			return new HandIterator(numberOfCards);
    		}
    	};
    }

    /**
     * Enables a foreach command to enumerate all possible ncard hands.
     *
     * @param shared Cards that must be in the hand.
     * @param dead Cards that must not be in the hand.
     * @param numberOfCards The total number of cards in the hand, including shared.
     * @return enumeration with a valid iterator
     * FROM:HandIterator.cs
     */
    public static Iterable<Long> Hands(
    		final long shared, final long dead, final int numberOfCards) {

    	return new Iterable<Long>() {
    		@Override
            public HandIteratorEx iterator() {
    			return new HandIteratorEx(shared, dead, numberOfCards);
    		}
    	};
    }

    /**
     * Returns a random hand with the specified number of cards and constrained
     * to not contain any of the passed dead cards.
     *
     * @param dead Mask for the cards that must not be returned.
     * @param ncards The number of cards to return in this hand.
     * @param rand An instance of the Random class.
     * @return A randomly chosen hand containing the number of cards requested.
     * FROM:HandIterator.cs
     */
    static long GetRandomHand(long dead, int ncards, Random rand) {

        long mask = 0L, card;

        for(int i = 0; i < ncards; i++) {
            do {
                card = _cardMasksTable[rand.nextInt(52)];
            } while (((dead | mask) & card) != 0);
            mask |= card;
        }

        return mask;
    }

    /**
     * This function iterates through random hands returning the number of
     * random hands specified in trials. Please note that a mask can be
     * repeated.
     *
     * @param shared Cards that must be in the hand.
     * @param dead Cards that must not be in the hand.
     * @param ncards The total number of cards in the hand, including shared.
     * @param trials The total number of random hands to return.
     * @return A random hand mask meeting the input specifications.
     * FROM:HandIterator.cs
     */
    public static Iterable<Long> RandomHands(
    	final long shared, final long dead, final int ncards, final int trials) {

    	return new Iterable<Long>() {
    		@Override
            public RandomHandIterator iterator() {
    			return new RandomHandIterator(shared, dead, ncards, trials);
    		}
    	};
    }

    /**
     * Iterates through random hands with ncards number of cards. This iterator
     * will return the number of masks specifed in trials. Masks can be
     * repeated.
     *
     * @param ncards Number of cards required to be in the hand.
     * @param trials Number of total mask to return.
     * @return A random hand as a hand mask.
     * FROM:HandIterator.cs
     */
    public static Iterable<Long> RandomHands(int ncards, int trials) {
    	return RandomHands(0L, 0L, ncards, trials);
    }

    /**
     * Fast Bitcounting method (adapted from snippets.org)
     *
     * @param bitField long to count
     * @return number of set bits in long argument
     */
    public static int BitCount(long bitField) {

    	return
        	_bitCountTable[(int)(bitField & 0x00000000000000FFL)] +
        	_bitCountTable[(int)((bitField & 0x000000000000FF00L) >> 8)] +
        	_bitCountTable[(int)((bitField & 0x0000000000FF0000L) >> 16)] +
        	_bitCountTable[(int)((bitField & 0x00000000FF000000L) >> 24)] +
        	_bitCountTable[(int)((bitField & 0x000000FF00000000L) >> 32)] +
        	_bitCountTable[(int)((bitField & 0x0000FF0000000000L) >> 40)] +
        	_bitCountTable[(int)((bitField & 0x00FF000000000000L) >> 48)] +
        	_bitCountTable[(int)((bitField & 0xFF00000000000000L) >> 56)];
    }

	/**
	 * Calculates the wining information about each players hand. Enumerates
	 * all possible remaining hands and tallies win, tie and losses for each
	 * player. This function typically takes well less than a second regardless
	 * of the number of players.
	 *
	 * @param pockets Array of pocket hand string, one for each player
	 * @param board the board cards
	 * @param dead the dead cards
	 * @param wins An array of win tallies, one for each player
	 * @param ties An array of tie tallies, one for each player
	 * @param losses An array of losses tallies, one for each player
	 * @param totalHands The total number of hands enumarated
	 */
	public static void HandOdds(String[] pockets, String board, String dead,
			long[] wins, long[] ties, long[] losses, long[] totalHands) {

        long[] pocketmasks = new long[pockets.length];
        long[] pockethands = new long[pockets.length];

        IntegerRef count = new IntegerRef(0);
        int bestcount;

        long boardmask = 0L, deadcards_mask = 0L;
        long deadcards = HandEngine.parseHand(dead, count);

        totalHands[0] = 0;
        deadcards_mask |= deadcards;

        // Read pocket cards
        for (int i = 0; i < pockets.length; i++)
        {
            count.set(0);
            pocketmasks[i] = HandEngine.parseHand(pockets[i], "", count);
            if (count.get() != 2) {
            	// Must have 2 cards in each pocket card set.
                throw new IllegalArgumentException("There must be two pocket cards.");
            }
            deadcards_mask |= pocketmasks[i];
            wins[i] = ties[i] = losses[i] = 0;
        }

        // Read board cards
        count.set(0);
        boardmask = HandEngine.parseHand("", board, count);

        // The board must have zero or more cards but no more than a total of 5
        if(!(count.get() >= 0 && count.get() <= 5))
        	throw new IllegalArgumentException("Board must have zero or more cards, but max 5");

        // Check pocket cards, board, and dead cards for duplicates
        if((boardmask & deadcards) != 0)
            throw new IllegalArgumentException("Duplicate between dead cards and board");

        // Validate the input
        for(int i = 0; i < pockets.length; i++) {
            for(int j = i + 1; j < pockets.length; j++) {
                if((pocketmasks[i] & pocketmasks[j]) != 0)
                    throw new IllegalArgumentException("Duplicate pocket cards");
            }

            if((pocketmasks[i] & boardmask) != 0)
                throw new IllegalArgumentException("Duplicate between cards pocket and board");

            if((pocketmasks[i] & deadcards) != 0)
            	throw new IllegalArgumentException("Duplicate between cards pocket and dead cards");
        }

        // Iterate through all board possiblities that doesn't include any pocket cards.
        for(long boardhand : Hands(boardmask, deadcards_mask, 5))
        {
            // Evaluate all hands and determine the best hand
            long bestpocket = Evaluate(pocketmasks[0] | boardhand, 7);
            pockethands[0] = bestpocket;
            bestcount = 1;
            for(int i = 1; i < pockets.length; i++) {
                pockethands[i] = Evaluate(pocketmasks[i] | boardhand, 7);
                if(pockethands[i] > bestpocket) {
                    bestpocket = pockethands[i];
                    bestcount = 1;
                }
                else if (pockethands[i] == bestpocket) {
                    bestcount++;
                }
            }

            // Calculate wins/ties/loses for each pocket + board combination.
            for(int i = 0; i < pockets.length; i++) {
                if(pockethands[i] == bestpocket) {
                    if(bestcount > 1)
                        ties[i]++;
                    else
                        wins[i]++;
                }
                else if (pockethands[i] < bestpocket) {
                    losses[i]++;
                }
            }

            totalHands[0]++;
        }
	}

	/**
	 * Returns the number of outs possible with the next card.
	 *
	 * @param player Players pocket cards
	 * @param board The board (must contain either 3 or 4 cards)
	 * @param opponents A list of zero or more opponent cards.
	 * @return The count of the number of single cards that improve the current
	 * 	hand.
	 */
	public static int Outs(long player, long board, long[] opponents) {
		return BitCount(OutsMask(player, board, opponents));
	}

	public static int Outs(long player, long board) {
		return Outs(player, board, new long[0]);
	}

	/**
	 * Creates a Hand mask with the cards that will improve the specified
	 * players hand against a list of opponents or if no opponents are listed
	 * just the cards that improve the players current had. Please note that
	 * this only looks at single cards that improve the hand and will not
	 * specifically look at runner-runner possiblities.
	 *
	 * @param player Players pocket cards
	 * @param board The board (must contain either 3 or 4 cards)
	 * @param opponents A list of zero or more opponent pocket cards
	 * @return A mask of all of the cards taht improve the hand.
	 */
	public static long OutsMask(long player, long board, long[] opponents) {

		long retval = 0L, dead = 0L;
        int ncards = HandEngine.BitCount(player | board);

        // Must have two cards for a legit set of pocket cards
        assert(HandEngine.BitCount(player) == 2);
        if(ncards != 5 && ncards != 6) {
            throw new IllegalArgumentException(
            		"Outs only make sense after the flop and before the river");
        }

        if(opponents.length > 0) {
            // Check opportunities to improve against one or more opponents
            for(long opp : opponents) {
            	// Must have two cards for a legit set of pocket cards
                assert(HandEngine.BitCount(opp) == 2);
                dead |= opp;
            }

            int playerOrigHandVal = HandEngine.Evaluate(player | board, ncards);
            int playerOrigHandType = HandEngine.computeHandType(playerOrigHandVal);
            int playerOrigTopCard = HandEngine.extractTopRankedCard(playerOrigHandVal);
            //_log.debug("playerOrigHandVal: " + playerOrigHandVal + " playerOrigHandType: " + playerOrigHandType + " playerOrigTopCard: " + playerOrigTopCard);

            for(long card : HandEngine.Hands(0L, dead | board | player, 1)) {
            	// _log.debug("card: " + card);
                boolean bWinFlag = true;
                //int[] ncards1 = new int[]{ncards[0]+1};
                //ncards[0]++;
                int playerHandVal = HandEngine.Evaluate(player | board | card, ncards+1);
                int playerNewHandType = HandEngine.computeHandType(playerHandVal);
                int playerNewTopCard = HandEngine.extractTopRankedCard(playerHandVal);
                //_log.debug("playerHandVal: " + playerHandVal + " playerNewHandType: " + playerNewHandType + " playerNewTopCard: " + playerNewTopCard);

                for(long oppmask : opponents) {
                	//int[] ncards2 = new int[]{ncards[0]+1};
                	//ncards[0]++;
                	int oppHandVal = HandEngine.Evaluate(oppmask | board | card, ncards+1);

                    bWinFlag = oppHandVal < playerHandVal && (playerNewHandType > playerOrigHandType || (playerNewHandType == playerOrigHandType && playerNewTopCard > playerOrigTopCard));
                    if (!bWinFlag)
                        break;
                }
                if (bWinFlag)
                    retval |= card;
            }
        }
        else
        {
            // Look at the cards that improve the hand.
            int playerOrigHandVal = HandEngine.Evaluate(player | board, ncards);
            int playerOrigHandType = HandEngine.computeHandType(playerOrigHandVal);
            int playerOrigTopCard = HandEngine.extractTopRankedCard(playerOrigHandVal);

            // Look ahead one card
            for(long card : HandEngine.Hands(0L, dead | board | player, 1)) {
                int playerNewHandVal = HandEngine.Evaluate(player | board | card, ncards+1);
                int playerONewHandType = HandEngine.computeHandType(playerNewHandVal);
                int playerNewTopCard = HandEngine.extractTopRankedCard(playerNewHandVal);
                if (playerONewHandType > playerOrigHandType || (playerONewHandType == playerOrigHandType && playerNewTopCard > playerOrigTopCard))
                    retval |= card;
            }
        }

        return retval;
	}

	/**
	 * This function returns true if the cards in the hand are all one suit.
	 *
	 * @param mask hand to check for "suited-ness"
	 * @return true if all hands are of the same suit, false otherwise.
	 */
	public static boolean IsSuited(long mask) {

		int cards = HandEngine.BitCount(mask);

        int sc = HandEngine.CardMask(mask, Suit.Clubs.ordinal());
        int sd = HandEngine.CardMask(mask, Suit.Diamonds.ordinal());
        int sh = HandEngine.CardMask(mask, Suit.Hearts.ordinal());
        int ss = HandEngine.CardMask(mask, Suit.Spades.ordinal());

        return  HandEngine.BitCount(sc) == cards || HandEngine.BitCount(sd) == cards ||
        	HandEngine.BitCount(sh) == cards || HandEngine.BitCount(ss) == cards;
	}

    /**
     * Returns true if the cards in the two card hand are connected.
     *
     * @param mask the hand to check
     * @return true of all of the cards are next to each other.
     */
    public static boolean IsConnected(long mask) {
        return HandEngine.GapCount(mask) == 0;
    }

    /**
     * Counts the number of empty space between adjacent cards. 0 means
     * connected, 1 means a gap of one, 2 means a gap of two and 3 means a gap
     * of three.
     *
     * @param mask two card hand mask
     * @return number of spaces between two cards
     */
    public static int GapCount(long mask) {

        if(HandEngine.BitCount(mask) != 2) return -1;

    	int start, end;
        int bf = HandEngine.CardMask(mask, Suit.Clubs.ordinal()) |
        			HandEngine.CardMask(mask, Suit.Diamonds.ordinal()) |
        			HandEngine.CardMask(mask, Suit.Hearts.ordinal()) |
        			HandEngine.CardMask(mask, Suit.Spades.ordinal());

        if(HandEngine.BitCount(bf) != 2) return -1;

        for(start = 12; start >= 0; start--) {
            if ((bf & (1L << start)) != 0)
                break;
        }

        for(end = start - 1; end >= 0; end--) {
            if ((bf & (1L << end)) != 0)
                break;
        }

        // Handle wrap
        if(start == 12 && end == 0) return 0;
        if(start == 12 && end == 1) return 1;
        if(start == 12 && end == 2) return 2;
        if(start == 12 && end == 3) return 3;

        return start-end-1;
    }

    public static void HandPlayerOpponentOdds(long ourcards, long board, /*ref*/ double[] player, /*ref*/ double[] opponent) {
    	HandEngine.HandPlayerOpponentOdds(
    			ourcards, board, player, opponent, null);
    }

	/**
	 * Given a set of pocket cards and a set of board cards this function
	 * returns the odds of winning or tying for a player and a random opponent.
	 * If last parameter is passed as null, then results will be divided by
	 * total hands evaluated to effectively return the percentage, otherwise
	 * results will not be divided, and instead total hands evaluated will be
	 * returned back to the caller.
	 *
	 * @param ourcards Pocket mask for the hand.
	 * @param board Board mask for hand
	 * @param player Player odds as doubles, must be size 9
	 * @param opponent Opponent odds as doubles, must be size 9
	 * @param aHandsEv Returned number of evaluated hands
	 */
	public static void HandPlayerOpponentOdds(long ourcards, long board, /*ref*/ double[] player, /*ref*/ double[] opponent, long[] aHandsEv) {
        int ourbest, oppbest;
        int count = 0;
        //int cards = Hand.BitCount(ourcards | board);
        int boardcount = HandEngine.BitCount(board);

        // Preconditions
        if(HandEngine.BitCount(ourcards) != 2)
        	throw new ArgumentOutOfRangeException("pocketcards");
        if(boardcount > 5)
        	throw new ArgumentOutOfRangeException("boardcards");
        if(player.length != opponent.length || player.length != 9)
        	throw new ArgumentOutOfRangeException();

        // Use precalcuated results for pocket cards
        if(boardcount == 0) {
            int index = HandEngine.PocketHand169Type(ourcards).getValue();
            double[] p = HandEngine._preCalcPlayerOddsTable[index];
            for(int x=0; x<p.length; ++x) player[x] = p[x];
            double[] o = HandEngine._preCalcOppOddsTable[index];
            for(int x=0; x<o.length; ++x) opponent[x] = o[x];
            return;
        }

        // initialize return values
        for(int i = 0; i < player.length; i++) {
            player[i] = opponent[i] = 0.0;
        }

        // Calculate results
        for(long oppcards : Hands(0L, ourcards | board, 2)) {
            for(long handmask : Hands(board, ourcards | oppcards, 5)) {
                ourbest = Evaluate(ourcards | handmask, 7);
                oppbest = Evaluate(oppcards | handmask, 7);
                if(ourbest > oppbest) {
                    player[computeHandType(ourbest)] += 1.0;
                    count++;
                }
                else if(ourbest == oppbest) {
                    player[computeHandType(ourbest)] += 0.5;
                    opponent[computeHandType(oppbest)] += 0.5;
                    count++;
                }
                else {
                    opponent[computeHandType(oppbest)] += 1.0;
                    count++;
                }
            }
        }

        if(aHandsEv == null) {
	        for(int i = 0; i < 9; i++) {
	            player[i] = player[i] / count;
	            opponent[i] = opponent[i] / count;
	        }
        }
        else
        	aHandsEv[0] = count;
	}

	/**
	 * Convinience function which calls {@link #HandPlayerOpponentOdds(long, long, double[], double[])}
	 * but parser pocket cards and board cards arguments first.
	 *
	 * @param pocketcards Pocket cards in ASCII
	 * @param boardcards Board cards in ASCII
	 * @param player Player odds as doubles, must be size 9
	 * @param opponent Opponent odds as doubles, must be size 9
	 */
	public static void HandPlayerOpponentOdds(
			String pocketcards, String boardcards,
			/*ref*/ double[] player, /*ref*/ double[] opponent) {

		long pCards = HandEngine.parseHand(pocketcards);
		long bCards = HandEngine.parseHand(boardcards);

		HandEngine.HandPlayerOpponentOdds(pCards, bCards, player, opponent);
	}

	/**
	 * Internal function used by HandPotential.
	 *
	 * @param ourcards
	 * @param board
	 * @param oppcards
	 * @param index
	 * @param HP
	 */
	private static void HandPotentialOpp(long ourcards, long board, long oppcards, int index, /*ref*/ int[][] HP) {

		final int ahead = 2;
        final int tied = 1;
        final int behind = 0;
        //long dead_cards = ourcards | board | oppcards;
        int ourbest, oppbest;

        for(long handmask : HandEngine.Hands(0L, ourcards | board | oppcards, 7 - HandEngine.BitCount(ourcards | board)))
        {
            ourbest = Evaluate(ourcards | board | handmask, 7);
            oppbest = Evaluate(oppcards | board | handmask, 7);
            if (ourbest > oppbest)
                (HP[index][ahead])++;
            else if (ourbest == oppbest)
                (HP[index][tied])++;
            else
                (HP[index][behind])++;
        }
	}

	/**
	 * Returns the positive and negative potential of the current hand. This
	 * funciton is described in Aaron Davidson's masters thesis
	 * (davidson.msc.pdf).
	 *
	 * @param pocket Hold Cards
	 * @param board Community cards
	 * @param ppot Positive Potential
	 * @param npot Negative Potential
	 */
	public static void HandPotential(long pocket, long board, /*out*/ double[] ppot, /*out*/ double[] npot) {

		final int ahead = 2;
        final int tied = 1;
        final int behind = 0;

        int[][] HP = new int[3][3];
        int[] HPTotal = new int[3];
        int cards = HandEngine.BitCount(pocket | board);
        double mult = (cards == 5 ? 990.0 : 45.0);

        if (cards < 5 || cards > 7)
            throw new ArgumentOutOfRangeException();

        // Initialize
        for (int i = 0; i < 3; i++) {
            HPTotal[i] = 0;
            for (int j = 0; j < 3; j++) {
                HP[i][j] = 0;
            }
        }

        // Rank our hand
        int ourrank = Evaluate(pocket | board, BitCount(pocket | board));

        // Mark known cards as dead.
        long dead_cards = pocket | board;

        // Iterate through all possible opponent pocket cards
        for(long oppPocket : Hands(0L, dead_cards, 2)) {
            // Note Current State
            int opprank = Evaluate(oppPocket | board, BitCount(oppPocket | board));
            if(ourrank > opprank) {
                HandPotentialOpp(pocket, board, oppPocket, ahead, /*ref*/ HP);
                HPTotal[ahead]++;
            }
            else if (ourrank == opprank) {
                HandPotentialOpp(pocket, board, oppPocket, tied, /*ref*/ HP);
                HPTotal[tied]++;
            }
            else {
                HandPotentialOpp(pocket, board, oppPocket, behind, /*ref*/ HP);
                HPTotal[behind]++;
            }
        }

        double den1 = (mult * (HPTotal[behind] + (HPTotal[tied] / 2.0)));
        double den2 = (mult * (HPTotal[ahead] + (HPTotal[tied] / 2.0)));
        if (den1 > 0)
            ppot[0] = (HP[behind][ahead] + (HP[behind][tied] / 2) + (HP[tied][ahead] / 2)) / den1;
        else
            ppot[0] = 0;
        if (den2 > 0)
            npot[0] = (HP[ahead][behind] + (HP[ahead][tied] / 2) + (HP[tied][behind] / 2)) / den2;
        else
            npot[0] = 0;
	}

	/**
	 * Returns hand strength (HS) given a player's hand, board cards and
	 * total number of players at the table (including this player).
	 *
	 * @param aPlayer
	 * @param aBoard
	 * @param aPlayerCount
	 * @return
	 */
	public static double getHS(long aPlayer, long aBoard, int aPlayerCount) {

		int boardCount = HandEngine.BitCount(aBoard);
		int playerBest = Evaluate(aPlayer | aBoard, 2+boardCount);
		int wins, ties; wins = ties = 0;
		int count = 0;
        for(long oppcards : Hands(0L, aPlayer | aBoard, 2)) {
        	int oppBest = Evaluate(oppcards | aBoard, 2+boardCount);
        	if(playerBest > oppBest)
        		wins++;
        	else if(playerBest == oppBest)
        		ties++;

        	count++;
        }
		double hs = (wins + (ties * 0.5D)) / count;
		if(aPlayerCount > 2) hs = Math.pow(hs, aPlayerCount);

		if(log.isTraceEnabled())
			log.trace("hs: " + hs + " hands evaluated: " + count);

		return hs;
	}

	public static double getHS(String aPlayer, String aBoard, int aPlayerCount) {
		long thePlayer = HandEngine.parseHand(aPlayer);
		long theBoard = HandEngine.parseHand(aBoard);
		return getHS(thePlayer, theBoard, aPlayerCount);
	}

	/**
	 * Calculates effective hand strength given a player, board cards and
	 * total players at the table (including this player). Effective hand
	 * strength takes into account a hand strength as well as hand potential.
	 *
	 * @param aPlayer
	 * @param aBoard
	 * @param aPlayerCount
	 * @return
	 */
	public static double getEHS(long aPlayer, long aBoard, int aPlayerCount) {

        double hs = HandEngine.getHS(aPlayer, aBoard, aPlayerCount);
		double[] positivePot = new double[1];
		double[] negativePot = new double[1];
		HandEngine.HandPotential(aPlayer, aBoard, positivePot, negativePot);

		double hsPow = Math.pow(hs, aPlayerCount);
		double ehs = hsPow + ((1 - hsPow) * positivePot[0]);

		return ehs;
	}

	public static double getEHS(String aPlayer, String aBoard, int aPlayerCount) {
		long thePlayer = HandEngine.parseHand(aPlayer);
		long theBoard = HandEngine.parseHand(aBoard);
		return getEHS(thePlayer, theBoard, aPlayerCount);
	}
}