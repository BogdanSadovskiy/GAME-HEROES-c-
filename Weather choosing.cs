
namespace myGame
{
     class Weather_choosing
    {
        public  Weather randWeather()
        {
            Console.WriteLine("\n\n\t\t\tLoading the weather");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tLoading the weather _");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tLoading the weather _ _");
            Thread.Sleep(1000);
            Console.Clear();
            Random r = new Random();
            int number = r.Next(1, 3);
            Weather s;
            if (number == 1)
            {
                Console.WriteLine("\n\n\t\t\tSunny weather");
                s = new Sunny();

            }
            else if (number == 2)
            {
                Console.WriteLine("\n\n\t\t\tCloudy weather");
                s = new Cloudy();

            }
            else
            {
                Console.WriteLine("\n\n\t\t\tDark Night");
                s = new DarkNight();
            }
            Console.WriteLine("\t\tHealth Regeneration: " + s.helthRegeneration);
            Console.WriteLine("\t\tMagic resistance: " + s.magicResistance);
            Console.WriteLine("\t\tMiss chance: " + s.missChance);
            Thread.Sleep(3000);


            return s;
        }
    }
}
