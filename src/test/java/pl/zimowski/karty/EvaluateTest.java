package pl.zimowski.karty;

import org.junit.Test;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Iterator;

public class EvaluateTest {

    private static final Logger log = LoggerFactory.getLogger(EvaluateTest.class);

    @Test
    public void testIterator() {
        if (log.isInfoEnabled()) {
            log.info("first run..");
        }
        long count = 0;
        long before = System.currentTimeMillis();
        for (long mask : HandEngine.Hands(5)) {
            count++;
        }
        long after = System.currentTimeMillis();
        if (log.isInfoEnabled()) {
            log.info("TIME: " + (after - before) + " ms, count: " + count);
        }
        if (log.isInfoEnabled()) {
            log.info("measuring..");
        }
        int x = 0;
        int trials = 100;
        long time = 0;
        count = 0;
        before = System.currentTimeMillis();
        while (x++ < trials) {
            Iterator<Long> i = HandEngine.Hands(5).iterator();
            while (i.hasNext()) {
                i.next();
                count++;
            }
        }
        after = System.currentTimeMillis();
        time = (after - before);
        if (log.isInfoEnabled()) {
            log.info("TIME: {} ms, AVG TIME: " + ((double) time / (double) trials) + " ms, count: " + count, time);
        }
    }

    // @Test
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
        String[] test = deal(2, 9);
        for (String t : test) {
            if (log.isInfoEnabled()) {
                log.info(t);
            }
        }
    }

    private String[] deal(int aCards, int aPlayers) {
        int count = 0;
        long board = 0;
        String[] ret = new String[aPlayers];

        for (long i : HandEngine.RandomHands(5, 3)) {
            board = i;
        }

        long dead = board;

        while (count < aPlayers) {
            for (long mask : HandEngine.RandomHands(0L, dead, aCards, 1)) {
                String cards = HandEngine.MaskToString(mask);

                if (log.isDebugEnabled()) {
                    log.debug(count + " cards: " + cards + ", dead: " + HandEngine.MaskToString(dead));
                }
                dead |= mask;
                ret[count] = cards;
            }
            count++;
        }

        // ret[aPlayers] = HandEngine.MaskToString(board);
        return ret;
    }
}
