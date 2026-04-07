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
            bool gameplay = true; // Gameplay flag to control the main game loop, which will allow the player to continue playing and exploring the world, capturing and battling new creatures until they choose to exit the game.
            // Create some initial creatures for the player to encounter and capture, which will provide variety in the creatures that players can encounter and capture, enhancing the gameplay experience and encouraging exploration of the game world.
            Creatures ashHoof = new Creatures("Ash-Hoof", 100, 1, CreatureType.Fire);  
            ashHoof.AddAttack("Flaming Charge", 25);
            ashHoof.AddDefense("Ashen Guard", 5);         
            Creatures thorntail = new Creatures("Thorn-Tail", 100, 1, CreatureType.Earth);           
            thorntail.AddAttack("Spike Strike", 20);
            thorntail.AddDefense("Thorn Shield", 15);
            Creatures coralslash = new Creatures("Coral-Slash", 100, 1, CreatureType.Water);          
            coralslash.AddAttack("Tidal Slash", 30);
            coralslash.AddDefense("Water Guard", 10);
            Creatures zephyrwing = new Creatures("Zephyr-Wing", 100, 1, CreatureType.Wind);
            zephyrwing.AddAttack("Gust", 20);
            zephyrwing.AddDefense("Air Barrier", 10);

            // Make array for wild creature encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture, enhancing the gameplay experience and encouraging exploration of the game world.
            Creatures[] wildEncounters = new Creatures[] { ashHoof, zephyrwing, thorntail, coralslash };

            Creatures playerStarter = Introduction(); // Call the Introduction method to start the game and allow the player to choose their starting creature.  
            
            // TO DO: Add a MENU loop to allow the player to continue playing and exploring the world, capturing 
            while (gameplay) {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Search for a new creature");
                Console.WriteLine("2. View your creature collection");
                Console.WriteLine("3. Exit Game");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("You venture into the wilds in search of new creatures...");
                        Creatures encounteredCreature = RandomEncounter(wildEncounters); // Generate a random encounter with a wild creature from the array of encounters.            
                        BattleTracker creatureBattle = new BattleTracker(playerStarter, encounteredCreature); // Create an instance of the BattleTracker class to track the player's battles and progress, which will allow for a more engaging and immersive gameplay experience as players can see their progress and achievements in the game.
                        creatureBattle.RunBattleLoop(); // Call the RunBattleLoop method to start the battle between the player's creature and the encountered creature, which will allow players to engage in battles and test their strategies and abilities against different creatures in the game.
                        // and battling new creatures. This will involve creating additional methods for different game actions and interactions.
                        break;
                    case "2":
                        Console.WriteLine("Your Creature Collection:");
                        playerStarter.CreatureStats(); // Display the player's starter creature's stats, which will allow the player to view their captured creatures and their attributes, enhancing their connection to their creatures and providing information for battles and interactions.
                        break;
                    case "3":
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
        static Creatures Introduction() // Intro Method & Creature Objects written by Ryan Spencer
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
                        scorchlynStarter.AddAttack("Exhaust Engulf", 20);
                        scorchlynStarter.AddAttack("Flamed Tail", 30);
                        scorchlynStarter.AddDefense("Fire Guard", 10);
                        Console.WriteLine($"You have chosen {scorchlynStarter.GetType().Name}!");
                        scorchlynStarter.CreatureStats();
                        scorchlynStarter.CreatureDescription();
                        scorchlynStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = scorchlynStarter; // Return the selected Scorchlyn to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "2":
                        Swirlyfin swirlyfinStarter = new Swirlyfin(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        swirlyfinStarter.AddAttack("Whirlpool", 30);
                        swirlyfinStarter.AddDefense("Agility", 15);
                        swirlyfinStarter.AddDefense("Fin Array", 20);
                        Console.WriteLine($"You have chosen {swirlyfinStarter.GetType().Name}!");
                        swirlyfinStarter.CreatureStats();
                        swirlyfinStarter.CreatureDescription();
                        swirlyfinStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = swirlyfinStarter; // Return the selected Swirlyfin to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "3":
                        Tarkyuss tarkyussStarter = new Tarkyuss(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        tarkyussStarter.AddAttack("Claw Strike", 15);
                        tarkyussStarter.AddAttack("Rolling Spikes", 35);
                        tarkyussStarter.AddDefense("Shell Shield", 10);
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
            return starterChoice; // Return the selected creature to be used as the player's starter creature in the game.
        }
        static Creatures RandomEncounter(Creatures[] encounters) // Method to generate a random encounter with a wild creature from the specified array of encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture.
        {
            Random index = new Random(); // Create a new instance of the Random class to generate random numbers, which will be used to select a random creature from the array of encounters.
            int encounter = index.Next(encounters.Length); // Generate a random index within the bounds of the encounters array, which will be used to select a random creature from the array.
            return encounters[encounter]; // Return the randomly selected creature from the array of encounters.
        }
    }
}
