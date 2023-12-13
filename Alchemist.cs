

namespace myGame
{

    internal class Alchemist : Hero
    {
        public Alchemist()
        {

            this.Name = "Alchemist";
            this.HeroDescr = "Starting gold - 1200\nHas increased gold income by 18\n" +
                "When Sunny - gold income + 10\n" + "When Cloudy - gold income + 5\n"
                + "When Dark night - gold income +19 / physical damage -30";

            this.defaultHealth = 1500;
            this.defaultHealthRegeneration = 7;
            this.damageType = DamageTYPE.Physical;
            this.defaultPhysicleDamage = 150;
            this.defaultMagicalDamage = 0;
            this.defaultCriticalChance = 0;
            this.defaultDodgeChance = 5;
            this.defaultMagicalResistance = 20;
            this.defaultPhysicalResistance = 15;
            this.defaultMissChance = 0;

            this.Health = this.defaultHealth;
            this.currenthealth = Health;
            this.HealthRegeneration = this.defaultHealthRegeneration;
            this.PhysicalDamage = this.defaultPhysicleDamage;
            this.MagicalDamage = this.defaultMagicalDamage;
            this.PhysicalResistance = this.defaultPhysicalResistance;
            this.MagicalResistance = this.defaultMagicalResistance;
            this.CriticalChance = this.defaultCriticalChance;
            this.DodgeChance = this.defaultDodgeChance;
            this.MissChance = this.defaultMissChance;
            this.numberOFAttack = 0;
            this.returnedDamage = 0;
            this.damageDealt = 0;
            this.damageRecived = 0;
            this.Gold = 1200;
            this.GoldIncrease = 18;
        }



        public override void weatherFactors(Weather weather)
        {

            if (weather.Name == "Sunny")
            {
                this.GoldIncrease += 10;
            }
            if (weather.Name == "Dark night")
            {
                this.GoldIncrease += 19;
                this.PhysicalDamage -= 30;
            }
            if (weather.Name == "Cloudy")
            {
                this.GoldIncrease += 5;
            }
            this.HealthRegeneration += weather.helthRegeneration;
            this.MagicalResistance += weather.magicResistance;
            this.MissChance+= weather.missChance;

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
                    Console.WriteLine("Physical damage - " + (int)dmg);
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
            this.currenthealth -= (int)(magDmg + dmg);
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

            if (r.Next(1, 100) <= this.CriticalChance)
            {
                Console.Write("Critical dmg ");
                dmg *= 1.75;
            }
            this.damageDealt += (int)dmg;
            return (int)dmg;

        }

        public override int magicalAttack()
        {
            this.damageDealt += this.MagicalDamage;
            return this.MagicalDamage;
        }

        public override int Regeneration()
        {
            this.currenthealth += this.HealthRegeneration;
            HealthCheking();
            this.healed += this.HealthRegeneration;
            return this.HealthRegeneration;
        }

        public override void GoldEarn(Hero hero)
        {
            if (hero.Health == 0)
            {
                this.Gold += 2000;
            }
            this.Gold += 8 + GoldIncrease;
        }
    }
}
