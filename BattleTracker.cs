using System;
using System.Collections.Generic;
using System.Linq;

namespace CodexGame
{
    internal class BattleTracker
    {
        private int TurnOrder = 0; // 0 = Player, 1 = Enemy
        private int TurnTracker = 1;
        private Creatures player;
        private Creatures enemy;

        public BattleTracker(Creatures playerInput, Creatures enemyInput)
        {
            player = playerInput;
            enemy = enemyInput;
        }

        public void RunBattleLoop()
        {
            Console.WriteLine($"\nA wild {enemy.GetName()} appeared!");

            while (player.Health() > 0 && enemy.Health() > 0)
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
                Console.WriteLine($"{player.GetName()} HP: {player.Health()} | {enemy.GetName()} HP: {enemy.Health()}");
                Console.WriteLine("What will you do? 1. Attack | 2. Defense");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Get the list of attacks added for each creature
                    var attacks = player.GetAttackMoves();

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

                        enemy.UpdateHealth(-damage);
                        Console.WriteLine($"\n{player.GetName()} used {moveName} for {damage} damage!");
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move selection!");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine($"\n{player.GetName()} has defence up!");
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2.");
                }
            }
        }

        private void EnemyTurn()
        {
            var enemyAttacks = enemy.GetAttackMoves();

            // Simple Random Logic
            Random rando = new Random();
            int randomIndex = rando.Next(0, enemyAttacks.Count);

            string moveName = enemyAttacks.Keys.ElementAt(randomIndex);
            int damage = enemyAttacks[moveName];

            Console.WriteLine($"\nWild {enemy.GetName()} used {moveName}!");
            player.UpdateHealth(-damage);
            Console.WriteLine($"{player.GetName()} took {damage} damage!");
        }

        public void OutcomeMessage()
        {
            Console.WriteLine("\n--- THE BATTLE IS OVER ---");
            if (player.Health() <= 0)
            {
                Console.WriteLine("You were defeated...");
            }
            else
            {
                Console.WriteLine($"The wild {enemy.GetName()} fainted! You won!");
            }
        }
    }
}