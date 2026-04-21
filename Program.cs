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
using System.Runtime.CompilerServices;
using System.Security;
namespace CodexGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameplay = true; // Gameplay flag to control the main game loop, which will allow the player to continue playing and exploring the world, capturing and battling new creatures until they choose to exit the game.                 

            // Make array for wild creature encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture, enhancing the gameplay experience and encouraging exploration of the game world.
            Creatures[] wildEncounters = new Creatures[] { new AshHoof(100, 1), new Coralslash(100, 1), new Thorntail(100, 1), new Zephyrwing(100, 1) };

            Player playerChar = Introduction(); // Call the Introduction method to start the game and allow the player to choose their starting creature.  
            Creatures playerStarter = playerChar.GetActiveCreature(); // Getting the Player Character Active Creature.
            
            // TO DO: Add a MENU loop to allow the player to continue playing and exploring the world, capturing 
            while (gameplay) {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Search for a new creature");
                Console.WriteLine("2. View your creature");
                Console.WriteLine("3. Rotate Active Creature");         // Added Rotate active Creature option for the player
                Console.WriteLine("4. Visit the Belisle Island Clinic");
                Console.WriteLine("5. Exit Game");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine($"{playerChar.GetName()} venture into the wilds in search of new creatures...");
                        Creatures encounteredCreature = RandomEncounter(wildEncounters); // Generate a random encounter with a wild creature from the array of encounters.
                        encounteredCreature.SetHealth(100); // resets the encounted creatures health to full to ensure a fresh next encounter with it
                        BattleTracker creatureBattle = new BattleTracker(playerChar.GetActiveCreature(), encounteredCreature); // Create an instance of the BattleTracker class to track the player's battles and progress, which will allow for a more engaging and immersive gameplay experience as players can see their progress and achievements in the game.
                        creatureBattle.RunBattleLoop();
                        // Call the RunBattleLoop method to start the battle between the player's creature and the encountered creature, which will allow players to engage in battles and test their strategies and abilities against different creatures in the game.
                        // and battling new creatures. This will involve creating additional methods for different game actions and interactions.

                        // Handles the end results of the battle, if the creature is defeated rewards you a health potion and option to use one to continue fighting
                        // also prompts the player if they beat the creature and want to capture it
                        if (encounteredCreature.GetHealth() <= 0)
                        {
                            Console.WriteLine($"\nVictory! You found a Health Potion on the ground.");
                            playerChar.AddItem("Health Potion", 1); // A reward of a health potion to keep going

                            Console.WriteLine($"\nThe {encounteredCreature.GetName()} fainted! Attempt capture? (Y/N)");
                            string input = Console.ReadLine().ToUpper();

                            if (input == "Y" || input == "YES")
                            {
                                playerChar.CaptureCreature(encounteredCreature);
                            }

                            Console.WriteLine("\nWould you like to use a Health Potion to fully heal your creature? (Y/N)");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                playerChar.HealActiveCreature();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You lost and retreated from battle.....");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Your Creature Collection:");
                        playerChar.GetActiveCreature().CreatureStats(); // Display the player's active creature and stats, which will allow the player to view their captured creatures and their attributes, enhancing their connection to their creatures and providing information for battles and interactions.
                        playerChar.ShowInventory();  
                        break;
                    case "3":
                        playerChar.RotateActiveCreature(); // Calls the new rotation method
                        break;
                    case "4":
                            ClinicVisit(playerChar.GetActiveCreature(), playerChar);
                        break;
                    case "5":
                        Console.WriteLine("Thank you for playing the Codex: Creature Capture Game! Goodbye!");
                        gameplay = false; // Set gameplay to false to exit the main game loop and end the game.
                        continue; // Skip the rest of the loop and exit immediately after displaying the exit message.
                    default:
                        Console.WriteLine("INVALID INPUT! Please select a valid option from the menu.");
                        continue; // Invalid input, return to the beginning of the loop to display the menu again.
                }
            }
        }
        // Introduction method to welcome the player and start the game by allowing them to choose their starting creature.
        static Player Introduction() // Intro Method & Creature Objects written by Ryan Spencer
        {
            Creatures starterChoice = null; // Placeholder for the player's starter creature, which will be assigned based on the player's choice and used as their initial creature in the game.
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
                        scorchlynStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = scorchlynStarter; // Return the selected Scorchlyn to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "2":
                        Swirlyfin swirlyfinStarter = new Swirlyfin(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        Console.WriteLine($"You have chosen {swirlyfinStarter.GetType().Name}!");
                        swirlyfinStarter.CreatureStats();
                        swirlyfinStarter.CreatureDescription();
                        swirlyfinStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = swirlyfinStarter; // Return the selected Swirlyfin to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "3":
                        Tarkyuss tarkyussStarter = new Tarkyuss(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        Console.WriteLine($"You have chosen {tarkyussStarter.GetType().Name}!");
                        tarkyussStarter.CreatureStats();
                        tarkyussStarter.CreatureDescription();
                        tarkyussStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = tarkyussStarter; // Return the selected Tarkyuss to be used as the player's starter creature in the game.
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
            Player playerChar = new Player(playerName, starterChoice); // Return the selected creature to be used as the player's starter creature in the game.
            return playerChar;
        }
        static Creatures RandomEncounter(Creatures[] encounters) // Method to generate a random encounter with a wild creature from the specified array of encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture.
        {
            Random index = new Random(); // Create a new instance of the Random class to generate random numbers, which will be used to select a random creature from the array of encounters.
            int encounter = index.Next(encounters.Length); // Generate a random index within the bounds of the encounters array, which will be used to select a random creature from the array.
            return encounters[encounter]; // Return the randomly selected creature from the array of encounters.
        }

        static void ClinicVisit(Creatures activeCreature, Player name)
        {
            Console.WriteLine("You visit the Clinic on Belisle island!");
            Console.WriteLine("A nurse joins greets you.");
            Console.WriteLine("Welcome to Belisle Island Clinic!");
            Console.WriteLine("How may I help you?");
            Console.WriteLine("");
            Console.WriteLine("1. Heal my Creature");
            Console.WriteLine("2. Exit the Clinic");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    Console.WriteLine($"Come right this way {name.GetName()}...we will treat your creature back to health!");
                    Console.WriteLine($"The nurse takes {activeCreature.GetName()} and treats them back to full health!");
                    activeCreature.UpdateHealth(100);
                    Console.WriteLine($"Your {activeCreature.GetName()} is at full health!");
                    Console.WriteLine("Your welcome anytime, have a nice day!");
                    break;
                case "2":
                    Console.WriteLine("Your welcome anytime, have a nice day!");
                    break;
                default:
                    Console.WriteLine("The nurse didn't understand your request...");
                    break;
            }
        }
    }
}
