package pl.zimowski.karty;

public class BaseTest {

	protected String getTime(long aBefore, long aAfter) {
		return "TIME: " + (aAfter-aBefore) + " ms";
	}
}
