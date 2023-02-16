using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample2023Spring
{
    public class Card
    {
        public string rank { get; set; }
        public string suit { get; set; }
        public int value { get; set; }

        /// <summary>
        /// This is a card
        /// </summary>
        /// <param name="rank">the rank of the card</param>
        /// <param name="suit">the suit (♥, ♦, ♣, ♠)</param>
        /// <param name="value">the value of the card</param>
        public Card(string rank, string suit, int value)
        {
            this.rank = rank;
            this.suit = suit;
            this.value = value;
        }

        public override string? ToString()
        {
            return $"{rank} {suit}";
        }
        
    }
}
