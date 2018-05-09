package pl.zimowski.karty;

/**
 * Mutable integer representing a wrapper to native type which can be passed
 * by reference.
 *
 * @author Adam Zimowski
 */
public class IntegerRef {

	private int _value = 0;

	public IntegerRef() {
	}

	public IntegerRef(int aValue) {
		_value = aValue;
	}

	/**
	 * Increments value by one.
	 *
	 * @return last value prior to increment
	 */
	public int increment() {
		return _value++;
	}

	/**
	 * Decrements value by one.
	 */
	public int decrement() {
		return _value--;
	}

	public void set(int aNewValue) {
		_value = aNewValue;
	}

	/**
	 * @return actual integer value held by this wrapper
	 */
	public int get() {
		return _value;
	}
}
