using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_Mega_Challenge_War_v2
{
    public class Player
    {
        public List<String> PlayerDeck { get; set; }
        public string Name { get; set; }
        public int PlayerScore { get; set; }

        public Player(string aName)
        {
            PlayerDeck = new List<String>();
            Name = aName;
            PlayerScore = 0;
        }

    }
}