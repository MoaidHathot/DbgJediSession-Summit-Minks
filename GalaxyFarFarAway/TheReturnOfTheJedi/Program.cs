using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyFarFarAway;
using StarWarsUtilities;

namespace TheReturnOfTheJedi
{
    class Program
    {
        static void Main(string[] args)
        {
            var jedies = new[]
            {
                new JediKnight("Yoda", 9001, new ForceUserWeapon(LightsaberType.Lightsaber, ConsoleColor.Green)),
                new JediKnight("Obi-Wan Kenobi", 5000, new ForceUserWeapon(LightsaberType.Lightsaber, ConsoleColor.Cyan)),
                new JediKnight("Luke Skywalker", 6000, new ForceUserWeapon(LightsaberType.Lightsaber, ConsoleColor.Cyan)),
                new JediKnight("Mace Windu", 3000, new ForceUserWeapon(LightsaberType.Lightsaber, ConsoleColor.Magenta))
            };

            var siths = new[]
            {
                new SithLord("Darth Vader", 15000, new ForceUserWeapon(LightsaberType.Lightsaber, ConsoleColor.Red), "Cool Voice", "Swag"),
                new SithLord("Darth Maul", 7000, new ForceUserWeapon(LightsaberType.DoubleLightsaber, ConsoleColor.Red)),
                new SithLord("Kylo Ren", 6500, new ForceUserWeapon(LightsaberType.CrossgaurdLightsaber, ConsoleColor.Red), "Freeze layzer rays", "Be stupid")
            };

            var forceUsers = jedies.Concat<IForceUser>(siths).ToList();

            for (var index = 0; index < int.MaxValue; ++index)
            {
                foreach (var forceUser in forceUsers)
                {
                    Train(forceUser).Wait();
                }
            }

            Debug.WriteLine($"Press enter to quit.");
            Console.ReadLine();
        }
        static async Task Train(IForceUser user)
        {
            user.UseForce();

            //var academy = new StarWarsAcademy();
            //await academy.Train(user);
        }

    }
}
