using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_051_Mega_Challenge_War_v2
{
    public class Game
    {
        public List<Player> ActivePlayers { get; set; }
        public List<string> startingDeck { get; set; }

        Random _random = new Random();

        public Game(List<string> astartingDeck,string player1Name,string player2Name)
        {
            startingDeck = astartingDeck;
            ActivePlayers = Deal(startingDeck, player1Name, player2Name);
        }

        private List<Player> Deal(List<string> astartingDeck, string player1Name, string player2Name)
        {

            List<Player> playerList = new List<Player>();

            playerList.Add(new Player(player1Name));
            playerList.Add(new Player(player2Name));

            while (astartingDeck.Count > 0)
            {
                foreach (Player player in playerList)
                {
                    int random = _random.Next(astartingDeck.Count);
                    player.PlayerDeck.Add(astartingDeck.ElementAt(random));                  
                    astartingDeck.RemoveAt(random);
                }
            }
            return playerList;
        }

    }
    
}