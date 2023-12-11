
namespace myGame
{
    internal class Hero_Viewer
    {
        public  void mainStats(Hero hero)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(hero.Name);
            Console.WriteLine("Health - " + hero.currenthealth);
            Console.WriteLine("Physical dmg - " + hero.PhysicalDamage +
                " Magical dmg - " + hero.MagicalDamage);
            Console.WriteLine("Physical/Magical resistance - " + hero.PhysicalResistance +
                "/" + hero.MagicalResistance);
            Console.WriteLine(hero.Gold);
            Console.WriteLine("----------------------------------------------");
        }
        public  void HeroCard(Hero hero)
        {
            Console.WriteLine("==============================================");
            mainStats(hero);
            Console.WriteLine("Main damage - " + hero.damageType);
            Console.WriteLine(hero.HeroDescr);
            Console.WriteLine("==============================================\n");
        }

        public void HeroesCards(List<Hero> heroes)
        {
            int i = 1;
            foreach(Hero h in heroes)
            {
                Console.WriteLine("\t\t\t" + i);
                HeroCard(h);
                i++;
            }
        }
        
        
    }
}
