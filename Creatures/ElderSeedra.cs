/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * ElderSeedra is a wild creature that players can encounter and capture in the game. 
 * Child class representing the ElderSeedra creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe ElderSeedra's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class ElderSeedra : Creatures
    {
        public ElderSeedra(int health, int level, bool isCaptured = false) : base(name: "ElderSeedra", health, level, type: CreatureType.Wind, isCaptured, evasion: 0.30, accuracy: 0.82)
        {
            base.AddAttack("Vortex", 20);
            base.AddAttack("Elder Root Veil Tear", 45);
            base.AddDefense("Realm Phase", 20);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("ElderSeedra is a rare creature that is a seed created by the World Tree that floats on the wind currents of the different realms theorized to exist. They are always riding the currents and if the wind weakens they shift realms to more favorable condition in search of a place to bring forth a new elder tree. ");
            Console.WriteLine(""); // Provide a detailed description of ElderSeedra characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}