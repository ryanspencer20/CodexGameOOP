using System;
using System.Collections.Generic;
using System.Linq;

namespace CodexGame
{
    internal class BattleTracker
    {
        private int TurnOrder = 0; // 0 = Player, 1 = Enemy
        private int TurnTracker = 1;
        private Creatures playerCreature;
        private Creatures enemyCreature;

        public BattleTracker(Creatures playerCreature, Creatures enemyCreature, int turnOrder = 0, int turnTracker = 1)
        {
            this.playerCreature = playerCreature;
            this.enemyCreature = enemyCreature;
            this.TurnOrder = turnOrder;
            this.TurnTracker = turnTracker;
        }

        public void RunBattleLoop()
        {
            Console.WriteLine($"\nA wild {enemyCreature.GetName()} appeared!");

            while (playerCreature.GetHealth() > 0 && enemyCreature.GetHealth() > 0)
            {
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

        private void PlayerTurn()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine($"{playerCreature.GetName()} HP: {playerCreature.GetHealth()} | {enemyCreature.GetName()} HP: {enemyCreature.GetHealth()}");
                Console.WriteLine("What will you do? 1. Attack | 2. Defense");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Get the list of attacks added for each creature
                    Dictionary<string, int> attacks = playerCreature.GetAttackMoves();

                    // Display the menu
                    Console.WriteLine("\nChoose an attack:");
                    int i = 1;
                    foreach (var move in attacks)
                    {
                        Console.WriteLine($"{i}. {move.Key} ({move.Value} DMG)");
                        i++;
                    }

                    // Get player move selection
                    Console.Write("Enter number: ");
                    if (int.TryParse(Console.ReadLine(), out int moveNum) && moveNum > 0 && moveNum <= attacks.Count)
                    {
                        // Pull the move name based on the number chosen
                        string moveName = attacks.Keys.ElementAt(moveNum - 1);
                        int damage = attacks[moveName];

                        enemyCreature.UpdateHealth(-damage);
                        Console.WriteLine($"\n{playerCreature.GetName()} used {moveName} for {damage} damage!");
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move selection!");
                    }
                }
                else if (choice == "2")
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

                        playerCreature.SetActiveDefense(defense);
                        Console.WriteLine($"\n{playerCreature.GetName()} used {moveName} and raised defense by {defense}!");
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move selection!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2.");
                }
            }
        }

        private void EnemyTurn()
        {
            var enemyAttacks = enemyCreature.GetAttackMoves();

            // Simple Random Logic
            Random rando = new Random();
            int randomIndex = rando.Next(0, enemyAttacks.Count);

            string moveName = enemyAttacks.Keys.ElementAt(randomIndex);
            int damage = enemyAttacks[moveName];

            Console.WriteLine($"\nWild {enemyCreature.GetName()} used {moveName}!");
            int blocked = playerCreature.DefenseUsed();
            int netDamage = Math.Max(0, damage - blocked);
            playerCreature.UpdateHealth(-netDamage);
            if (blocked > 0) Console.WriteLine($"{playerCreature.GetName()} resisted {blocked} damage!");
            Console.WriteLine($"{playerCreature.GetName()} took {netDamage} damage!");
        }

        public void OutcomeMessage()
        {
            Console.WriteLine("\n--- THE BATTLE IS OVER ---");
            if (playerCreature.GetHealth() <= 0)
            {
                Console.WriteLine("You were defeated...");
            }
            else
            {
                Console.WriteLine($"The wild {enemyCreature.GetName()} fainted! You won!");
            }
        }
    }
}