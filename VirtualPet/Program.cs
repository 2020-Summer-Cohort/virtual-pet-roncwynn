using System;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello! Welcome to Virtual Pets");
            Console.ResetColor();
            Console.WriteLine("\nVirtual Pets is a game that allows you, the Player, to interact with virutal pets.");
            Console.WriteLine("\nIn this version of the game Pets can be Orgainic or Robotic.");
            Console.WriteLine("\nYou will be able interact with these pets for as short or as long as you like.");
            Console.WriteLine("\nAdditionally, you can add Virtual Pets to the Shelter and /or adopt pets from the shelter.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress ENTER to begin the game.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            Game playersGame = new Game();
            playersGame.BeginGame();
        }

    }
}
