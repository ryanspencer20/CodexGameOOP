using System;
using System.Collections.Generic;
using System.Linq;
/*
    * This file defines the BattleTracker class for the Codex Game.
    * The BattleTracker class manages the turn-based battle system between the player's active creature and a wild enemy creature.
    * It includes methods for running the battle loop, handling player and enemy turns, determining battle outcomes, and implementing combat mechanics such as evasion and accuracy.
*/
namespace CodexGame
{
    internal class BattleTracker // The BattleTracker class manages the turn-based battle system between the player's active creature and a wild enemy creature.
    {
        private int TurnOrder = 0; // 0 = Player, 1 = Enemy
        private int TurnTracker = 1; // Display the current round of battle, starting at 1 for player turn
        private Creatures playerCreature; // The player's active creature in battle
        private Creatures enemyCreature; // The enemy creature in battle
        // Constructor for the BattleTracker class, which initializes the player's active creature, the enemy creature, and sets the turn order and turn tracker
        public BattleTracker(Creatures playerCreature, Creatures enemyCreature, int turnOrder = 0, int turnTracker = 1)
        {
            this.playerCreature = playerCreature;
            this.enemyCreature = enemyCreature;
            this.TurnOrder = turnOrder;
            this.TurnTracker = turnTracker;
        }

        public void RunBattleLoop() // Battle loop method that manages the flow of the battle.
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\nA wild {enemyCreature.GetName()} appeared!");
            Console.ResetColor();

            while (playerCreature.GetHealth() > 0 && enemyCreature.GetHealth() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n--- Round {TurnTracker} ---");

                if (TurnOrder == 0)
                {
                    PlayerTurn();
                    TurnOrder = 1;
                }
                else
                {
                    EnemyTurn();
                    TurnOrder = 0;
                    TurnTracker++;
                }
            }
            OutcomeMessage();
        }

        private void PlayerTurn() // Private method for player's turn logic, called in the RunBattleLoop method when it's the player's turn.
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine($"{playerCreature.GetName()} HP: {playerCreature.GetHealth()} | {enemyCreature.GetName()} HP: {enemyCreature.GetHealth()}");
                Console.WriteLine("What will you do? 1. Attack | 2. Defense");
                Console.Write("Enter number: ");
                string choice = Console.ReadLine();

                if (choice == "1") // Attack Logic
                {
                    // Get the list of attacks added for each creature
                    Dictionary<string, int> attacks = playerCreature.GetAttackMoves();

                    // Display the menu
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nChoose an attack:");
                    int i = 1;
                    foreach (var move in attacks)
                    {
                        Console.WriteLine($"{i}. {move.Key} ({move.Value} DMG)");
                        i++;
                    }
                    Console.ResetColor();

                    // Get player move selection
                    Console.Write("Enter number: ");
                    if (int.TryParse(Console.ReadLine(), out int moveNum) && moveNum > 0 && moveNum <= attacks.Count)
                    {                            
                        // Pull the move name based on the number chosen
                        string moveName = attacks.Keys.ElementAt(moveNum - 1);
                        int damage = attacks[moveName];

                        // Logic for random attack.
                        bool hasEvaded = CombatEvasion();
                        bool AttackHits = CombatAccuracy(damage);
                        if (hasEvaded == true) // If the enemy creature evades the attack
                        {
                            Console.WriteLine($"{enemyCreature.GetName()} dodged the attack!");
                            validChoice = true;
                        }
                        else if (AttackHits == false) // If the attack misses based on accuracy
                        {
                            Console.WriteLine($"{playerCreature.GetName()}'s attack missed!");
                            validChoice = true;
                        }
                        else // Attack hits and damage is applied to enemy creature
                        {
                            enemyCreature.UpdateHealth(-damage);
                            Console.WriteLine($"\n{playerCreature.GetName()} used {moveName} for {damage} damage!");
                            validChoice = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move selection!");
                    }
                }
                else if (choice == "2") // Defense Logic
                {
                    // Get the list of defenses added for each creature
                    Dictionary<string, int> defenses = playerCreature.GetDefenseMoves();

                    // Display the menu
                    Console.WriteLine("\nChoose a defense:");
                    int i = 1;
                    foreach (var move in defenses)
                    {
                        Console.WriteLine($"{i}. {move.Key} ({move.Value} DEF)");
                        i++;
                    }

                    // Get player move selection
                    Console.Write("Enter number: ");
                    if (int.TryParse(Console.ReadLine(), out int moveNum) && moveNum > 0 && moveNum <= defenses.Count)
                    {
                        // Pull the move name based on the number chosen
                        string moveName = defenses.Keys.ElementAt(moveNum - 1);
                        int defense = defenses[moveName];

                        playerCreature.AddActiveDefense(defense);
                        Console.WriteLine($"\n{playerCreature.GetName()} used {moveName} and raised defense by {defense}!");
                        validChoice = true;
                    }
                    else // Handle invalid input for defense selection
                    {
                        Console.WriteLine("Invalid move selection!");
                    }
                }
                else // Handle invalid input for action selection
                {
                    Console.WriteLine("Please enter 1 or 2.");
                }
            }
            Console.ResetColor();
        }

        private void EnemyTurn() // Private method for enemy's turn logic, called in the RunBattleLoop method when it's the enemy's turn.
        {
            var enemyAttacks = enemyCreature.GetAttackMoves();

            // Simple Random Logic
            Random rando = new Random();
            int randomIndex = rando.Next(0, enemyAttacks.Count);

            string moveName = enemyAttacks.Keys.ElementAt(randomIndex);
            int damage = enemyAttacks[moveName];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nWild {enemyCreature.GetName()} used {moveName}!");
            int blocked = playerCreature.GetDefense();
            int netDamage = Math.Max(0, damage - blocked);
            
            // Conditional combat logic for enemy creature
            bool hasEvaded = CombatEvasion();
            bool AttackHits = CombatAccuracy(damage);
            if (hasEvaded == true)
            {
               Console.WriteLine($"{playerCreature.GetName()} dodged the attack!"); 
            }
            else if (AttackHits == false)
            {
                Console.WriteLine($"{enemyCreature.GetName()}'s attack missed!");
            }
            else
            {
                if (blocked > 0) Console.WriteLine($"{playerCreature.GetName()} resisted {blocked} damage!");
                playerCreature.DefenseUsed(damage);
                playerCreature.UpdateHealth(-netDamage);
                Console.WriteLine($"{playerCreature.GetName()} took {netDamage} damage!");
            }
            Console.ResetColor();
        }

        public void OutcomeMessage() // Public method to display the outcome of the battle, called at the end of the RunBattleLoop method after the battle concludes.
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n--- THE BATTLE IS OVER ---");
            if (playerCreature.GetHealth() <= 0)
            {
                Console.WriteLine("You were defeated...");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"The wild {enemyCreature.GetName()} fainted! You won!");
                Console.ResetColor();
            }
            Console.ResetColor();
        }

        private bool CombatEvasion() // This method is used for both creatures in combat for rolling evasion of attacks.
        {
            // Accuracy Random chance to hit or miss attack
            Random hitChance = new Random();
            double evasionChance = hitChance.Next(1,101);
            
        
            // Conditional for hitting target
            if (TurnOrder == 0) // Player's Turn
            {
                // Console.WriteLine($"TEST: Evasion for enemy creature is {enemyCreature.GetEvasion()}%");
                if (evasionChance < enemyCreature.GetEvasion())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else // Enemy's Turn
            {
                // Console.WriteLine($"TEST: Evasion for the player creature is {playerCreature.GetEvasion()}%");
                if (evasionChance < playerCreature.GetEvasion())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool CombatAccuracy(int damage) // This method is used for both creatures in combat for rolling accuracy of attacks. The damage parameter is used to apply a simple modifier to make higher damage moves slightly less accurate, adding a strategic element to move selection in battles.
        {
            // Accuracy Random chance to hit or miss attack
            Random hitChance = new Random();
            double AccuracyChance = hitChance.Next(1,101);
            // Console.WriteLine($"TEST: Accuracy before modifier {AccuracyChance}%");
            int damageModifier = damage / 10; // Simple modifier to make higher damage moves slightly less accurate
            AccuracyChance += damageModifier; // Increase the chance to miss for higher damage moves
            // Console.WriteLine($"TEST: Accuracy after modifier {AccuracyChance}%");
        
            // Conditional for hitting target
            if (TurnOrder == 0) // Player's Turn
            {
                // Console.WriteLine($"TEST: Accuracy for enemy creature is {enemyCreature.GetAccuracy()}%");
                if (AccuracyChance < enemyCreature.GetAccuracy())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else // Enemy's Turn
            {
                // Console.WriteLine($"TEST: Accuracy for the player creature is {playerCreature.GetAccuracy()}%");
                if (AccuracyChance < playerCreature.GetAccuracy())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}