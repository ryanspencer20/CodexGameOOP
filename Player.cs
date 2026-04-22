using System;
using System.Collections.Generic;

namespace CodexGame
{
    internal class Player
    {
        private string playerName; // The player's name
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
            bool replaceFlag = true; // Flag to control the replacement loop
            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                    Console.WriteLine("Your collection is full! You can only hold 4 creatures.");
                    Console.WriteLine("Would you like to replace a creature in your collection? (Y/N)");
                    string input = Console.ReadLine().Trim().ToUpper();
                    Console.Write("Your answer: ");
                    while (replaceFlag) // Loop to handle replacement decision and input validation
                    {
                        if (input == "Y" || input == "YES") // If the player chooses to replace, show collection and prompt for selection
                        {
                            ShowCollection();
                            Console.Write("Enter the number of the creature you want to replace: ");
                            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= collection.Count)
                            { // Validate the player's choice and perform the replacement
                                Console.WriteLine($"You released {collection[choice - 1].GetName()} and added {wildCreature.GetName()} to your collection.");
                                collection[choice - 1] = wildCreature; // Replace the selected creature with the new one
                                replaceFlag = false; // Exit the replacement loop
                            }
                            else // Handle invalid input for replacement selection
                            {
                                Console.WriteLine("Invalid choice. The new creature was not added to your collection.");
                                replaceFlag = true; // Loop the replacement loop on invalid input
                            }
                        }                    
                        else // If the player chooses not to replace, exit the replacement loop and do not add the new creature
                        {
                            Console.WriteLine($"You decided not to capture the {wildCreature.GetName()}.");
                            replaceFlag = false; // Exit the replacement loop
                        }
                        
                    }
                }
            }
        }

        public string GetName() // This method is used to access the player's name for display and reference in other classes.
        {
            return playerName;
        }

        public Creatures GetActiveCreature() // This method is used to access the active creature for battles and reference in other classes.
        {
            return activeCreature;
        }

        public List<Creatures> GetCollection() // This method is used to access the player's collection for display and reference in other classes.
        {
            return collection;
        }

        // Inventory Methods

        public void ShowInventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n--- {playerName}'s Inventory ---");
            foreach (var item in inventory) // Loop through the inventory Dictionary and display each item and its quantity.
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
            Console.ForegroundColor = ConsoleColor.Green;
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"You don't have any {itemName}s left!");
            return false;
        }

        public void HealActiveCreature()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            // Checks potion availability in inventory before resetting active creature's health
            if (UseItem("Health Potion"))
            {
                activeCreature.SetHealth(100);
                Console.WriteLine($"{activeCreature.GetName()} has been fully healed to 100 HP!");
            }
        }

        public void AddToCollection(Creatures newCreature) // This method is used to add a new creature to the player's collection.
        {
            collection.Add(newCreature);
        }

        // This method is used to display collection when rotating active creature and for general reference.
        public void ShowCollection() 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n--- {playerName}'s Creature Collection ---");
            for (int i = 0; i < collection.Count; i++) // Loop through the collection and display each creature with a number.
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter the number of your captured creatures you want to make active: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= collection.Count)
            {
                if (collection[choice - 1] == activeCreature) // Check if the selected creature is already active.
                {
                    Console.WriteLine($"{activeCreature.GetName()} is already your active creature!");
                    return; // Exit the method if the selected creature is already active.
                }
                else
                {
                    activeCreature = collection[choice - 1]; // Set the active creature based on the player's choice (adjusting for 0-based index)
                    Console.WriteLine($"{activeCreature.GetName()} is now your active creature!");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}