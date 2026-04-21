/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * Ash-Hoof is a wild creature that players can encounter and capture in the game. 
 * Child class representing the Ash-Hoof creature, which inherits from the Creatures parent class and provides specific implementation for the CreatureDescription method to describe Ash-Hoof's characteristics and behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodexGame
{
    internal class AshHoof: Creatures
    {
        public AshHoof(int health, int level, bool isCaptured = false) : base(name: "Ash-Hoof", health, level, type: CreatureType.Fire, isCaptured, evasion: 0.28, accuracy: 0.90)
        {
            base.AddAttack("Stomp", 15); // added another attack
            base.AddAttack("Flaming Charge", 25);
            base.AddDefense("Ashen Guard", 5);
        }
        public override void CreatureDescription()
        {
            Console.WriteLine("Ash-Hoof is a fiery creature with a strong and sturdy build, resembling a horse with flames emanating from its hooves. It has a fierce and determined personality, often charging headfirst into battle with its powerful flaming attacks. Ash-Hoof is known for its resilience and endurance, able to withstand heavy damage while delivering devastating blows to its opponents. Its fiery nature also gives it an advantage against certain types of creatures, making it a formidable opponent in battles.");
            Console.WriteLine(""); // Provide a detailed description of Ash-Hoof's characteristics and behavior, which will help players understand the creature's strengths, weaknesses, and personality, enhancing their connection to the creature and their immersion in the game world.
        }
    }
}