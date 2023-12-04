
namespace myGame
{
    internal class Hero_Viewer
    {
        public  void mainStats(Hero hero)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(hero.Name);
            Console.WriteLine("Health - " + hero.currenthealth);
            Console.WriteLine("Main damage - " + hero.damageType);
            Console.WriteLine("Physical dmg - " + hero.PhysicalDamage +
                " Magical dmg - " + hero.defaultMagicalDamage);
            Console.WriteLine("Physical/Magical resistance - " + hero.defaultPhysicalResistance +
                "/" + hero.MagicalResistance);
            Console.WriteLine("----------------------------------------------");
        }
        public  void HeroCard(Hero hero)
        {
            Console.WriteLine("==============================================");
            mainStats(hero);
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
        public void ArtefactCard(Artefact actefact)
        {
            Console.WriteLine("-------------- " + actefact.Name +" ------------------");
            Console.WriteLine("Price - " + actefact.price + "$");
            if (actefact.health != 0)
            {
                Console.WriteLine("Health " + actefact.health);
            }
            if (actefact.HealthRegeneration != 0)
            {
                Console.WriteLine("Health regeneration " + actefact.HealthRegeneration);
            }
            if (actefact.magicalDamage != 0)
            {
                Console.WriteLine("Magical dmg " + actefact.magicalDamage);
            }
            if (actefact.physicalDamage != 0)
            {
                Console.WriteLine("Physical dmg " + actefact.physicalDamage);
            }
            if (actefact.PhysicalResistance != 0)
            {
                Console.WriteLine("Physical resistance " + actefact.PhysicalResistance);
            }
            if (actefact.MagicalResistance != 0)
            {
                Console.WriteLine("Magical Resistance " + actefact.MagicalResistance);
            }
            if (actefact.CriticalChance != 0)
            {
                Console.WriteLine("Critical Chance" + actefact.CriticalChance);

            }
            if (actefact.MissChance != 0)
            {
                Console.WriteLine("Miss Chance" + actefact.MissChance);
            }
            if (actefact.DodgeChance != 0)
            {
                Console.WriteLine("Dodge chance " + actefact.DodgeChance);

            }

            Console.WriteLine("--------------------------------------------------");
        }

        public void artefactListViewer(List<Artefact> artefactList)
        {
            int i = 1;
            foreach(Artefact item in artefactList)
            {
                Console.WriteLine("==================== " + i+ " =======================");
                ArtefactCard(item);
                Console.WriteLine("==============================================\n");
                i++;
            }
        }
        public bool isGoldEnough(Artefact item, Hero hero) {
        if(item.price> hero.Gold)
            {
                Console.WriteLine("Not enough gold");
                return false;
            }
            Console.WriteLine("You have bought " + item.Name);
            return true;
        }
        
    }
}
