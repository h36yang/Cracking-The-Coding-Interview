using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _007_ObjectOrientedDesign
{
    /// <summary>
    /// 7.1) Deck of Cards:
    /// Design the data structures for a generic deck of cards.
    /// Explain how you would subclass the data structures to implement blackjack.
    /// </summary>
    public static class Question_7_1
    {
        #region Generic Data Structures

        public enum CardSuit
        {
            Spade,
            Heart,
            Club,
            Diamond
        }

        public abstract class Card
        {
            public CardSuit Suit { get; private set; }

            private readonly Dictionary<int, string> _specialValueNameMap = new Dictionary<int, string>()
            {
                { 1, "A" },
                { 11, "J" },
                { 12, "Q" },
                { 13, "K" }
            };

            private readonly Dictionary<CardSuit, string> _suitMap = new Dictionary<CardSuit, string>()
            {
                { CardSuit.Spade, "♠" },
                { CardSuit.Heart, "♥" },
                { CardSuit.Club, "♣" },
                { CardSuit.Diamond, "♦" }
            };

            private readonly int _value;

            public virtual int Value => _value;

            public bool IsAce => _value == 1;

            protected Card(CardSuit suit, int value)
            {
                Suit = suit;
                _value = value;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Card other))
                {
                    return false;
                }

                return Suit.Equals(other.Suit) && Value.Equals(other.Value);
            }

            public override int GetHashCode()
            {
                return Suit.GetHashCode() * 13 + Value.GetHashCode();
            }

            public override string ToString()
            {
                string valueName;
                if (_specialValueNameMap.ContainsKey(_value))
                {
                    valueName = _specialValueNameMap[_value];
                }
                else
                {
                    valueName = _value.ToString();
                }
                return $"{_suitMap[Suit]}{valueName}";
            }
        }

        public class Deck<T> where T : Card
        {
            private static Random _randomGenerator;

            public List<T> Cards { get; private set; }

            public List<T> DealtCards { get; private set; } = new List<T>(52);

            public int RemainingCards => Cards.Count;

            public int TotalCards => Cards.Count + DealtCards.Count;

            public Deck(List<T> cards)
            {
                Cards = new List<T>(cards);
            }

            public void ResetDeck()
            {
                Cards.AddRange(DealtCards);
                DealtCards.Clear();
            }

            public void Shuffle()
            {
                if (_randomGenerator == null)
                {
                    _randomGenerator = new Random();
                }
                Cards = Cards.OrderBy(x => _randomGenerator.Next()).ToList();
            }

            public T DealCard()
            {
                if (RemainingCards == 0)
                {
                    return null;
                }

                int lastCardIndex = RemainingCards - 1;
                T card = Cards[lastCardIndex];
                Cards.RemoveAt(lastCardIndex);
                DealtCards.Add(card);
                return card;
            }

            public List<T> DealHand(int numberOfCards)
            {
                var hand = new List<T>(numberOfCards);
                for (int i = 0; i < numberOfCards; i++)
                {
                    hand.Add(DealCard());
                }
                return hand;
            }
        }

        public abstract class Hand<T> where T : Card
        {
            public List<T> Cards { get; private set; }

            protected Hand(List<T> cards)
            {
                Cards = new List<T>(cards);
            }

            public virtual int Score()
            {
                int score = 0;
                foreach (T card in Cards)
                {
                    score += card.Value;
                }
                return score;
            }

            public void AddCard(T card)
            {
                Cards.Add(card);
            }

            public override string ToString()
            {
                var hand = new StringBuilder();
                foreach (T card in Cards)
                {
                    hand.Append($"{card} ");
                }
                return hand.ToString();
            }
        }

        #endregion

        #region Blackjack Implementation

        public class BlackjackCard : Card
        {
            public override int Value => base.Value <= 10 ? base.Value : 10;

            public int MaxValue => IsAce ? 11 : Value;

            public BlackjackCard(CardSuit suit, int value) : base(suit, value) { }
        }

        public class BlackjackHand : Hand<BlackjackCard>
        {
            public bool IsBusted => Score() > 21;

            public bool Is21 => Score() == 21;

            public bool IsBlackjack => Is21 && Cards.Count == 2;

            public BlackjackHand(List<BlackjackCard> cards) : base(cards) { }

            public override int Score()
            {
                List<int> possibleScores = PossibleScores();
                int finalScore = 0;
                int minScore = int.MaxValue;
                foreach (int score in possibleScores)
                {
                    if (score > finalScore && score <= 21)
                    {
                        finalScore = score;
                    }

                    if (score < minScore)
                    {
                        minScore = score;
                    }
                }
                return finalScore != 0 ? finalScore : minScore;
            }

            private List<int> PossibleScores()
            {
                var scores = new List<int>();
                for (int i = 0; i < Cards.Count; i++)
                {
                    int score = Cards[i].MaxValue;
                    for (int j = 0; j < Cards.Count; j++)
                    {
                        if (i != j)
                        {
                            score += Cards[j].Value;
                        }
                    }
                    scores.Add(score);
                }
                return scores.Distinct().ToList();
            }
        }

        #endregion
    }
}
