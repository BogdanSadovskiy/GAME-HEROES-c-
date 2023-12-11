

using System;
using System.Numerics;

namespace myGame
{
    internal class Store
    {

        public void ArtefactCard(Artefact actefact)
        {
            Console.WriteLine("-------------- " + actefact.Name + " ------------------");
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
            foreach (Artefact item in artefactList)
            {
                Console.WriteLine("==================== " + i + " =======================");
                ArtefactCard(item);
                Console.WriteLine("==============================================\n");
                i++;
            }
        }
        public bool isGoldEnough(Artefact item, Hero hero)
        {
            if (item.price > hero.Gold)
            {
                Console.WriteLine("Not enough gold");
                return false;
            }
            Console.WriteLine("You have bought " + item.Name);
            return true;
        }

        public Artefact artefact_LVL1_Viewer(List<Artefact> item, Hero hero, string player)
        {
            while (true)
            {
                int menu;
                Console.Clear();
                Console.WriteLine("\n" + player + " " + hero.Name + " Store\n");
                Console.WriteLine("Gold - " + hero.Gold + "\n");
                Console.WriteLine("\nArtefacts LVL-1\n");
                artefactListViewer(item);
                Console.WriteLine("BACK ---------- press ESC\n");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return null;
                }
                char f;
                f = (key.KeyChar);
                try { menu = Int16.Parse(f.ToString()); }
                catch (Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if (menu > item.Count())
                {
                    Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue;
                }
                return item[menu - 1];
            }
        }

        public Artefact artefact_LVL2_Viewer(List<Artefact> item, Hero hero, string player)
        {
            while (true)
            {
                int menu;
                Console.Clear();
                Console.WriteLine("\n" + player + " " + hero.Name + " Store\n");
                Console.WriteLine("Gold - " + hero.Gold + "\n");
                Console.WriteLine("\nArtefacts LVL-2:");
                artefactListViewer(item);
                Console.WriteLine("BACK ---------- press ESC\n");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return null;
                }
                char f;
                f = (key.KeyChar);
                try { menu = Int16.Parse(f.ToString()); }
                catch (Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if (menu > item.Count())
                {
                    Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue;
                }
                return item[menu-1];    
            }
        }
        public Artefact store(List<Artefact> itemlvl1, List<Artefact> itemlvl2, Hero hero, string player)
        {
            while (true)
            {
                Artefact lvl1 = null;
                Artefact lvl2 = null;
                int menu;
                Console.Clear();
                Console.WriteLine("\n" + player + " " + hero.Name + " Store\n");
                Console.WriteLine("Gold - " + hero.Gold + "\n");
                Console.WriteLine("Artefacts LVL-1 press 1");
                Console.WriteLine("Artefacts LVL-2 press 2");
                Console.WriteLine("Sell artefacts  press S");
                Console.WriteLine("BACK ---------- press ESC");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return null;
                }
                char f;
                f = (key.KeyChar);
                if(f == 's' || f == 'S')
                {

                }
                try{ menu = Int16.Parse(f.ToString());}
                catch(Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if(menu > 2) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if(menu == 1)
                {
                    lvl1 = artefact_LVL1_Viewer(itemlvl1, hero, player);
                    if( lvl1 != null ) { return lvl1; }
                }
                if(menu == 2)
                {
                    lvl2 = artefact_LVL2_Viewer(itemlvl2, hero, player);
                    if(lvl2 != null ) { return lvl2; }
                }
            }
            
        }

    }
}
