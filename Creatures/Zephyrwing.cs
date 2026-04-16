/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Zephyr-Wing is a wild creature that players can encounter and capture in the game. 
 * Child class representing the Zephyr-Wing creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Zephyr-Wing's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Zephyrwing: Creatures
    {
        public Zephyrwing(int health, int level, bool isCaptured = false) : base(name: "Zephyr-Wing", health, level, type: CreatureType.Wind, isCaptured, evasion: 0.24, accuracy: 0.91)
        {
            base.AddAttack("Gust", 20);
            base.AddDefense("Air Barrier", 10);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("Zephyr-Wing is a graceful and agile creature that resembles a combination of a bird and a butterfly. It has large, colorful wings that allow it to soar through the air with ease, and its slender body is covered in soft, feathery fur. Zephyr-Wing is known for its speed and agility, able to quickly dodge attacks while delivering swift and precise strikes to its opponents. It has a gentle and serene personality, often using its calming presence to diffuse tense situations and avoid unnecessary conflicts. Zephyr-Wing is also highly intelligent, able to analyze its surroundings and adapt its strategies during battles.");
            Console.WriteLine(""); // Provide a detailed description of Zephyr-Wing's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}