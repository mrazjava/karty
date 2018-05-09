package pl.zimowski.karty;

import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class BenchmarkTest extends BaseTest {

	private static final Logger _log = LoggerFactory.getLogger(BenchmarkTest.class);

//	public BenchmarkTest() {
//		_log.setLevel(Level.INFO);
//	}

	@Test
	public void fiveCardHandJavaIterator() {

		// dry test is needed here to remove JIT factor from later tests
		if(_log.isDebugEnabled()) _log.debug("running dry first..");
		long count = 0;
		long before = System.currentTimeMillis();
		for(@SuppressWarnings("unused")
		long mask : HandEngine.Hands(5)) count++;
		long after = System.currentTimeMillis();
		if(_log.isDebugEnabled()) {
			long duration = after - before;
			_log.debug(count + " iterations in " + duration + " ms");
			_log.debug((1000L/duration)*count + " hands per second");
			_log.debug("running real benchmark..");
		}

		count = 0;
		before = System.currentTimeMillis();
		for(@SuppressWarnings("unused")
		long mask : HandEngine.Hands(5)) count++;
		after = System.currentTimeMillis();
		if(_log.isInfoEnabled()) {
			long duration = after - before;
			_log.info(count + " iterations in " + duration + " ms");
			_log.info((1000L/duration)*count + " hands per second");
			if(duration > 250) {
				/**
				 * On laptop with specs below fastest ever recorded was 196ms
				 * which gives 12,994,800 hands p/s.
				 */
				_log.warn("Too slow; on Pentium-M 1.6ghz w/HP and 2gig ram " +
						"should run around 200ms. Try reruning this test.");
			}
		}
	}

	@Test
	public void fiveCardHandInlinedIterator() {

		int i1, i2, i3, i4, i5;
		long card1, n2, n3, n4;
		int count = 0;

		i1 = i2 = i3 = i4 = i5 = 0;
		card1 = n2 = n3 = n4 = 0;

		long before = System.currentTimeMillis();
        for(i1 = HandEngine.NUMBER_OF_CARDS - 1; i1 >= 0; i1--) {
            card1 = HandEngine._cardMasksTable[i1];
            for(i2 = i1 - 1; i2 >= 0; i2--) {
                n2 = card1 | HandEngine._cardMasksTable[i2];
                for(i3 = i2 - 1; i3 >= 0; i3--) {
                    n3 = n2 | HandEngine._cardMasksTable[i3];
                    for(i4 = i3 - 1; i4 >= 0; i4--) {
                        n4 = n3 | HandEngine._cardMasksTable[i4];
                        for(i5 = i4 - 1; i5 >= 0; i5--) {
                            @SuppressWarnings("unused")
							long mask = n4 | HandEngine._cardMasksTable[i5];
                            count++;
                        }
                    }
                }
            }
        }
		long after = System.currentTimeMillis();

		if(_log.isInfoEnabled()) {
			long duration = after - before;
			_log.info(count + " iterations in " + duration + " ms");
			_log.info((1000L/duration)*count + " hands per second");
			if(duration > 50) {
				/**
				 * On laptop with specs below, fastest ever recorded was 25ms
				 * which gives rougly 100 million hands per second.
				 */
				_log.warn("Too slow; on Pentium-M 1.6ghz w/HP and 2gig ram " +
						"should run around 200ms. Try reruning this test.");
			}
		}
	}

	@Test
	public void sevenCardHandJavaIterator() {
		// dry test is needed here to remove JIT factor from later tests
		if(_log.isDebugEnabled()) _log.debug("running dry first..");
		long count = 0;
		long before = System.currentTimeMillis();
		for(@SuppressWarnings("unused")
		long mask : HandEngine.Hands(7)) count++;
		long after = System.currentTimeMillis();
		if(_log.isDebugEnabled()) {
			long duration = after - before;
			_log.debug(count + " iterations in " + duration + " ms");
			_log.debug((1000L/duration)*count + " hands per second");
			_log.debug("running real benchmark..");
		}

		count = 0;
		before = System.currentTimeMillis();
		for(@SuppressWarnings("unused")
		long mask : HandEngine.Hands(7)) count++;
		after = System.currentTimeMillis();
		if(_log.isInfoEnabled()) {
			long duration = after - before;
			_log.info(count + " iterations in " + duration + " ms");
			_log.info((int)((1000D/duration)*count) + " hands per second");
			if(duration > 15000) {
				/**
				 * On laptop with specs below, fastest ever recorded was 11221ms
				 * which gives 11,922,694 hands p/s.
				 */
				_log.warn("Too slow; on Pentium-M 1.6ghz w/HP and 2gig ram " +
						"should run around 1.2s. Try reruning this test.");
			}
		}
	}

	@Test
	public void sevenCardHandInlinedIterator() {

		int i1, i2, i3, i4, i5, i6, i7;
		long card1, n2, n3, n4, n5, n6;
		int count = 0;

		i1 = i2 = i3 = i4 = i5 = i6 = i7 = 0;
		card1 = n2 = n3 = n4 = n5 = n6 = 0;

		long before = System.currentTimeMillis();
        for(i1 = HandEngine.NUMBER_OF_CARDS - 1; i1 >= 0; i1--) {
            card1 = HandEngine._cardMasksTable[i1];
            for(i2 = i1 - 1; i2 >= 0; i2--) {
                n2 = card1 | HandEngine._cardMasksTable[i2];
                for(i3 = i2 - 1; i3 >= 0; i3--) {
                    n3 = n2 | HandEngine._cardMasksTable[i3];
                    for(i4 = i3 - 1; i4 >= 0; i4--) {
                        n4 = n3 | HandEngine._cardMasksTable[i4];
                        for(i5 = i4 - 1; i5 >= 0; i5--) {
                            n5 = n4 | HandEngine._cardMasksTable[i5];
                            for(i6 = i5 - 1; i6 >= 0; i6--) {
                                n6 = n5 | HandEngine._cardMasksTable[i6];
                                for(i7 = i6 - 1; i7 >= 0; i7--) {
                                    @SuppressWarnings("unused")
									long mask = n6 | HandEngine._cardMasksTable[i7];
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
        long after = System.currentTimeMillis();

		if(_log.isInfoEnabled()) {
			long duration = after - before;
			_log.info(count + " iterations in " + duration + " ms");
			_log.info((int)((1000D/duration)*count) + " hands per second");
			if(duration > 2000) {
				/**
				 * On laptop with specs below, fastest ever recorded was 1418ms
				 * which gives 94,347,362 hands per second.
				 */
				_log.warn("Too slow; on Pentium-M 1.6ghz w/HP and 2gig ram " +
						"should run around 200ms. Try reruning this test.");
			}
		}
	}

	@Test
	public void fiveCardEvaluateWithJavaIterator() {


		int i1, i2, i3, i4, i5;
		long card1, n2, n3, n4;
		long count = 0; long time = 0;

		i1 = i2 = i3 = i4 = i5 = 0;
		card1 = n2 = n3 = n4 = 0;

        for(i1 = HandEngine.NUMBER_OF_CARDS - 1; i1 >= 0; i1--) {
            card1 = HandEngine._cardMasksTable[i1];
            for(i2 = i1 - 1; i2 >= 0; i2--) {
                n2 = card1 | HandEngine._cardMasksTable[i2];
                for(i3 = i2 - 1; i3 >= 0; i3--) {
                    n3 = n2 | HandEngine._cardMasksTable[i3];
                    for(i4 = i3 - 1; i4 >= 0; i4--) {
                        n4 = n3 | HandEngine._cardMasksTable[i4];
                        for(i5 = i4 - 1; i5 >= 0; i5--) {
                            @SuppressWarnings("unused")
							long mask = n4 | HandEngine._cardMasksTable[i5];
                            long before = System.currentTimeMillis();
                            @SuppressWarnings("unused")
							int hand = HandEngine.Evaluate(mask, 5);
                            long after = System.currentTimeMillis();
                            time += (after-before);
                            count++;
                        }
                    }
                }
            }
        }

		if(_log.isInfoEnabled()) {
			_log.info(count + " evaluations in " + time + " ms");
			_log.info((int)((1000D/time)*count) + " evaluations per second");
		}

	}

}
