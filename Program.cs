// Program to run the Codex Game
using System;
namespace CodexGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Codex Game!");
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Hello, {playerName}! Let's start the game.");
        }
    }
}
