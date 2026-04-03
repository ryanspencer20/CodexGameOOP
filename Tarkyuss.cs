/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Tarkyuss is one of the starter creatures that players can choose at the beginning of the game, as well as capture in the wild. 
 * Child class representing the Tarkyuss creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Tarkyuss's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Tarkyuss: Creatures
    {
        public Tarkyuss(int health, int level, bool isCaptured = false, Dictionary<String, Dictionary<String, int>> abilities = null) : base(name: "Tarkyuss", health, level, type: CreatureType.Earth, isCaptured, abilities)
        {
        }

        public override void CreatureDescription()
        {
            Console.WriteLine("This armadillo-looking creature with rocky spikes protruding on its back make it a hard target to hit. Its aggressive nature is of most danger if provoked. It resides among the rock cliffs and mounds to burrow homes for themselves.");
            Console.WriteLine(""); // Provide a detailed description of Tarkyuss's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}