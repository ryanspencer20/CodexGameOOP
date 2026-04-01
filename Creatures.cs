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
        public Creatures(String name, int health, int level, CreatureType type, bool isCaptured = false)
        {
            this.name = name;
            this.health = health;
            this.level = level;
            this.type = type;
            this.isCaptured = isCaptured;
        }
        public void CreatureStats()
        {
            Console.WriteLine($"Name: {name}\nHealth: {health}\nLevel: {level}\nType: {type}\nCaptured: {isCaptured}");
            Console.WriteLine("");// Display the creature's stats in a clear and organized format, which will allow players to easily understand their creature's attributes and make informed decisions during battles and interactions.
        }
        public abstract void CreatureDescription();
    }
}