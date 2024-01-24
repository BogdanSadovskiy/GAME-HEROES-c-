

namespace myGame
{
    internal class Fight_Logs
    {
        public void LOGSWriter(string log)
        {
          
        }
        public string LOGS(Hero player1, Hero player2, int rounds)
        {
            String winner;
            if (player1.isHeroAlive()) winner = "PLAYER 1";
            else { winner = "PLAYER 2"; }
            string fightLog = "";
            fightLog += "Player 1(" + player1.Name + ") VS Player 2(" + player2.Name;
            fightLog += "\nWinner - " + winner;
            fightLog += "\nNumber of rounds - " + rounds;
            fightLog += "\nPlayer 1:\nDamage dealt (" + player1.damageDealt.ToString() + "); Damage recived ("
                + player1.damageRecived.ToString() + "); Healed (" + player1.healed.ToString()+ "\n";
            fightLog += "\nPlayer 2:\nDamage dealt (" + player2.damageDealt.ToString() + "); Damage recived ("
                + player2.damageRecived.ToString() + "); Healed (" + player2.healed.ToString() + "\n";
            return fightLog;
        }

    }
}
