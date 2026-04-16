/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Coral-Slash is a wild creature that players can encounter and capture in the game. 
 * Child class representing the Coral-Slash creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Coral-Slash's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class Coralslash: Creatures
    {
        public Coralslash(int health, int level, bool isCaptured = false) : base(name: "Coral-Slash", health, level, type: CreatureType.Water, isCaptured, evasion: 0.3, accuracy: 0.83)
        {
            base.AddAttack("Tidal Slash", 30);
            base.AddDefense("Water Guard", 10);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("Coral-Slash is a sleek and agile creature that resembles a combination of a coral reef and a predatory fish. It has a vibrant and colorful appearance, with sharp, blade-like fins that it uses to slash through its opponents in battle. Coral-Slash is known for its speed and precision, able to strike quickly and accurately while evading attacks with its agile movements. It has a calm and collected demeanor, often using its strategic thinking to outmaneuver its opponents in combat. Coral-Slash is also highly adaptable, able to thrive in various aquatic environments and utilize its surroundings to its advantage during battles.");
            Console.WriteLine(""); // Provide a detailed description of Coral-Slash's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}