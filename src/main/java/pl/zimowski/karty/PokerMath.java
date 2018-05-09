package pl.zimowski.karty;

public class PokerMath {

	public static long binomial(int aN, int aK) {

        long[][] binomial = new long[aN+1][aK+1];

        // base cases
        for (int k = 1; k <= aK; k++) binomial[0][k] = 0;
        for (int n = 0; n <= aN; n++) binomial[n][0] = 1;

        // bottom-up dynamic programming
        for (int n = 1; n <= aN; n++)
            for (int k = 1; k <= aK; k++)
                binomial[n][k] = binomial[n-1][k-1] + binomial[n-1][k];

        return binomial[aN][aK];
	}
}
