using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample2023Spring
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new();
        public List<CardGroup> CardGroups { get; set; } = new();

        public Deck() {
            ResetDeck();
        }

        public void CreateCardGroup()
        {
            CardGroups = (from c in Cards
                         group c by c.value into g
                         select new CardGroup { Value = g.Key, Count = g.Count() }).ToList();
        }

        public List<Card> FindRanksInDeck(string rankToFind)
        {
            var cardsFound = (from card in Cards
                              where card.rank == rankToFind
                              select card).ToList();
            return cardsFound;
        }

        public int CheckRank()
        {   
            if (CheckForStraightFlush()) 
                return 9; 
            if (CheckForFourOfAKind()) 
                return 8;
            if (CheckForFullHouse()) 
                return 7;
            if (CheckForFlush()) 
                return 6;
            if (CheckForStraight())
                return 5;
            if (CheckForThreeOfAKind())
                return 4;
            if (CheckForTwoPairs())
                return 3;
            if (CheckForPairs())
                return 2;
            return 1;
        }

        public bool CheckForPairs()
        {
            return CardGroups.Where(c => c.Count == 2).Any();

        }

        public bool CheckForTwoPairs()
        {
            return CardGroups.Where(c => c.Count == 2).Count() == 2;

        }

        public bool CheckForStraightFlush()
        {
            return CheckForStraight() && CheckForFlush();
        }

        public bool CheckForFourOfAKind()
        {
            return CardGroups.Where(c => c.Count == 4).Any();

        }

        public bool CheckForThreeOfAKind() 
        {
            return CardGroups.Where(c => c.Count == 3).Any();
        }

        public bool CheckForFullHouse()
        {
            return CheckForThreeOfAKind() && CheckForPairs();
        }

        public bool CheckForStraight()
        {
            var straightGroup = Cards.OrderByDescending(c => c.value).ToList();

            for (int i = 0; i < straightGroup.Count() - 1; i++)
            {
                if (straightGroup[i].value != (straightGroup[i+1].value + 1))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckForFlush()
        {
            var suitGroups = from c in Cards
                             group c by new { c.suit } into g
                             select new { value = g.Key, count = g.Count() };

            return suitGroups.Count() == 1;
        }

        public List<Card> DealCards(int numOfCards)
        {
            List<Card> cardsDealt = new();
            Random rnd = new();
            if (numOfCards < Cards.Count)
            {
                for (int cardsToDeal = 1; cardsToDeal <= numOfCards; cardsToDeal++)
                {
                    int cardToSelect = rnd.Next(Cards.Count);
                    Card dealtCard = Cards[cardToSelect];
                    cardsDealt.Add(dealtCard);
                    Cards.RemoveAt(cardToSelect);
                }
            }
            return cardsDealt;
        }

        public void ResetDeck()
        {
            Cards.Clear();
            List<string> suits = new List<string>() { "♥", "♦", "♣", "♠" };
            List<string> ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<int> values = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    Card card = new Card(rank, suit, values[ranks.IndexOf(rank)]);
                    Cards.Add(card);
                }
            }
        }
    }
}
