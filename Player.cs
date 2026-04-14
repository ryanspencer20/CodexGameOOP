using System;
using System.Collections.Generic;

namespace CodexGame
{
    internal class Player
    {
        private string playerName;
        private List<Creatures> collection; // A list of captured creatures
        private Creatures activeCreature;   // The creature currently active

        // Inventory Dictionary
        private Dictionary<string, int> inventory;

        public Player(string name, Creatures starter)
        {
            this.playerName = name;

            this.collection = new List<Creatures>();
            this.inventory = new Dictionary<string, int>();

            this.collection.Add(starter);
            this.activeCreature = starter;

            // Give the player some starting items
            this.inventory.Add("Soul Ball", 5);
            this.inventory.Add("Health Potion", 2);
        }

        public string GetName()
        {
            return playerName;
        }

        public Creatures GetActiveCreature()
        {
            return activeCreature;
        }

        public List<Creatures> GetCollection()
        {
            return collection;
        }

        // Inventory Methods

        public void ShowInventory()
        {
            Console.WriteLine($"\n--- {playerName}'s Inventory ---");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key}: x{item.Value}");
            }
        }

        // Method to check if item exist before adding to the Dictionary
        public void AddItem(string itemName, int amount)
        {
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += amount;
            }
            else
            {
                inventory.Add(itemName, amount);
            }
            Console.WriteLine($"Added {amount}x {itemName} to your bag.");
        }

        // Method to use an item
        public bool UseItem(string itemName)
        {
            if (inventory.ContainsKey(itemName) && inventory[itemName] > 0)
            {
                inventory[itemName]--;
                return true;
            }

            Console.WriteLine($"You don't have any {itemName}s left!");
            return false;
        }

        public void AddToCollection(Creatures newCreature)
        {
            collection.Add(newCreature);
        }

        public void ShowCollection()
        {
            Console.WriteLine($"\n--- {playerName}'s Creature Collection ---");
            for (int i = 0; i < collection.Count; i++)
            {
                // Access the name of the creature in the list
                Console.WriteLine($"{i + 1}. {collection[i].GetName()}");
            }
        }
    }
}