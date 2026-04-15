/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Thorntail is a wild creature that players can encounter and capture in the game. 
 * Child class representing the Thorntail creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Thorntail's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Thorntail: Creatures
    {
        public Thorntail(int health, int level, bool isCaptured = false) : base(name: "Thorntail", health, level, type: CreatureType.Earth, isCaptured, evasion: 0.15, accuracy: 0.89)
        {
            base.AddAttack("Spike Strike", 20);
            base.AddDefense("Thorn Shield", 15);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("Thorntail is a fierce and agile creature that resembles a combination of a feline and a porcupine. It has a sleek and muscular build, with sharp, thorn-like quills covering its back and tail. Thorntail is known for its quick reflexes and agility, able to dodge attacks with ease while delivering swift and precise strikes to its opponents. Its thorny quills also provide it with a natural defense mechanism, allowing it to deter attackers and protect itself in battle. Thorntail has a bold and confident personality, often taking the initiative in combat and using its speed and agility to outmaneuver its opponents.");
            Console.WriteLine(""); // Provide a detailed description of Thorntail's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}