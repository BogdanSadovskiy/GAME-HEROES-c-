

namespace myGame
{
    internal class Butterfly : Artefact
    {
        public Butterfly()
        {
            this.Name = "Butterfly";
            this.health = 0;
            this.HealthRegeneration = 0;
            this.physicalDamage = 70;
            this.magicalDamage = 0;
            this.PhysicalResistance = 0;
            this.MagicalResistance = 20;
            this.CriticalChance = 30;
            this.DodgeChance = 0;
            this.MissChance = 0;
        }
    }
}
