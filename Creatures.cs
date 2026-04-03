using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
/*
    * This file defines the Creatures class and the CreatureType enum for the Codex Game.
    * The Creatures class is an abstract class that represents a creature in the game, with properties such as name, health, 
    level, type, and capture status.
    * The CreatureType enum defines the different types of creatures available in the game: Earth, Fire, Water, and Wind.
*/
namespace CodexGame
{
    enum CreatureType
    {
        Earth,
        Fire,
        Water,
        Wind
    }
    internal abstract class Creatures // Parent Class representing a creature in the Codex Game
    {
        private String name;
        private int health;
        private int level;
        private CreatureType type;
        private bool isCaptured;
        private Dictionary<String, Dictionary<String, int>> abilities = new Dictionary<String, Dictionary<String, int>> { { "Attack", new Dictionary<String, int>() }, { "Defense", new Dictionary<String, int>() } }; // Dictionary to store the creature's abilities, which will allow for dynamic addition and management of abilities for each creature, enhancing the depth and customization options for players.
        public Creatures(String name, int health, int level, CreatureType type, bool isCaptured = false, Dictionary<String, Dictionary<String, int>> abilities = null)
        {
            this.name = name;
            this.health = health;
            this.level = level;
            this.type = type;
            this.abilities = abilities ?? new Dictionary<String, Dictionary<String, int>> { { "Attack", new Dictionary<String, int>() }, { "Defense", new Dictionary<String, int>() } };
            this.isCaptured = isCaptured;
        }
        public void CreatureStats()
        {
            Console.WriteLine($"Name: {name}\nHealth: {health}\nLevel: {level}\nType: {type}");
            Console.WriteLine("");// Display the creature's stats in a clear and organized format, which will allow players to easily understand their creature's attributes and make informed decisions during battles and interactions.
            Console.WriteLine("Attack:");
            foreach (var attack in abilities["Attack"])
            {
                Console.WriteLine($"- {attack.Key}: {attack.Value}");
            }
            Console.WriteLine("Defense:");
            foreach (var defense in abilities["Defense"])
            {
                Console.WriteLine($"- {defense.Key}: {defense.Value}");
            }
            Console.WriteLine(""); // Display the creature's abilities in a clear and organized format, which will allow players to easily understand their creature's capabilities and make informed decisions during battles and interactions.    

        }   
        public void Capture() // Update the creature's capture status and provide feedback to the player, enhancing their sense of accomplishment and connection to the creature.
        {
            isCaptured = true;
            Console.WriteLine($"{name} has been captured!"); 
        }
        public void UpdateHealth(int amount) // Update the creature's health by a specified amount, which will allow players to manage their creature's health during battles and interactions, adding a strategic element to the gameplay.
        {
            if (health + amount < 0)
            {
                health = 0;
            }
            else if (health + amount > 100)
            {
                health = 100;
            }
            else
            {
                health += amount;
            }
        }
        public void AddAttack(String attackName, int power) // Add an attack name and power to the dictionary.
        {
            abilities["Attack"].Add(attackName, power);
        }
        public void AddDefense(String defenseName, int defense) // Add a defense name and value to the dictionary.
        {
            abilities["Defense"].Add(defenseName, defense);
        }
        public abstract void CreatureDescription();
    }
}