package pl.zimowski.karty;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class HandTest {

    private static final Logger log = LoggerFactory.getLogger(HandTest.class);

    @Test
    public void shouldDealStraight() {
        int handValue = HandEngine.Evaluate("Ah Kd Qh Jh 10h 9s 8s");
        log.debug("handValue: " + handValue);
        assertEquals(67895296, handValue);
        String desc = HandEngine.descriptionFromHandValue(handValue);
        log.debug(desc);
        assertTrue(desc.contains("straight"));
        int cardVal = HandEngine.extractSecondRankedCard(handValue);
        log.debug("second ranked card: {}", cardVal);
        assertEquals(0, cardVal);
        // String card = HandEngine.descriptionFromCardValue(cardVal);
        // System.out.println("card: " + card);
    }
}
