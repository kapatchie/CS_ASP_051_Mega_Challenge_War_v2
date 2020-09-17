using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_Mega_Challenge_War_v2
{
    public class Deck
    {
        public List<String> StartingDeck { get; set; }

        public Deck()
        {
            StartingDeck = DeckBuilder();
        }

        private List<String> DeckBuilder()
        {
            string[] kinds = new string[13] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] suites = new string[4] { "Hearts", "Spades", "Diamonds", "Clovers" };
            List<string> startingDeck = new List<string>() { };

            foreach (var suite in suites)
            {
                foreach (var kind in kinds)
                {
                    startingDeck.Add(kind + " " + " of" + " " + suite);
                }
            }

            return startingDeck;
        }
    }
}