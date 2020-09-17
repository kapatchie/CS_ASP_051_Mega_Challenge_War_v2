using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_051_Mega_Challenge_War_v2
{
    public partial class Default : System.Web.UI.Page
    {
        Random _random = new Random();
        protected void PlayButton_Click(object sender, EventArgs e)
        {
            ResultLable.Text = "";
            Logic();
        }

        private void Logic()
        {
            Deck _deck = new Deck();
            Game _game = new Game(_deck.StartingDeck, "Player 1 ", "Player 2");
            int _turnLimit = 0;

            DisplayDraws(_game);

            List<string> cards = new List<string>();
            ResultLable.Text += "<br/><br/>";
            while (_turnLimit < 20)
            {
                
                string player1Card = DrawCards(_game, 0);
                string player2Card = DrawCards(_game, 1);
                

                cards.Add(player1Card);
                cards.Add(player2Card);
                string Winner = DetermineWinner(player1Card,player2Card,_game);

                if(Winner != "War Has Been Declered") 
                {
                    ResultLable.Text += String.Format("Player 1 Has Drawn {0}<br/> Player 2 Has Drawn {1}<br/> The Winner is {2} <br/><br/>",
                    player1Card, player2Card, Winner);                  
                }
                else
                {
                    ResultLable.Text += String.Format("<br/>War<br/>");
                    cards.Clear();
                    cards.AddRange(War(player1Card, player2Card, _game));
                    foreach (string card in cards)
                    {
                     ResultLable.Text += String.Format("Bounties are {0}<br/>", card);                        
                    }
                }

                if(Winner == "Player 1") { addCards(cards, _game, 0); }
                    else if (Winner == "Player 2") { addCards(cards, _game, 1); }

                cards.Clear();
                updateScore(_game);
                
                _turnLimit++;
            }

            if (_game.ActivePlayers.ElementAt(0).PlayerScore > _game.ActivePlayers.ElementAt(1).PlayerScore )
            {
                ResultLable.Text += String.Format("{0} is the winner with a score of {1}", 
                    _game.ActivePlayers.ElementAt(0).Name, _game.ActivePlayers.ElementAt(0).PlayerScore.ToString());
            }else if (_game.ActivePlayers.ElementAt(0).PlayerScore < _game.ActivePlayers.ElementAt(1).PlayerScore)
            {
                ResultLable.Text += String.Format("{0} is the winner with a score of {1}",
                    _game.ActivePlayers.ElementAt(1).Name, _game.ActivePlayers.ElementAt(1).PlayerScore.ToString());
            }
            else { ResultLable.Text += "Tie"; }
            
        }
       
        private void updateScore(Game game)
        {
            foreach (Player player in game.ActivePlayers)
            {
                player.PlayerScore = player.PlayerDeck.Count();
            }
        }

        private void addCards(List<string> Cards, Game game,int WinningPlayer)
        {
            if (WinningPlayer == 0)
            {
              
                for (int i = 0; i < Cards.Count; i++)
                {
                    game.ActivePlayers.ElementAt(1).PlayerDeck.Remove(Cards[i]);
                }
                game.ActivePlayers.ElementAt(WinningPlayer).PlayerDeck.AddRange(Cards);
            }
            else
            {
                for (int i = 0; i < Cards.Count; i++)
                {
                    game.ActivePlayers.ElementAt(0).PlayerDeck.Remove(Cards[i]);
                }
                game.ActivePlayers.ElementAt(WinningPlayer).PlayerDeck.AddRange(Cards);                
            }
        }

        private string DetermineWinner(string player1Card,string player2Card,Game game)
        {

            int Player1Score = Values(player1Card);
            int Player2score = Values(player2Card);
            if(Player1Score > Player2score) { return "Player 1"; }
            else if (Player1Score < Player2score) { return "Player 2"; }
            else{return "War Has Been Declered"; } 
          }

        private List<string> War(string player1Card, string player2Card,Game game)
        {
            List<string> p1Bounties = new List<string>() { player1Card };
            List<string> p2Bounties = new List<string>() { player2Card };
            List<string> Bounties = new List<string>() {};
            

            for (int i = 0; i < 2; i++)
            {
                p1Bounties.Add(DrawCards(game, 0));
                p2Bounties.Add(DrawCards(game, 1));
            }
            for (int i = 0; i < p1Bounties.Count; i++)
            {
                Bounties.Add(p1Bounties[i]);
                Bounties.Add(p2Bounties[i]);
            }

           string Winner = DetermineWinner(p1Bounties.ElementAt(2), p2Bounties.ElementAt(2), game);

            if (Winner == "Player 1") { p1Bounties.AddRange(p2Bounties); addCards(p1Bounties, game, 0); return Bounties; }
            else if (Winner == "Player 2") { p2Bounties.AddRange(p1Bounties); addCards(p2Bounties, game, 1); return Bounties; }
            else War(player1Card,player2Card,game);return null;
            
        }

        private int Values(string playerCard)
        {
            if (playerCard.StartsWith("Ace")) {        return 13; }
            else if (playerCard.StartsWith("2")) {     return 1; }
            else if (playerCard.StartsWith("3")) {     return 2; }
            else if (playerCard.StartsWith("4")) {     return 3; }
            else if (playerCard.StartsWith("5")) {     return 4; }
            else if (playerCard.StartsWith("6")) {     return 5; }
            else if (playerCard.StartsWith("7")) {     return 6; }
            else if (playerCard.StartsWith("8")) {     return 7; }
            else if (playerCard.StartsWith("9")) {     return 8; }
            else if (playerCard.StartsWith("10")) {    return 9; }
            else if (playerCard.StartsWith("Jack")) {  return 10; }
            else if (playerCard.StartsWith("Queen")) { return 11; }
            else if (playerCard.StartsWith("Kind")) {  return 12; }
            else { return 0; }
        }

        private void DisplayDraws(Game _game)
        {
            for (int i = 0; i < 26; i++)
            {
                foreach (Player player in _game.ActivePlayers)
                {
                    ResultLable.Text += String.Format("{0} has Drawn the {1}<br/>", player.Name, player.PlayerDeck[i]);
                }
            }
        }

        private string DrawCards(Game game,int playerTurn)
        {
            
            int random = _random.Next(game.ActivePlayers.ElementAt(playerTurn).PlayerDeck.Count());
            game.ActivePlayers.ElementAt(playerTurn).PlayerDeck.ElementAt(0);
            string _DrawnCard = game.ActivePlayers.ElementAt(playerTurn).PlayerDeck.ElementAt(random);

            return _DrawnCard;
        }
    }
}