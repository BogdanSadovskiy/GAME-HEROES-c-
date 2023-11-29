
namespace myGame;




class program
{
    static void Main(string[] args)
    {
        Hero_Viewer heroViewer = new Hero_Viewer();
        List<Hero> HeroesList = new List<Hero>();
        Nature_Prophet nature_Prophet = new Nature_Prophet();
        Juggernaut juggernaut = new Juggernaut();
        HeroesList.Add(juggernaut);
        HeroesList.Add(nature_Prophet);
        Hero hero1;

        Weather weather = new Weather_choosing().randWeather();
        Console.Clear();
        int menu = 0;
        string menu_;
        Hero player1;
        Hero player2;
        while (menu == 0){
            Console.WriteLine("\t\tChoose the hero: ");
            heroViewer.HeroesCards(HeroesList);
            try
            {
                menu_ = Console.ReadLine();
                menu = Int16.Parse(menu_);
                player1 = HeroesList[menu - 1]; //Chosing first hero

            }
            catch
            {
                Console.WriteLine("Wrong input");
            }
        }

        while (menu == 0)
        {
            Console.WriteLine("\t\tChoose the hero: ");
            heroViewer.HeroesCards(HeroesList);
            try
            {
                menu_ = Console.ReadLine();
                menu = Int16.Parse(menu_);
                player2 = HeroesList[menu - 1]; //Chosing second hero

            }
            catch
            {
                Console.WriteLine("Wrong input");
            }
        }






    }
}