
namespace myGame;




class program
{
    static void Main(string[] args)
    {


        Eternal_Shroud eternal_Shroud = new Eternal_Shroud();
        Daedalus daedalus = new Daedalus();
        Octarine_Core octarine_Core = new Octarine_Core();
        Radiance radiance = new Radiance();
        Vanguard vanguard = new Vanguard();
        Butterfly butterfly = new Butterfly();
        List<Artefact> artefact_list = new List<Artefact>();
        artefact_list.Add(eternal_Shroud);
        artefact_list.Add(daedalus);
        artefact_list.Add(octarine_Core);
        artefact_list.Add(radiance);
        artefact_list.Add(vanguard);
        artefact_list.Add(butterfly);
        //artefacts


        Hero_Viewer heroViewer = new Hero_Viewer();
        List<Hero> HeroesList = new List<Hero>();
        Nature_Prophet nature_Prophet = new Nature_Prophet();
        Juggernaut juggernaut = new Juggernaut();
        HeroesList.Add(juggernaut);
        HeroesList.Add(nature_Prophet);
        //heroes

        Weather weather = new Weather_choosing().randWeather();
        //weather choosing

        Console.Clear();


        //start game
        int menu = 0;
        string menu_;
        Hero player1;
        Hero player2;

        /////////////////////////////////////////////////////////
        do
        {
            Console.WriteLine("\t\tChoose the hero: ");
            heroViewer.HeroesCards(HeroesList);

            menu_ = Console.ReadLine();
            menu = Int16.Parse(menu_);

        } while (menu > HeroesList.Count());
            player1 = HeroesList[menu - 1]; //Chosing first hero

        do
        {
            Console.WriteLine("\t\tChoose the hero: ");
        heroViewer.HeroesCards(HeroesList);

        menu_ = Console.ReadLine();
        menu = Int16.Parse(menu_);
        } while (menu > HeroesList.Count());
        player2 = HeroesList[menu - 1]; //Chosing second hero

        ////////////////////////////////////////////////////////////////
        int round = 0;

        Console.Clear() ;
        Console.WriteLine("\n\n\n\t\t\tThe battle began");
        Thread.Sleep(2000);
        Console.WriteLine("\n\n\n\t\t\t" + player1.Name + "\n\t\t\t\tVS\n" + "\t\t\t" + player2.Name );
        Thread.Sleep(2000);    

     
        List<Artefact> buyArtPplayer1 = new List<Artefact>();
        List<Artefact> buyArtPplayer2 = new List<Artefact>();

        while (true)
        {
            if(round%10 == 0)     //artefact store
            {

                buyArtPplayer1.Clear(); //clear the buy LIST
                buyArtPplayer2.Clear();

                do
                {
                    Console.WriteLine(player1.Name + " Store"); // buying for first player
                    Console.WriteLine("Input \'e\' to exit");
                    heroViewer.artefactListViewer(artefact_list);
                    menu_ = Console.ReadLine();
                    if (menu_ == "e")
                    {
                        break;
                    }
                    menu = Int16.Parse(menu_);
                    buyArtPplayer1.Add(artefact_list[menu - 1]);
                } while (true);
                player1.addArtefact(buyArtPplayer1);

                do
                {
                    Console.WriteLine(player2.Name + " Store"); // buying for second player
                    Console.WriteLine("Input \'e\' to exit");
                    heroViewer.artefactListViewer(artefact_list);
                    menu_ = Console.ReadLine();
                    if (menu_ == "e")
                    {
                        break;
                    }
                    menu = Int16.Parse(menu_);
                    buyArtPplayer2.Add(artefact_list[menu - 1]);
                } while (true);
                player2.addArtefact(buyArtPplayer2);
            }

            heroViewer.mainStats(player1);
            heroViewer.mainStats(player2);
            

            Func <int, int , int , int> damageRecievePlayer2 = player2.getAttacked;
            Func<int, int, int, int> damageRecievePlayer1 = player1.getAttacked;

            int dmg = damageRecievePlayer2(player1.phisicalAttack(), player1.magicalAttack(), player1.damageDealt); // damaging Hero 2
           player1.DamageCounter(dmg); //counting dealt damage
            player1.Regeneration();

            dmg= damageRecievePlayer2(player2.phisicalAttack(), player2.magicalAttack(), player2.damageDealt); // damaging Hero 1
            player2.DamageCounter(dmg); //counting dealt damage
            player2.Regeneration();
            Thread.Sleep(2000);

        }




    }
}