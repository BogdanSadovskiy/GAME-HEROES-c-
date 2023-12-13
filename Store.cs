


namespace myGame
{
    internal class Store
    {
        public bool ForBuy = true;
        public bool ForSell = false;
        public void ArtefactCard(Artefact actefact, bool status)
        {
            Console.WriteLine("-------------- " + actefact.Name + " ------------------");

            if(status == ForBuy)
            {
                Console.WriteLine("Price - " + actefact.price + "$");
            }
            if(status == ForSell)
            {
                Console.WriteLine("Sell price - " + actefact.sellPrice + "$");
            }
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

        public void artefactListViewer(List<Artefact> artefactList, bool status)
        {
            int i = 1;
            if(artefactList!= null )
            {
                if(artefactList?.Count() != 0)
                {
                    foreach (Artefact item in artefactList)
                    {
                        Console.WriteLine("==================== " + i + " =======================");
                        ArtefactCard(item, status);
                        Console.WriteLine("==============================================\n");
                        i++;
                    }
                    return;
                }
               
            }
            Console.WriteLine("Empty");
           
        }
        public bool isGoldEnough(Artefact item, Hero hero)
        {
            if (item.price > hero.Gold)
            {
                Console.WriteLine("Not enough gold");
                return false;
            }
            return true;
        }
        public bool isHeroCanAddItem(Hero hero)
        {
            if(hero.artefacts.Count <= 6) { return true; }
            Console.WriteLine("Not enough space for artifacts");
            return false;
        }
     

        public void artefact_LVL_Viewer(List<Artefact> item, Hero hero, string player, string artefacts_LVL)
        {
            while (true)
            {
                int menu;
                Console.Clear();
                Console.WriteLine("\n" + player + " " + hero.Name + " Store\n");
                Console.WriteLine("Gold - " + hero.Gold + "\n");
                Console.WriteLine("\n" + artefacts_LVL + ":");
                artefactListViewer(item, ForBuy);
                Console.WriteLine("BACK ---------- press ESC\n");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
                char f;
                f = (key.KeyChar);
                try { menu = Int16.Parse(f.ToString()); }
                catch (Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if (menu > item.Count())
                {
                    Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue;
                }
                if (isGoldEnough(item[menu- 1],hero)) 
                {

                    if (!isHeroCanAddItem(hero)) { Thread.Sleep(1500); continue; }
                    hero.addArtefact (item[menu - 1]);
                    hero.Gold -= item[menu - 1].price;
                    Console.WriteLine("Have bought " + item[menu - 1]);
                    Thread.Sleep(1500);
                }
                else{Thread.Sleep(1500);}  
            }
        }
        public void sellArtefacts(Hero hero, string player)
        {
            while (true)
            {
                int menu;
                Console.Clear();
                Console.WriteLine("\n" + player + " " + hero.Name + " Store\n");
                Console.WriteLine("Gold - " + hero.Gold + "\n");
                Console.WriteLine("Choose artefact you want to sell");
                artefactListViewer(hero.artefacts, ForSell);
                Console.WriteLine("Press ECS to back");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return;
                }
                char f;
                f = (key.KeyChar);
                try { menu = Int16.Parse(f.ToString()); }
                catch (Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if (menu > hero.artefacts.Count())
                {
                    Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue;
                }
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Do you want sell " + hero.artefacts[menu - 1].Name + "?");
                    Console.WriteLine("ECS - back     YES - ENTER");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        break;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        hero.Gold += hero.artefacts[menu - 1].sellPrice;
                        hero.removeArtefact(menu - 1);
                        Console.WriteLine("Sold");
                        Thread.Sleep(1500);
                        break;
                    }
                }
            }
        }
        public void store(List<Artefact> itemlvl1, List<Artefact> itemlvl2, Hero hero, string player)
        {
            while (true)
            {
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
                    return ;
                }
                char f;
                f = (key.KeyChar);
                if(f == 's' || f == 'S')
                {
                    sellArtefacts(hero, player);
                    continue;
                }
                try{ menu = Int16.Parse(f.ToString());}
                catch(Exception e) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }
                if(menu > 2) { Console.WriteLine("Wrong input"); Thread.Sleep(1500); continue; }


                if(menu == 1)
                {
                    artefact_LVL_Viewer(itemlvl1, hero, player, "Artefacts LVL1");
                }
                if(menu == 2)
                {
                    artefact_LVL_Viewer(itemlvl2, hero, player, "Artefacts LVL2");
                }
            }
            
        }

    }
}
