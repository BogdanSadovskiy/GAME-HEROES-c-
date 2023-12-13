using System;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace myGame;




class program
{
    static void Main(string[] args)
    {

        List<Artefact> artefacts_LVL1= new List<Artefact>();
        artefacts_LVL1.Add(new Broom_Handle());
        artefacts_LVL1.Add(new Occult_Bracelet());
        artefacts_LVL1.Add(new Philosopher_s_Stone());
        List<Artefact> artefacts_LVL2 = new List<Artefact>();
        artefacts_LVL2.Add(new Eternal_Shroud());
        artefacts_LVL2.Add(new Daedalus());
        artefacts_LVL2.Add(new Octarine_Core());
        artefacts_LVL2.Add(new Radiance());
        artefacts_LVL2.Add(new Vanguard());
        artefacts_LVL2.Add(new Butterfly());
        artefacts_LVL2.Add(new Blade_Mail());

        artefacts_LVL1.Sort((Artefact a, Artefact b) => a.price.CompareTo(b.price));
        artefacts_LVL2.Sort((Artefact a, Artefact b) => a.price.CompareTo(b.price)); // sorting using lambda 
        //artefacts lvl2

        Store store = new Store();
        Hero_Viewer heroViewer = new Hero_Viewer();
        
        Nature_Prophet nature_Prophet = new Nature_Prophet();
        Juggernaut juggernaut = new Juggernaut();
        Alchemist alchemist = new Alchemist();

        //heroes
        Console.WriteLine("\n\n\t\tThis game is about fighting between heroes.\n\t\tHeroes can grow by earnig gold, bying items, etc\n");

        while (true) /// GAME PROCESS
        {
            List<Hero> HeroesList = new List<Hero>();
            HeroesList.Add(juggernaut);
            HeroesList.Add(nature_Prophet);
            HeroesList.Add(alchemist);
            Console.WriteLine("\t\tPress ENTER to start game");
            Console.WriteLine("\t\tPress any key to exit");
            ConsoleKeyInfo key = Console.ReadKey();


            if (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\tBYE");
                return;
            }

            Weather weather = new Weather_choosing().randWeather();
            //weather choosing

            Console.Clear();

            //start game
            int menu = 0;
            string menu_;
            Hero player1;
            Hero player2;
            Console.Clear();
            /////////////////////////////////////////////////////////
            do
            {
                Console.WriteLine("\nPlayer 1:\tChoose the hero: ");
                heroViewer.HeroesCards(HeroesList);
                menu = -1;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                char f;
                try
                {
                    f = (key.KeyChar);
                    menu = Int16.Parse(f.ToString());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Wrong input"); continue;
                }

            } while (menu == -1 || menu > HeroesList.Count());

            player1 = HeroesList[menu - 1];                 //Chosing first hero for player 1
            Console.WriteLine("\nPlayer 1 has chosen " + player1.Name);
            Thread.Sleep(2000);
            Console.Clear();
            //////////////////////////////////////////////////////////////////////////////
            do
            {
                Console.WriteLine("\nPlayer 2:\tChoose the hero: ");
                heroViewer.HeroesCards(HeroesList);
                menu = -1;
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                char f;
                try
                {
                    f = (key.KeyChar);
                    menu = Int16.Parse(f.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input"); 
                }

            } while (menu == -1 || menu > HeroesList.Count());
            player2 = HeroesList[menu - 1];                                //Chosing second hero
            Console.WriteLine("\nPlayer 2 has chosen " + player2.Name);
            Thread.Sleep(2000);
            Console.Clear();
            ////////////////////////////////////////////////////////////////
            ///
            int round = 1;

            Console.Clear();
            Console.WriteLine("\n\n\n\t\t\t" + player1.Name + "\n\t\t\t\tVS\n" + "\t\t\t" + player2.Name);
            Thread.Sleep(2000);
            Console.Clear();


            ///////////////////////////////////////////////////////////////////////////////
            while (true)
            {
                //-------------------------------------------------------------------------------------------------------------//
                if (round == 1 || round % 10 == 0)     //artefact store
                {

                    store.store(artefacts_LVL1, artefacts_LVL2, player1, "Player 1"); // buying for first player\
                    Console.Clear();
                    //--------------------------------------------------------------------------------------------------------------------//
                    store.store(artefacts_LVL1, artefacts_LVL2, player2, "Player 2"); // buying for second player\
                }
                //-----------------------------------------------------------------------------------------------------------------------//

                if (round == 1)
                {
                    Console.Clear();
                    heroViewer.mainStats(player1);
                    heroViewer.mainStats(player2);
                    Thread.Sleep(2000);
                    Console.Clear();
                }



                Func<int, int, int, int> damageRecievePlayer2 = player2.getAttacked;
                Func<int, int, int, int> damageRecievePlayer1 = player1.getAttacked;
                //---------------- Player 1 attack--------------------------------------------------------------------------------------//
                heroViewer.mainStats(player1); //Stats in the moment
                Console.WriteLine(" PLAYER 1 - " + player1.Name + " attacking:");
                int dmg = damageRecievePlayer2(player1.phisicalAttack(), player1.magicalAttack(), player1.damageDealt); // damaging Hero 2
                player1.DamageCounter(dmg); //counting dealt damage
                player1.other(player2, dmg);
                heroViewer.mainStats(player2);//Stats in the moment
                                              // ----------------------------- Is player 1 winner? ----------------------------//
                if (!player2.isHeroAlive())
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t" + player1.Name + "\n\t\tWINNER");
                    break;
                }
                Thread.Sleep(2000);
                Console.Clear();

                heroViewer.mainStats(player1); //Stats in the moment
                Console.WriteLine(" PLAYER 2 - " + player2.Name + " attacking:");
                dmg = damageRecievePlayer1(player2.phisicalAttack(), player2.magicalAttack(), player2.damageDealt); // damaging Hero 1
                player2.DamageCounter(dmg); //counting dealt damage
                player2.other(player1, dmg);
                heroViewer.mainStats(player2);
                //------------------------------------------------------------------------------------------------------------------------------------------------
                // ----------------------------- Is player 2 winner? ----------------------------//
                if (!player1.isHeroAlive())
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t" + player2.Name + "\n\t\tWINNER");
                    break;
                }
                Thread.Sleep(2000);
                Console.Clear();
                round++;
            }




        }
    }
}