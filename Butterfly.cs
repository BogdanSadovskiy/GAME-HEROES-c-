﻿

namespace myGame
{
    internal class Butterfly : Artefact
    {
        public Butterfly()
        {
            this.Name = "Butterfly";
            this.price = 3000;
            this.health = 0;
            this.HealthRegeneration = 0;
            this.physicalDamage = 70;
            this.magicalDamage = 0;
            this.PhysicalResistance = 0;
            this.MagicalResistance = 0;
            this.CriticalChance = 0;
            this.DodgeChance = 25;
            this.MissChance = 0;
            this.GoldIncrease = 0;
            this.returnedDamage = 0;
        }
    }
}
