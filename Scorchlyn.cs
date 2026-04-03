/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Scorchlyn is one of the starter creatures that players can choose at the beginning of the game, as well as capture in the wild. 
 * Child class representing the Scorchlyn creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Scorchlyn's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Scorchlyn: Creatures
    {
        public Scorchlyn(int health, int level, bool isCaptured = false, Dictionary<String, Dictionary<String, int>> abilities = null) : base(name: "Scorchlyn", health, level, type: CreatureType.Fire, isCaptured, abilities)
        {
        }
        public override void CreatureDescription()
         {
             Console.WriteLine("This creature is found at the base of the Belisle Coast inactive volcano of the Tertiannary Mountains at the heart of the region. It’s rarely found beyond this territory as it is extremely territorial. If agitated, it can get very aggressive!");
             Console.WriteLine(""); // Provide a detailed description of Scorchlyn's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
         }
    }
}