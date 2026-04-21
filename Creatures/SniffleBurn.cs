/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * SniffleBurn is a wild creature that players can encounter and capture in the game. 
 * Child class representing the SniffleBurn creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Ash-Hoof's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class SniffleBurn : Creatures
    {
        public SniffleBurn(int health, int level, bool isCaptured = false) : base(name: "SniffleBurn", health, level, type: CreatureType.Fire, isCaptured, evasion: 0.19, accuracy: 0.76)
        {
            base.AddAttack("Ashen Sneeze", 20);
            base.AddAttack("Magma Snot Fling", 30);
            base.AddDefense("Contagious", 15);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("SniffleBurn is a sloth like creature with flaming back fur. They are said to mostly dwell in volcanic chambers, but once in a while will wander out and get lost. Most creatures tend to avoid them for there sorry look of always being sick so they believe theyll catch whatever contagen they carry.");
            Console.WriteLine(""); // Provide a detailed description of SniffleBurn's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}