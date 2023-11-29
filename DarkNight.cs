using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    internal class DarkNight : Weather
    {
        public DarkNight()
        {
            this.Name = "Dark night";
            this.helthRegeneration = -5;
            this.missChance = 20;
            this.magicResistance = -10;
        }
    }
}
