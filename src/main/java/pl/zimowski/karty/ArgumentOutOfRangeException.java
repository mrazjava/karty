package pl.zimowski.karty;

public class ArgumentOutOfRangeException extends RuntimeException {

	private static final long serialVersionUID = 3158556515121118685L;

	public ArgumentOutOfRangeException() {
	}

	public ArgumentOutOfRangeException(String message) {
		super(message);
	}

	public ArgumentOutOfRangeException(Throwable cause) {
		super(cause);
	}

	public ArgumentOutOfRangeException(String message, Throwable cause) {
		super(message, cause);
	}

}
