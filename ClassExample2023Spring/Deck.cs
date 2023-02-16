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
        
        public Deck() {
            ResetDeck();
        }

        public List<Card> FindRanksInDeck(string rankToFind)
        {
            var cardsFound = (from card in Cards
                              where card.rank == rankToFind
                              select card).ToList();
            return cardsFound;
        }

        public bool CheckForPairs()
        {
            var cardGroups = from c in Cards
                             group c by new { c.value } into g
                             select new { value = g.Key, count = g.Count() };

            return cardGroups.Where(c => c.count == 2).Any();

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
