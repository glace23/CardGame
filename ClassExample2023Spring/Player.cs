using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample2023Spring
{
    public class Player
    {
        public string name { get; set; }
        public Deck Hand { get; set; } = new();

        public Player(string name)
        {
            this.name = name;
        }

        public bool CheckForRank(string rankToFind)
        {
            return Hand.FindRanksInDeck(rankToFind).Count() > 0;
        }

        public void ShowHand()
        {
            Console.WriteLine($"{name}'s hand:");
            foreach (Card card in Hand.Cards)
            {
                Console.Write($"{card}\t");
            }
            Console.WriteLine();
        }
    }
}
