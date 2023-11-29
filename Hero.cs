
namespace myGame
{
    abstract class Hero
    {
        public List<Artefact> artefacts;
        public int numberOFAttack;
        public string Name { get; set; }
        public string HeroDescr { get; set; }
        public int defaultHealth { get; set; }
        public int defaultHealthRegeneration { get; set; }
        public DamageTYPE damageType { get; set; }
        public int defaultPhysicleDamage { get; set; }
        public int defaultMagicalDamage { get; set; }
        public int defaultPhysicalResistance { get; set; }
        public int defaultMagicalResistance { get; set; }
        public int defaultCriticalChance { get; set; }
        public int defaultDodgeChance { get; set; }
        public int defaultMissChance { get; set; }

        public int Health { get; set; }
        public int HealthRegeneration { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicalDamage { get; set; }
        public int PhysicalResistance { get; set; }
        public int MagicalResistance { get; set; }
        public int CriticalChance { get; set; }
        public int DodgeChance { get; set; }
        public int MissChance { get; set; }

        public int damageDealt { get; set; }
        public int damageRecived { get; set; }
        public int healed { get; set; }

        abstract public void addArtefact(List<Artefact> artefacts);
        abstract public void weatherFactors(Weather weather);


        public void HealthCheking()
        {
            if(this.Health < 0)
            {
                Health = 0;
            }
        }
        abstract public int phisicalAttack();
        abstract public int magicalAttack();
        abstract public int Regeneration();
        abstract public int getAttacked(int physicalDamage_, int magicalDamage_,
        int damageDealt_);

    };
}
