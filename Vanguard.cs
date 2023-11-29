

namespace myGame
{
    internal class Vanguard : Artefact
    {
        public Vanguard()
        {
            this.Name = "Vanguard";
            this.price = 2000;
            this.health = 250;
            this.HealthRegeneration = 10;
            this.physicalDamage = 10;
            this.magicalDamage = 0;
            this.PhysicalResistance = 10;
            this.MagicalResistance = 0;
            this.CriticalChance = 0;
            this.DodgeChance = 0;
            this.MissChance = 0;
        }
    }
}
