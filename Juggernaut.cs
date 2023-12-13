

namespace myGame;

class Juggernaut : Hero
{
    public Juggernaut()
    {

        this.Name = "Juggernaut";
        this.HeroDescr = "Every 3 deals 175% damage\n" +
            "When Sunny - magical resistance +15";
        
        this.defaultHealth = 1600;
        this.defaultHealthRegeneration = 15;
        this.damageType = DamageTYPE.Physical;
        this.defaultPhysicleDamage = 160;
        this.defaultMagicalDamage = 0;
        this.defaultCriticalChance = 20;
        this.defaultDodgeChance = 5;
        this.defaultMagicalResistance = 20;
        this.defaultPhysicalResistance = 30;
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
        this.damageDealt = 0;
        this.damageRecived = 0;
        this.Gold = 1000;
    }



    public override void weatherFactors(Weather weather)
    {
        this.HealthRegeneration += weather.helthRegeneration;
        if(weather.Name == "Sunny")
        {
            this.MagicalResistance += 15;
        }
        else
        {
            this.MagicalResistance += weather.magicResistance;
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
        if (this.numberOFAttack == 2)     ///HEro ability double damage every 3 hit
        {
            Console.WriteLine("Ability used");
            dmg *= 1.75;
            this.numberOFAttack = 0;
        }
        if(r.Next(1,100)<= this.CriticalChance)
        {
            Console.Write("Critical dmg ");
            dmg *= 1.75;
        }
        this.numberOFAttack++;
        return (int)dmg;

    }

    public override int magicalAttack()
    {
        return this.MagicalDamage;
    }

    public override int Regeneration()
    {
        this.currenthealth += this.HealthRegeneration;
        HealthCheking();
        return this.HealthRegeneration;
    }

    public override void GoldEarn(Hero hero)
    {
        if(hero.Health == 0)
        {
            this.Gold += 2000;
        }
        this.Gold += 8;
    }
}
