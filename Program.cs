/*
    IOT1026 - Object-Oriented Programming - Final Project
    Ryan Spencer - Dylan Brost
 * Codex: Creature Capture Game - A creature capture game where players can search, capture and battle other creatures. 
 * The game will feature a variety of creatures in inherited classes with different stats and abilities, as well as a storyline and progression system for players to follow.
 * The development is coded in C# and will utilize object-oriented programming principles to create classes, inheritance, and interfaces.
 * Error Handling: To ensure that players enter valid data and can proceed with the game without errors or issues.
 * The design is intended to be engaging and immersive, with a focus on player choice and interaction with battles and its creatures.
 * Main program to run the Codex Game and welcome the player, asking for their name and starting creature.
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
            Console.Title = "Codex: Creature Capture Game"; // Set the console title to the name of the game, which will enhance the branding and presentation of the game and create a more immersive experience for the player.
            bool gameplay = true; // Gameplay flag to control the main game loop, which will allow the player to continue playing and exploring the world, capturing and battling new creatures until they choose to exit the game.                 
            Console.Clear(); // Clear the console to start the main game loop with a clean interface after the introduction and starter selection process, which will enhance the player's immersion and focus on the gameplay experience.
            // Make array for wild creature encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture, enhancing the gameplay experience and encouraging exploration of the game world.
            Creatures[] wildEncounters = new Creatures[] { new AshHoof(100, 1), new Coralslash(100, 1), new Thorntail(100, 1), new Zephyrwing(100, 1), new ElderSeedra(100, 1), new SeaCucumbra(100, 1), new SniffleBurn(100, 1) };

            Player myPlayer = Introduction(); // Call the Introduction method to start the game and allow the player to choose their starting creature.  
            
            // MENU loop to allow the player to continue playing and exploring the world and capturing new creatures until they choose to exit the game.
            while (gameplay) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t==Belisle Island=="); // Main menu for the player to choose their next action, which will allow them to explore the world, view their creature collection, and interact with different game features and mechanics.
                Console.WriteLine("1. Search for a new creature");      // Option to search for a new creature, this will generate a random encounter from the array of wild creatures.
                Console.WriteLine("2. View your creature");             // Option to view the player's active creature and stats, which will allow the player to view their captured creatures and their attributes, enhancing their connection to their creatures and providing information for battles and interactions.
                Console.WriteLine("3. Rotate Active Creature");         // Rotate active Creature option for the player
                Console.WriteLine("4. Visit the Belisle Island Clinic");// Option to visit the clinic to heal the player's active creature, which will allow the player to maintain their creatures' health and continue exploring and battling in the game world.
                Console.WriteLine("5. Exit Game"); // Option to exit the game, which will allow the player to end their adventure and return to the main menu or desktop, providing a clear and satisfying conclusion to their gameplay experience.
                Console.Write($"{myPlayer.GetName()}:\t-What should I do?-\nChoose a number from the menu: ");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Random rand = new Random();
                        int SearchChance = rand.Next(0, 101); // Random number generator to determine if a creature is found during the search, which will add an element of chance and excitement to the gameplay experience as players explore the world and search for new creatures.
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{myPlayer.GetName()}:\t-It's time to venture into the wilds in search of new creatures...-");
                        NarrativePause();
                        if (SearchChance <= 90) // 90% chance to find a creature, which will provide a balanced gameplay experience where players have a good chance of finding creatures while still maintaining an element of challenge and unpredictability in their search for new creatures.
                        {
                            Creatures encounteredCreature = RandomEncounter(wildEncounters); // Generate a random encounter with a wild creature from the array of encounters.
                            encounteredCreature.SetHealth(100); // resets the encounted creatures health to full to ensure a fresh next encounter with it
                            BattleTracker creatureBattle = new BattleTracker(myPlayer.GetActiveCreature(), encounteredCreature); // Create an instance of the BattleTracker class to track the player's battles and progress, which will allow for a more engaging and immersive gameplay experience as players can see their progress and achievements in the game.
                            creatureBattle.RunBattleLoop();
                            // Call the RunBattleLoop method to start the battle between the player's creature and the encountered creature, which will allow players to engage in battles and test their strategies and abilities against different creatures in the game.
                            // and battling new creatures. This will involve creating additional methods for different game actions and interactions.

                            // Handles the end results of the battle, if the creature is defeated rewards you a health potion and option to use one to continue fighting
                            // also prompts the player if they beat the creature and want to capture it
                            if (encounteredCreature.GetHealth() <= 0)
                            {
                                Console.WriteLine($"\nVictory! You found a Health Potion on the ground.");
                                myPlayer.AddItem("Health Potion", 1); // A reward of a health potion to keep going

                                Console.WriteLine($"\nThe {encounteredCreature.GetName()} fainted! Attempt capture? (Y/N)");
                                string input = Console.ReadLine().ToUpper();
                                if (input.ToUpper() == "Y" || input.ToUpper() == "YES")
                                {
                                    myPlayer.CaptureCreature(encounteredCreature);
                                    Console.WriteLine($"You successfully captured the {encounteredCreature.GetName()}!");
                                    NarrativePause();
                                }
                                else
                                {
                                    Console.WriteLine("You decided not to capture the creature and continue on your adventure.");
                                    NarrativePause();
                                }
                                Console.WriteLine("\nWould you like to use a Health Potion to fully heal your creature? (Y/N)");
                                string healInput = Console.ReadLine().ToUpper();
                                if (healInput.ToUpper() == "Y" || healInput.ToUpper() == "YES")
                                {
                                    myPlayer.HealActiveCreature();
                                    Console.WriteLine($"{myPlayer.GetName()} used a Health Potion!");
                                    Console.WriteLine($"{myPlayer.GetActiveCreature().GetType().Name} is fully healed!");
                                    NarrativePause();
                                }
                            }                     
                            else
                            {
                                Console.WriteLine($"{myPlayer.GetName()}:\t -UGH! OH NO! I lost the battle to that {encounteredCreature.GetName()}...-");
                                NarrativePause();
                                Console.WriteLine($"{myPlayer.GetName()}:\t -I need to heal up {myPlayer.GetActiveCreature().GetType().Name} at the Clinic...-");
                                NarrativePause();
                            }
                        }
                        else
                        {
                            Console.WriteLine("...3 hours later...");
                            NarrativePause();
                            Console.WriteLine($"{myPlayer.GetName()}:\t -UGH! It's been hours and no creatures found! I need a break...-");
                            NarrativePause();
                        }
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine($"{myPlayer.GetName()}:\t-Let's take a look at {myPlayer.GetActiveCreature().GetType().Name} for its stats!-");
                        Console.WriteLine("---------------------------------------------");
                        myPlayer.GetActiveCreature().CreatureStats(); // Display the player's active creature and stats, which will allow the player to view their captured creatures and their attributes, enhancing their connection to their creatures and providing information for battles and interactions.
                        myPlayer.GetActiveCreature().CreatureDescription(); // Display the player's active creature's description.
                        Console.WriteLine("");
                        Console.WriteLine($"{myPlayer.GetName()}:\t-Let's also check my inventory for items!-");
                        Console.WriteLine("---------------------------------------------");
                        myPlayer.ShowInventory();  
                        Console.WriteLine("---------------------------------------------");
                        NarrativePause();
                        Console.ResetColor ();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (myPlayer.GetCollection().Count <= 1) // Check if the player has more than one creature in their collection before allowing them to rotate their active creature, which will ensure that the player has a valid selection of creatures to choose from and prevent errors or issues with rotating an active creature when there are no other creatures available.
                        {
                            Console.WriteLine("You don't have any creatures in your collection to rotate! Capture some creatures first!");
                            NarrativePause();
                        }
                        else
                        {
                            Console.WriteLine($"{myPlayer.GetName()}:\t -I should give {myPlayer.GetActiveCreature().GetType().Name} a break, let me switch for another one in my collection!-");
                            myPlayer.RotateActiveCreature(); // Calls the new rotation method
                            NarrativePause();
                        }
                        Console.ResetColor();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        if (myPlayer.GetActiveCreature().GetHealth() >= 100) // Check if the player's active creature is already at full health before allowing them to visit the clinic, which will prevent unnecessary visits to the clinic and encourage players to manage their creatures' health effectively.
                        {
                            Console.WriteLine($"{myPlayer.GetName()}:\t -My {myPlayer.GetActiveCreature().GetType().Name} is already at full health! I don't need to visit the clinic right now!-");
                            NarrativePause();
                        }
                        else
                        {
                            Console.WriteLine($"{myPlayer.GetName()}:\t -I should take {myPlayer.GetActiveCreature().GetType().Name} to the clinic to get healed!-");
                            ClinicVisit(myPlayer.GetActiveCreature(), myPlayer);
                        }
                        Console.ResetColor();
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Thank you for playing the Codex: Creature Capture Game! Goodbye!");
                        NarrativePause();
                        gameplay = false; // Set gameplay to false to exit the main game loop and end the game.
                        continue; // Skip the rest of the loop and exit immediately after displaying the exit message.
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("INVALID INPUT! Please select a valid option from the menu.");
                        Console.ResetColor();
                        continue; // Invalid input, return to the beginning of the loop to display the menu again.
                    
                }
                Console.Clear(); // Clear the console to start the main game loop with a clean interface after the introduction and starter selection process, which will enhance the player's immersion and focus on the gameplay experience.
            }
        }
        // Introduction method to welcome the player and start the game by allowing them to choose their starting creature.
        static Player Introduction() // Intro Method & Creature Objects written by Ryan Spencer
        {
            Creatures starterChoice = null; // Placeholder for the player's starter creature, which will be assigned based on the player's choice and used as their initial creature in the game.
            bool validInput = false; // Valid input flag to control the input validation loops, which will ensure that the player enters valid data and can proceed with the game without errors or issues.
            string playerName = ""; // Placeholder for the player's name outside of the input loop, which will be used to personalize the game experience and allow the player to connect with their character and the world of the Codex Game.
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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
            NarrativePause();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Narrative introducing the world and the player's role as a creature trainer, which will set the stage for the adventure and provide context for the player's journey.
            Console.WriteLine($"Welcome to the land of Belisle Island, {playerName}! A land filled with mysterious creatures and endless adventures.\nAs a new trainer, you have the opportunity to explore this vibrant world, capture unique creatures, and become a legendary trainer.\nYour journey begins now, and the choices you make will shape your adventure.\nAre you ready to embark on this exciting journey?");
            NarrativePause();
            Console.WriteLine("...?");
            NarrativePause();
            Console.WriteLine("?: \t-ADVENTURER! PLEASE WAIT! OH...I need to get out and excerise more...-");
            NarrativePause();
            Console.WriteLine("Craig:\t-My name is Craig! I am the guide for new trainers.-");
            NarrativePause();
            Console.WriteLine("Craig:\t-What's your name, adventurer?-");
            NarrativePause();
            Console.WriteLine($"{playerName}:\t-Hi my name is {playerName}! -");
            NarrativePause();
            Console.WriteLine($"Craig:\t-It's a pleasure to meet you, {playerName}!-");
            NarrativePause();
            Console.WriteLine($"Craig:\t-Please come with me and I will help you get started on your adventure.-");
            NarrativePause();
            Console.WriteLine("...");
            NarrativePause();
            Console.WriteLine($"{playerName}:\t-Where are we?-");
            NarrativePause();
            Console.WriteLine("Craig:\t-This is my research lab where I study the creatures of Belisle Island!-");
            NarrativePause();
            Console.WriteLine("Craig:\t-I will help you get started on your adventure and teach you how to capture creatures.-");
            NarrativePause();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Craig:\t-First, let's choose your starting creature!-");
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
                        Console.WriteLine($"{playerName}:\t-I will choose {scorchlynStarter.GetType().Name}!-");
                        NarrativePause();
                        scorchlynStarter.CreatureStats();
                        scorchlynStarter.CreatureDescription();
                        scorchlynStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = scorchlynStarter; // Return the selected Scorchlyn to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "2":
                        Swirlyfin swirlyfinStarter = new Swirlyfin(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        Console.WriteLine($"{playerName}:\t-I will choose {swirlyfinStarter.GetType().Name}!-");
                        NarrativePause();
                        swirlyfinStarter.CreatureStats();
                        swirlyfinStarter.CreatureDescription();
                        swirlyfinStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = swirlyfinStarter; // Return the selected Swirlyfin to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    case "3":
                        Tarkyuss tarkyussStarter = new Tarkyuss(100, 1); // Starting stats for healthy creature at level 1, which will be used as the base stats for all creatures in the game and can be modified as the player captures and levels up their creatures.
                        Console.WriteLine($"{playerName}:\t-I will choose {tarkyussStarter.GetType().Name}!-");
                        NarrativePause();
                        tarkyussStarter.CreatureStats();
                        tarkyussStarter.CreatureDescription();
                        tarkyussStarter.Capture(); // Capture the creature immediately upon selection, which will update the isCaptured property and allow the player to view their captured creatures in their collection.
                        starterChoice = tarkyussStarter; // Return the selected Tarkyuss to be used as the player's starter creature in the game.
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Craig:\t-Oh sorry must be my old hearing, I didn't hear what you said, can you please repeat that?-");
                        validInput = false;
                        break; // Check if the input is valid (1, 2, or 3), otherwise loop display an error message and prompt the player to re-enter their choice.
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            NarrativePause();
            Console.WriteLine($"Congratulations {playerName} on choosing your first creature! Your adventure begins now. Explore the world, capture new creatures, and become a legendary trainer!");
            Player playerChar = new Player(playerName, starterChoice); // Return the selected creature to be used as the player's starter creature in the game.
            Console.WriteLine("");
            NarrativePause();
            Console.WriteLine("Craig:\t-AHA! A valid choice!-");
            NarrativePause();
            Console.WriteLine($"Craig:\t-{starterChoice.GetType().Name} will serve you well!-");
            NarrativePause();
            Console.WriteLine("Craig:\t-Your journey as a creature trainer begins now!-");
            NarrativePause();
            Console.WriteLine("Craig:\t-Remember, each creature has its own unique stats and abilities, so choose wisely and strategize your battles!-");
            NarrativePause();
            Console.Clear(); // Clear the console to start the main game loop with a clean interface after the introduction and starter selection process, which will enhance the player's immersion and focus on the gameplay experience.
            return playerChar;
        }
        static Creatures RandomEncounter(Creatures[] encounters) // Method to generate a random encounter with a wild creature from the specified array of encounters, which will allow for dynamic generation of encounters and provide variety in the creatures that players can encounter and capture.
        {
            Random index = new Random(); // Create a new instance of the Random class to generate random numbers, which will be used to select a random creature from the array of encounters.
            int encounter = index.Next(encounters.Length); // Generate a random index within the bounds of the encounters array, which will be used to select a random creature from the array.
            return encounters[encounter]; // Return the randomly selected creature from the array of encounters.
        }

        static void ClinicVisit(Creatures activeCreature, Player playerName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            bool menuFlag = true;
            Console.WriteLine("You visit the Clinic on Belisle island!");
            NarrativePause();
            Console.WriteLine("A nurse sees you and walks over to greet you.");
            NarrativePause();
            Console.WriteLine("Jessica:\t-HI! Welcome to Belisle Island Clinic! my name is Nurse Jessica-");
            NarrativePause();
            Console.WriteLine("Jessica:\t-How may I help you today?-");
            NarrativePause();
            while (menuFlag)
            {
                Console.WriteLine("");
                Console.WriteLine("1. Heal my Creature");
                Console.WriteLine("2. Exit the Clinic");
                Console.Write("Please select a number from the menu: ");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine($"{playerName.GetName()}:\t-Please help heal my {activeCreature.GetName()}! They've been through a lot!-");
                        NarrativePause();
                        Console.WriteLine($"Jessica:\t-Come right this way {playerName.GetName()}...we will treat your creature back to health!-");
                        NarrativePause();
                        Console.WriteLine($"The nurse takes {activeCreature.GetName()} and treats them back to full health!");
                        activeCreature.UpdateHealth(100);
                        Console.WriteLine($"Your {activeCreature.GetName()} is at full health!");
                        NarrativePause();
                        Console.WriteLine("Jessica:\t-You're welcome anytime, have a nice day!-");
                        NarrativePause();
                        menuFlag = false;
                        break;
                    case "2":
                        Console.WriteLine("Jessica:\t-You're welcome anytime, have a nice day!-");
                        NarrativePause();
                        menuFlag = false;
                        break;
                    default:
                        Console.WriteLine("Jessica:\t-Sorry I didn't quite get that, can you please repeat your request?");
                        NarrativePause();
                        menuFlag = true;
                        break;
                }
            }
            Console.ResetColor();
        }
        static void NarrativePause() // Method to create a pause in the narrative, allowing the player to read and absorb the story and dialogue before proceeding, which will enhance the storytelling aspect of the game and create a more immersive experience for the player.
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo(); // Create a variable to store the key information when the player presses a key, which will be used to detect when the player is ready to continue with the narrative and allow them to control the pacing of the story.
            Console.WriteLine("\nPress enter to continue...");
            while (keyInfo.Key != ConsoleKey.Enter) // Loop to wait for the player to press a key before continuing, which will allow the player to control the pacing of the narrative and ensure they have time to read and understand the story and dialogue.
            {
                System.Threading.Thread.Sleep(100); // Sleep for a short duration to prevent excessive CPU usage while waiting for input, which will improve the performance of the game and create a smoother experience for the player.
                keyInfo = Console.ReadKey(true); // Update the keyInfo variable with the new key press
            }
            int currentLine = Console.CursorTop - 1; // Get the current line of the console cursor, which will be used to clear the "Press enter to continue..." message from the console after the player presses enter, creating a cleaner and more polished user interface.
            Console.SetCursorPosition(0, currentLine);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }
    }
}
