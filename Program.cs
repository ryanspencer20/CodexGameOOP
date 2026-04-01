/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * The game will feature a variety of creatures in inherited classes with different stats and abilities, as well as a storyline and progression system for players to follow.
 * The development is coded in C# and will utilize object-oriented programming principles to create classes, inheritance, and interfaces.
 * Error Handling: To ensure that players enter valid data and can proceed with the game without errors or issues.
 * The design is intended to be engaging and immersive, with a focus on player choice and interaction with battles and its creatures.
 * Main program to run the Codex Game and welcome the player, asking for their name and starting the game.
*/
using System;
namespace CodexGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Introduction(); // Call the Introduction method to start the game and allow the player to choose their starting creature.    
            // TO DO: Add a loop to allow the player to continue playing and exploring the world, capturing  
            // and battling new creatures. This will involve creating additional methods for different game actions and interactions.
        }
        // Introduction method to welcome the player and start the game by allowing them to choose their starting creature.
        static void Introduction() // Intro Method & Creature Objects written by Ryan Spencer
        {
            bool validInput = false; // Valid input flag to control the input validation loops, which will ensure that the player enters valid data and can proceed with the game without errors or issues.
            string playerName = ""; // Placeholder for the player's name outside of the input loop, which will be used to personalize the game experience and allow the player to connect with their character and the world of the Codex Game.
            Console.WriteLine("Welcome to the Codex: Creature Capture Game!");
            while (!validInput)
            {   
                Console.Write("Please enter your name: ");
                playerName = Console.ReadLine();
                if (string.IsNullOrEmpty(playerName) || playerName.Length > 50) // Check if the input is empty or more than 50 characters, which would be invalid.
                {
                    Console.WriteLine("INVALID INPUT! name can't be empty or more than 50 characters.");
                    validInput = false; 
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write($"Is {playerName} correct? (Y/N): ");
                    string confirmation = Console.ReadLine();
                    if (!string.IsNullOrEmpty(confirmation) && confirmation.Length <= 3 && (confirmation.ToUpper() == "Y" || confirmation.ToUpper() == "YES")) // Nested Conditional to confirm the player's name, allowing them to re-enter if it is incorrect.
                    {
                        Console.WriteLine($"Hello, {playerName}! Let's start your adventure!");
                        validInput = true; // Valid input, exit the loop.
                    }
                    else
                    {
                        Console.WriteLine("Let's try again."); // Return to the beginning of the loop to allow the player to re-enter their name if they indicated it was incorrect.
                        validInput = false; // Reset validInput to false to continue the loop for re-entry of the player's name.
                    }
                }
            }
            validInput = false; // Reset validInput for the next input validation loop.
            // TO DO: Add name to player new player object, which will allow the game to track the player's name and display it in various interactions and messages throughout the game, enhancing the player's immersion and connection to their character.
            // TO DO: Add narrative introducing the world and the player's role as a creature trainer, which will set the stage for the adventure and provide context for the player's journey.
            Console.WriteLine($"Please select a creature to start your adventure:");
            Console.WriteLine("1. Scorchlyn - Fire Type");
            Console.WriteLine("2. Swirlyfin - Water Type");
            Console.WriteLine("3. Tarkyuss - Earth Type");
            while (!validInput)
            {            
            Console.Write("Enter the number corresponding to your choice: ");
            string choice = Console.ReadLine();
            switch (choice) // Player Menu options to select their starting creature, which will display the creature's stats and description.
            {
                case "1":
                    Scorchlyn scorchlynStarter = new Scorchlyn(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                    Console.WriteLine($"You have chosen {scorchlynStarter.GetType().Name}!");
                    scorchlynStarter.CreatureStats();
                    scorchlynStarter.CreatureDescription();
                    // TO DO: Update player class to allow the player to capture the creature and add it to their collection, which will involve updating the isCaptured property and allowing the player to view their captured creatures.
                    validInput = true;
                    break;
                case "2":
                    Swirlyfin swirlyfinStarter = new Swirlyfin(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                    Console.WriteLine($"You have chosen {swirlyfinStarter.GetType().Name}!");
                     swirlyfinStarter.CreatureStats();
                    swirlyfinStarter.CreatureDescription();
                    // TO DO: Update player class to allow the player to capture the creature and add it to their collection, which will involve updating the isCaptured property and allowing the player to view their captured creatures.
                    validInput = true;
                    break;
                case "3":
                    Tarkyuss tarkyussStarter = new Tarkyuss(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                    Console.WriteLine($"You have chosen {tarkyussStarter.GetType().Name}!");
                    tarkyussStarter.CreatureStats();
                    tarkyussStarter.CreatureDescription();
                    // TO DO: Update player class to allow the player to capture the creature and add it to their collection, which will involve updating the isCaptured property and allowing the player to view their captured creatures.
                    validInput = true;
                    break;
                default:
                    Console.WriteLine("INVALID INPUT! Please re-enter and select a valid choice.");
                    validInput = false;
                    break; // Check if the input is valid (1, 2, or 3), otherwise loop display an error message and prompt the player to re-enter their choice.
            }
        }
            Console.WriteLine("");
            Console.WriteLine($"Congratulations {playerName} on choosing your first creature! Your adventure begins now. Explore the world, capture new creatures, and become a legendary trainer!");
        }
    }
}
