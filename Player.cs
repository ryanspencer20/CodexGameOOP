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
        // Checks Soul Ball count before proceeding with capture and
        // enforces a cap on the creature collection to maintain balance.
        public void CaptureCreature(Creatures wildCreature)
        {
            // Verify item exists and is used
            if (UseItem("Soul Ball"))
            {
                Console.WriteLine($"You throw a Soul Ball at the defeated wild {wildCreature.GetName()}...");

                // Checks to see if the player cap of 4 is reached or room to add another
                if (collection.Count < 4)
                {
                    collection.Add(wildCreature);
                    Console.WriteLine($"The {wildCreature.GetName()} was added to your collection.");
                }
                else
                {
                    Console.WriteLine("Your deck is full! You can only hold 4 creatures.");
                }
            }
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
        public void HealActiveCreature()
        {
            // Checks potion availability in inventory before resetting active creature's health
            if (UseItem("Health Potion"))
            {
                activeCreature.SetHealth(100);
                Console.WriteLine($"{activeCreature.GetName()} has been fully healed to 100 HP!");
            }
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
        // Prompts the player to select a new active creature from their collection
        // and checks that the input is a valid number within the list range.
        public void RotateActiveCreature()
        {
            ShowCollection();
            Console.Write("Enter the number of your captured creatures you want to make active: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= collection.Count)
            {
                activeCreature = collection[choice - 1];
                Console.WriteLine($"{activeCreature.GetName()} is now your active creature!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}