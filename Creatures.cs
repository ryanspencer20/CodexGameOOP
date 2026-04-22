using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
/*
    * This file defines the Creatures class and the CreatureType enum for the Codex Game.
    * The Creatures class is an abstract class that represents a creature in the game, with properties such as name, health, 
    level, type, and capture status.
    * The CreatureType enum defines the different types of creatures available in the game: Earth, Fire, Water, and Wind.
    * The Creatures class includes methods for managing the creature's health, abilities, and capture status, 
    as well as a virtual method for displaying a creature description.
*/
namespace CodexGame
{
    enum CreatureType // Enum to represent the different types of creatures in the game. 
    {
        Earth,
        Fire,
        Water,
        Wind
    }
    internal class Creatures // Parent Class representing a creature in the Codex Game.
    {
        private String name; // The creature's name
        private int health; // The creature's health
        private int level; // The creature's level
        private CreatureType type; // The creature's type
        private bool isCaptured; // Whether the creature has been captured
        private int activeDefense = 0; // The creature's active defense
        private double evasion; // The creature's evasion percentage
        private double accuracy; // The creature's accuracy percentage
        private Dictionary<String, Dictionary<String, int>> abilities = new Dictionary<String, Dictionary<String, int>> { { "Attack", new Dictionary<String, int>() }, { "Defense", new Dictionary<String, int>() } }; // Dictionary to store the creature's abilities, which will allow for dynamic addition and management of abilities for each creature, enhancing the depth and customization options for players.
        public Creatures(String name, int health, int level, CreatureType type, bool isCaptured = false, double evasion = 0, double accuracy = 0, Dictionary<String, Dictionary<String, int>> abilities = null)
        {
            this.name = name;
            this.health = health;
            this.level = level;
            this.type = type;
            this.abilities = abilities ?? new Dictionary<String, Dictionary<String, int>> { { "Attack", new Dictionary<String, int>() }, { "Defense", new Dictionary<String, int>() } };
            this.isCaptured = isCaptured;
            this.evasion = evasion;
            this.accuracy = accuracy;
        }
        public String GetName() // Get the creature's name, which will allow players to easily identify and refer to their creatures during battles and interactions.
        {
            return name;
        }   
        public Dictionary<string, int> GetAttackMoves() // Get the creature's attack moves, which will allow players to easily identify and utilize their creature's offensive capabilities during battles and interactions.
        {
            return abilities["Attack"];
        }
        public Dictionary<string, int> GetDefenseMoves() // Get the creature's defense moves, which will allow players to easily identify and utilize their creature's defensive capabilities during battles and interactions.
        {
            return abilities["Defense"];
        }
        public void SetHealth(int newHealth) // Set the creature's health, which will allow players to easily manage their creature's health during battles and interactions, adding a strategic element to the gameplay.
        {
            this.health = newHealth;
        }
        public void CreatureStats() // Display the creature's stats, which will allow players to easily understand their creature's attributes and make informed decisions during battles and interactions.
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
        public int GetHealth() // Get the creature's health, which will allow players to easily identify and refer to their creatures during battles and interactions.
        {
            return health;
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
        public int GetDefense() // Return the creature's current active defense value, which will allow players to easily identify and refer to their creature's defensive capabilities during battles and interactions.
        {
            return activeDefense;
        }
        public void AddActiveDefense(int amount) // Add a specified amount to the creature's active defense, which will allow players to manage their creature's defensive capabilities during battles and interactions, adding a strategic element to the gameplay.
        {
            if ((activeDefense + amount) > 50) activeDefense = 50;
            else activeDefense += amount;
        }
        public int DefenseUsed(int amount) // Subtract a specified amount from the creature's active defense when it is used, which will allow players to manage their creature's defensive capabilities during battles and interactions, adding a strategic element to the gameplay.
        {
            if ((activeDefense - amount) < 0) activeDefense = 0;
            else activeDefense -= amount;
            return activeDefense;
        }
        public virtual void AddAttack(String attackName, int power) // Add an attack name and power to the dictionary, which will allow players to easily identify and utilize their creature's offensive capabilities during battles and interactions.
        {
            abilities["Attack"].Add(attackName, power);
        }
        public virtual void AddDefense(String defenseName, int defense) // Add a defense name and value to the dictionary, which will allow players to easily identify and utilize their creature's defensive capabilities during battles and interactions.
        {
            abilities["Defense"].Add(defenseName, defense);
        }
        public double GetEvasion() // Return the creature's evasion percentage, which will allow players to easily identify and refer to their creature's evasive capabilities during battles and interactions.
        {
            return evasion * 100;
        }
        
        public double GetAccuracy() // Return the creature's accuracy percentage, which will allow players to easily identify and refer to their creature's accuracy during battles and interactions.
        {
            return accuracy * 100;
        }
        public virtual void CreatureDescription() // Virtual method to display a description of the inherited creature, which will provide players with background information and enhance their connection to the creature.
        {
        }
    }
}