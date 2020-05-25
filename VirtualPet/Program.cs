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
            Console.WriteLine("Hello! Welcome to Virtual Pets");
            Console.WriteLine("\nVirtual Pets is a game whereby which you, the Player, can create an imaginary pet inside the computer.");
            Console.WriteLine("\nYou will be able interact with this pet for a short or as long as you like");
            Console.WriteLine("\nWould you like to play the Virtual Pet game now?  Please press Y or N");

            string playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            while (playerGameResponse != "y" && playerGameResponse != "n")
            {
                Console.WriteLine($"\nThat input was not a 'Y' or 'N'.  Please try again.");
                playerGameResponse = Console.ReadKey().KeyChar.ToString().ToLower();
            }
            if (playerGameResponse == "y")
            {
                Console.Clear();
                Game playersGame = new Game();
                playersGame.BeginGame();
            }
            else 
            {
                Console.WriteLine("\nPlease come back another time.");
            }
        }

    }
}
