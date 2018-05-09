package pl.zimowski.karty;

import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class EvaluateTest extends BaseTest {

	private long _max = 100001;

	private static final Logger _log = LoggerFactory.getLogger(EvaluateTest.class);

//	public EvaluateTest() {
//		_log.setLevel(Level.INFO);
//	}

	@Test
	public void testIterator() {
		if(_log.isInfoEnabled()) _log.info("first run..");
		long count = 0;
		long before = System.currentTimeMillis();
		for(long mask : HandEngine.Hands(5)) count++;
		long after = System.currentTimeMillis();
		if(_log.isInfoEnabled()) {
			_log.info("TIME: " + (after-before) + " ms, count: " + count);
		}
		if(_log.isInfoEnabled()) _log.info("measuring..");
		int x=0;
		int trials = 100;
		long time = 0;
		while(x < trials) {
			before = System.currentTimeMillis();
			for(long mask : HandEngine.Hands(5)) { int b=1; };
			after = System.currentTimeMillis();
			++x;
			time += (after-before);
		}
		if(_log.isInfoEnabled()) {
			_log.info("AVG TIME: " + (double)time/(double)trials + " ms, count: " + count);
		}
	}

	//@Test
	/*
	public void playCs() {

		long time = 0;

		for(int x=0; x<_max; ++x) {
			//String board = "ah 6h qh th jh";
			String[] players = deal(2,2);
			long before = System.currentTimeMillis();
			HandEngine h1 = new HandEngine(players[0], players[2]);
			//Hand h2 = new Hand(players[1], players[2]);
			String h1desc = h1.getDescription();
			//String h2desc = h2.getDescription();

			if(_log.isDebugEnabled()) {
				_log.debug("board: " + players[2]);
				_log.debug("1: [" + players[0] + "] " + h1desc);
				_log.debug("2: [" + players[1] + "] " + h2desc);
			}

			long after = System.currentTimeMillis();
			//if(_log.isInfoEnabled()) _log.info(getTime(before, after));
			if(x > 0) time += (after-before);
		}

		if(_log.isInfoEnabled())
			_log.info("AVG TIME: " + ((double)time / (double)(_max-1)) + " ms");
	}*/

	@Test
	public void runDeal() {
		String[] test = deal(2, 10);
		for(String t : test) {
			if(_log.isInfoEnabled()) _log.info(t);
		}
	}

	private String[] deal(int aCards, int aPlayers) {

		int count = 0;
		long board = 0;
		String[] ret = new String[aPlayers+1];

		for(long i : HandEngine.RandomHands(5, 3)) {
			board = i;
		}

		long dead = board;

		while(count < aPlayers) {
			for(long mask : HandEngine.RandomHands(0L, dead, aCards, 1)) {
				String cards = HandEngine.MaskToString(mask);
				/*
				if(_log.isDebugEnabled()) {
					_log.debug(count + " cards: " + cards +
							", dead: " + Hand.MaskToString(dead));
				}
				*/
				dead |= mask;
				ret[count] = cards;
			}
			count++;
		}
		ret[aPlayers] = HandEngine.MaskToString(board);
		return ret;
	}
}
