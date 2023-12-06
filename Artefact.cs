﻿
using System.Runtime.CompilerServices;

namespace myGame
{
    abstract class Artefact
    {
        public string Name { get; set; }
        public int price { get; set; }
        public int sellPrice { get { return  (int)(this.price * 0.7);}  }
        public int health { get; set; }
        public int HealthRegeneration { get; set; }
        public int physicalDamage { get; set; }
        public int magicalDamage { get; set; }
        public int MagicalResistance { get; set; }
        public int PhysicalResistance { get; set; }
        public int CriticalChance { get; set; }
        public int DodgeChance { get; set; }
        public int MissChance { get; set; }

        public bool buyArtefact (int gold)
        {
            if(this.price> gold)
            {
                return false;
            }
            return true;
        }

    }
}
