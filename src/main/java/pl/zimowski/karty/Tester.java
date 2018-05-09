package pl.zimowski.karty;

public class Tester {

	public static void main(String[] args) {
		int handValue = HandEngine.Evaluate("Ah Kd Qh Jh 10h 9s 8s");
		System.out.println("handValue: " + handValue);
		String desc = HandEngine.descriptionFromHandValue(handValue);
		System.out.println(desc);
		int cardVal = HandEngine.extractSecondRankedCard(handValue);
		System.out.println(cardVal);
		String card = HandEngine.descriptionFromCardValue(cardVal);
		System.out.println("card: " + card);
	}
}
