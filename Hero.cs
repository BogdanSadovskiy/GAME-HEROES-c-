
namespace myGame
{
    abstract class Hero
    {
        public List<Artefact> artefacts = new List<Artefact>();
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


        public int Gold { get; set;}   
        public int GoldIncrease { get; set;}
        public int Health { get; set; }
        public int currenthealth { get; set; }
        public int HealthRegeneration { get; set; }
        public int PhysicalDamage { get; set; }
        public int MagicalDamage { get; set; }
        public int PhysicalResistance { get; set; }
        public int MagicalResistance { get; set; }
        public int CriticalChance { get; set; }
        public int DodgeChance { get; set; }
        public int MissChance { get; set; }
        public int returnedDamage { get; set; }
        public int damageDealt { get; set; }
        public int damageRecived { get; set; }
        public int healed { get; set; }


        public int isArtefactsFull()           
        {
            return artefacts.Count();
        }

        public void removeArtefact(int index)
        {
            this.Health -= this.artefacts[index].health;
            this.currenthealth -= this.artefacts[index].health;
            this.HealthRegeneration -= this.artefacts[index].HealthRegeneration;
            this.PhysicalDamage -= this.artefacts[index].physicalDamage;
            this.MagicalDamage -= this.artefacts[index].magicalDamage;
            this.PhysicalResistance -= this.artefacts[index].PhysicalResistance;
            this.MagicalResistance -= this.artefacts[index].MagicalResistance;
            this.CriticalChance -= this.artefacts[index].CriticalChance;
            this.DodgeChance -= this.artefacts[index].DodgeChance;
            this.MissChance -= this.artefacts[index].MissChance;
            this.GoldIncrease-= this.artefacts[index].GoldIncrease;
            this.returnedDamage -= this.artefacts[index].returnedDamage;
            this.artefacts.RemoveAt(index);
        }
        public void addArtefact(Artefact a)
        {

            if (a != null)
            {
                this.artefacts.Add(a);
                this.Health += a.health;
                this.currenthealth += a.health;
                this.HealthRegeneration += a.HealthRegeneration;
                this.PhysicalDamage += a.physicalDamage;
                this.MagicalDamage += a.magicalDamage;
                this.PhysicalResistance += a.PhysicalResistance;
                this.MagicalResistance += a.MagicalResistance;
                this.CriticalChance += a.CriticalChance;
                this.DodgeChance += a.DodgeChance;
                this.MissChance += a.MissChance;
                this.GoldIncrease += a.GoldIncrease;
                this.returnedDamage+= a.returnedDamage;

            }
        }
        abstract public void weatherFactors(Weather weather);
        public int returnedDMG (int DMG)
        {
            if(this.returnedDamage == 0) { return 0; }
            int d = (int)(DMG * (0.01 * this.returnedDamage));
            Console.Write(this.Name +" returned damage - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(d);
            Console.ResetColor();
            return d ;
        } 

        public void HealthCheking()
        {
            if(this.currenthealth < 0)
            {
                currenthealth = 0;
            }
            if (currenthealth > this.Health)
            {
                currenthealth = Health;
            }
        }
        abstract public int phisicalAttack();
        abstract public int magicalAttack();
        abstract public int Regeneration();
        abstract public int getAttacked(int physicalDamage_, int magicalDamage_,
        int damageDealt_);
        public void DamageCounter(int damage)
        {
            this.damageDealt+= damage;
        }
        abstract public  void GoldEarn(Hero hero);
        public bool isHeroAlive()
        {
            if (this.currenthealth <= 0)
            {
                return false;
            }
            return true;
        }
        public void other(Hero hero, int damage)
        {
            hero.DamageCounter( hero.returnedDMG(damage)); //counting returned damage
            this.Regeneration();
            this.GoldEarn(hero);

        }
    };
}
