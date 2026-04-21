/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * SeaCucumbra is a wild creature that players can encounter and capture in the game. 
 * Child class representing the SeaCucumbra creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Coral-Slash's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class SeaCucumbra : Creatures
    {
        public SeaCucumbra(int health, int level, bool isCaptured = false) : base(name: "SeaCucumbra", health, level, type: CreatureType.Water, isCaptured, evasion: 0.1, accuracy: 0.67)
        {
            base.AddAttack("Wiggle", 10);
            base.AddDefense("Wiggle", 10);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("Honestly theres not much to say about this creature its a sea cucumber, and it wiggles! wiggle, wiggle!"); // gotta have magic carp equivalent of useless
            Console.WriteLine(""); // Provide a detailed description of SeaCucumbra characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}