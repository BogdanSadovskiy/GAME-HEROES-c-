

namespace myGame
{

    internal class Alchemist : Hero
    {
        public Alchemist()
        {

            this.Name = "Alchemist";
            this.HeroDescr = "Starting gold - 1200\nHas increased gold income by 8\n" +
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
            this.GoldIncrease = 8;
        }

        public override int heroFeatureMagicalAttack()
        {
            return commonMagicalAttack();
        }

        public override int heroFeaturePhysicalAttack()
        {
            return commonPhisicalAttack();
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

       

        
    }
}
