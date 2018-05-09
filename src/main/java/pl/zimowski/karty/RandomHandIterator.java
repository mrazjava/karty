package pl.zimowski.karty;

import java.util.Iterator;
import java.util.NoSuchElementException;
import java.util.Random;

public class RandomHandIterator implements Iterator<Long> {

	private long shared, dead, deadmask;
	private int ncards, trials, cardcount, loopCount;
	private Random rand;

	public RandomHandIterator(long aShared, long aDead, int aCards, int aTrials) {

        if (aCards < 0 || aCards > 7)
            throw new ArgumentOutOfRangeException("aCards");

		shared = aShared;
		dead = aDead;
		ncards = aCards;
		trials = aTrials;

	    deadmask = dead | shared;
	    cardcount = ncards - HandEngine.BitCount(shared);

	    rand = new Random();
	}

	@Override
    public boolean hasNext() {
		return loopCount < trials;
	}

	@Override
    public Long next() {
		if(loopCount < trials) {
			++loopCount;
			return HandEngine.GetRandomHand(deadmask, cardcount, rand) | shared;
		}
        throw new NoSuchElementException();
	}

	@Override
    public void remove() {
		throw new UnsupportedOperationException();
	}

}
