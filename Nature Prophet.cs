

namespace myGame
{
    internal class Nature_Prophet : Hero
    {
        public Nature_Prophet()
        {

            this.Name = "Nature Prophet";
            this.HeroDescr = "Has 20% chance to deal double magic damage\n" +
                "When it is Dark Night - health regeneration +10";

            this.defaultHealth = 1350;
            this.defaultHealthRegeneration = 10;
            this.damageType = DamageTYPE.Magical;
            this.defaultPhysicleDamage = 60;
            this.defaultMagicalDamage = 100;
            this.defaultCriticalChance = 20;
            this.defaultDodgeChance = 25;
            this.defaultMagicalResistance = 30;
            this.defaultPhysicalResistance = 5;
            this.defaultMissChance = 0;

            this.Health = this.defaultHealth;
            this.HealthRegeneration = this.defaultHealthRegeneration;
            this.PhysicalDamage = this.defaultPhysicleDamage;
            this.MagicalDamage = this.defaultMagicalDamage;
            this.PhysicalResistance = this.defaultPhysicalResistance;
            this.MagicalResistance = this.defaultMagicalResistance;
            this.CriticalChance = this.defaultCriticalChance;
            this.DodgeChance = this.defaultDodgeChance;
            this.MissChance = this.defaultMissChance;
            this.numberOFAttack = 0;
            this.damageDealt = 0;
            this.damageRecived = 0;
        }

        public override void addArtefact(List<Artefact> artefacts_)
        {
            if (artefacts != null)
            {
                foreach (Artefact a in artefacts_)
                {
                    this.artefacts.Add(a);
                    this.Health += a.health;
                    this.HealthRegeneration += a.HealthRegeneration;
                    this.PhysicalDamage += a.physicalDamage;
                    this.MagicalDamage += a.magicalDamage;
                    this.PhysicalResistance += a.PhysicalResistance;
                    this.MagicalResistance += a.MagicalResistance;
                    this.CriticalChance += a.CriticalChance;
                    this.DodgeChance += a.DodgeChance;
                    this.MissChance += a.MissChance;

                }
            }

        }

        public override void weatherFactors(Weather weather)
        {
            this.MagicalResistance += weather.magicResistance;
            if (weather.Name == "Dark night")
            {
                this.HealthRegeneration += 10;
            }
            else
            {
                this.HealthRegeneration += weather.helthRegeneration;
                
            }
            this.MissChance += weather.missChance;

        }

        override public int getAttacked(int physicalDamage_, int magicalDamage_,
            int damageDealt_)
        {
            double dmg = physicalDamage_;
            double magDmg = magicalDamage_;
            if (physicalDamage_ != 0)
            {
                Random r = new Random();
                if (r.Next(1, 100) <= this.DodgeChance)
                {
                    Console.WriteLine("Dodged");
                }
                else
                {
                    double kofOfPhysicleResistanse = (0.052 * this.PhysicalResistance) /
                        (0.9 + 0.048 * this.PhysicalResistance);
                    dmg *= (1 - kofOfPhysicleResistanse);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine((int)dmg);
                    Console.ResetColor();
                }

            }
            double kofOfMagResistanse = (0.052 * this.MagicalResistance) /
                        (0.9 + 0.048 * this.MagicalResistance);
            magDmg *= (1 - kofOfMagResistanse);
            if (magDmg != 0)
            {
                Console.Write("Magical damage ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((int)magDmg);
                Console.ResetColor();
            }

            this.damageRecived += (int)(magDmg + dmg);
            this.Health -= (int)(magDmg + dmg);
            this.HealthCheking();
            return (int)(magDmg + dmg);

        }

        public override int phisicalAttack()
        {
            Random r = new Random();
            if (r.Next(1, 100) <= this.MissChance)
            {
                Console.Write("Miss");
                return 0;
            }
            double dmg = this.PhysicalDamage;
 
            return (int)dmg;

        }

        public override int magicalAttack()
        {
            Random r = new Random();

            if(r.Next(1,100) <= 20) 
            {
                int magDMG = this.MagicalDamage * 2;
                Console.WriteLine("Nature is helping me ");     
                this.numberOFAttack = 0;
                return magDMG;
            }
         
            return this.MagicalDamage;
        }

        public override int Regeneration()
        {
            int healthLine = this.Health;
            this.Health += this.HealthRegeneration;
            if (Health > healthLine)
            {
                Health = healthLine;
            }
            return this.HealthRegeneration;
        }


    }
}

