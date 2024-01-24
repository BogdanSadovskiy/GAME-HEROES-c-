

namespace myGame
{
    internal class Nature_Prophet : Hero
    {
        public Nature_Prophet()
        {

            this.Name = "Nature Prophet";
            this.HeroDescr = "Has 20% chance to deal double magic damage\n" +
                "When it is Dark Night - health regeneration +10";

            this.defaultHealth = 2350;
            this.defaultHealthRegeneration = 47;
            this.damageType = DamageTYPE.Magical;
            this.defaultPhysicleDamage = 60;
            this.defaultMagicalDamage = 140;
            this.defaultCriticalChance = 0;
            this.defaultDodgeChance = 25;
            this.defaultMagicalResistance = 30;
            this.defaultPhysicalResistance = 5;
            this.defaultMissChance = 5;
            this.defaultReturnedDamage = 0;

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
            this.returnedDamage = defaultReturnedDamage;
            this.damageDealt = 0;
            this.damageRecived = 0;
            this.Gold = 1000;
            this.GoldIncrease = 0;
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

        public override int heroFeaturePhysicalAttack()
        {
            return commonPhisicalAttack();
        }

        public override int heroFeatureMagicalAttack()
        {
            if(random.Next(1, 100) <= 20)
            {
                int dmg = this.MagicalDamage * 2;
                Console.WriteLine("The power of nature "); // hero ability to get increased power
                this.damageDealt += dmg;
                return dmg;
            }
            return commonMagicalAttack();
        }
  

    }
}

