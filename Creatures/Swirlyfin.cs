/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Swirlyfin is one of the starter creatures that players can choose at the beginning of the game, as well as capture in the wild. 
 * Child class representing the Swirlyfin creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Swirlyfin's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Swirlyfin: Creatures
    {
        public Swirlyfin(int health, int level, bool isCaptured = false) : base(name: "Swirlyfin", health, level, type: CreatureType.Water, isCaptured, evasion: 0.32, accuracy: 0.78)
        {
            base.AddAttack("Whirlpool", 30);
            base.AddDefense("Agility", 15);
            base.AddDefense("Fin Array", 20);
        }

        public override void CreatureDescription()
        {
            Console.WriteLine("This fish-like entity swims in the shallow waters of the Belisle Coast shorelines. It’s swift like movements make is impossible to catch! Its fins come in an array of beautiful colors that shine when displayed by Swirlyfin’s command, distracting prey and threats.  ");
            Console.WriteLine(""); // Provide a detailed description of Swirlyfin's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}