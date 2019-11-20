using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static _007_ObjectOrientedDesign.Question_7_1;

namespace _007_ObjectOrientedDesignTest
{
    [TestClass]
    public class Question_7_1_Test
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        public void BlackjackTest(int _)
        {
            // Arrange new deck
            var cards = new List<BlackjackCard>(52);
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new BlackjackCard((CardSuit)suit, value));
                }
            }
            var deck = new Deck<BlackjackCard>(cards);

            // Assert new deck
            Assert.AreEqual(52, deck.TotalCards, "Incorrect total number of cards in the initial deck.");
            Assert.AreEqual(52, deck.RemainingCards, "Incorrect remaining number of cards in the initial deck.");
            Assert.IsTrue(cards.SequenceEqual(deck.Cards));

            // Act 1
            deck.Shuffle();
            List<BlackjackCard> handOfCards = deck.DealHand(2);
            var hand = new BlackjackHand(handOfCards);

            // Assert new hand
            Assert.AreEqual(52, deck.TotalCards, "Incorrect total number of cards in the deck.");
            Assert.AreEqual(50, deck.RemainingCards, "Incorrect remaining number of cards in the deck.");
            Assert.IsTrue(handOfCards.SequenceEqual(hand.Cards));

            int expectedScore = handOfCards[0].MaxValue + handOfCards[1].MaxValue;
            if (handOfCards[0].IsAce && handOfCards[1].IsAce)
            {
                expectedScore = 12;
            }
            Console.WriteLine($"Initial Score: {hand.Score()}. Cards in hand: {hand}");

            Assert.AreEqual(expectedScore, hand.Score(), "Incorrect score calculated.");
            Assert.AreEqual(expectedScore > 21, hand.IsBusted, "Check IsBusted failed.");
            Assert.AreEqual(expectedScore == 21, hand.Is21, "Check Is21 failed.");
            Assert.AreEqual(expectedScore == 21, hand.IsBlackjack, "Check IsBlackjack failed.");

            // Act 2
            int count = 1;
            while (!hand.IsBusted && !hand.Is21)
            {
                BlackjackCard newCard = deck.DealCard();
                hand.AddCard(newCard);
                handOfCards.Add(newCard);

                // Assert updated hand
                Assert.AreEqual(52, deck.TotalCards, "Incorrect total number of cards in the deck.");
                Assert.AreEqual(50 - count, deck.RemainingCards, "Incorrect remaining number of cards in the deck.");
                Assert.IsTrue(handOfCards.SequenceEqual(hand.Cards));

                int expectedMinScore = 0;
                int expectedMaxScore = 0;
                bool aceFound = false;
                foreach (BlackjackCard card in handOfCards)
                {
                    if (!aceFound && card.IsAce)
                    {
                        expectedMaxScore += card.MaxValue;
                        aceFound = true;
                    }
                    else
                    {
                        expectedMaxScore += card.Value;
                    }
                    expectedMinScore += card.Value;
                }
                expectedScore = expectedMaxScore > 21 ? expectedMinScore : expectedMaxScore;
                Console.WriteLine($"Round {count} Score: {hand.Score()}. Cards in hand: {hand}");

                Assert.AreEqual(expectedScore, hand.Score(), "Incorrect score calculated.");
                Assert.AreEqual(expectedScore > 21, hand.IsBusted, "Check IsBusted failed.");
                Assert.AreEqual(expectedScore == 21, hand.Is21, "Check Is21 failed.");
                Assert.IsFalse(hand.IsBlackjack, "Check IsBlackjack failed.");

                count++;
            }

            // Act 3
            deck.ResetDeck();

            // Assert after deck reset
            Assert.AreEqual(52, deck.TotalCards, "Incorrect total number of cards after deck reset.");
            Assert.AreEqual(52, deck.RemainingCards, "Incorrect remaining number of cards after deck reset.");
        }
    }
}
