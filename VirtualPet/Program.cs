using System;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Virtual Pets");

            Console.WriteLine("Enter Pet Name:");
            string petName = Console.ReadLine();

            Pet somePet = new Pet();
            somePet.Name = petName;
            Console.WriteLine($"pet name = {somePet.Name}");

            Console.WriteLine("Enter Pet Name:");
            petName = Console.ReadLine();
            somePet.SetName(petName);
            somePet.SetSpecies("Lion");
            Console.WriteLine($"pet name = {somePet.Name}");

            Pet somePet2 = new Pet("Ron", "Tiger");
            Console.WriteLine($" {somePet2.Name} is a {somePet2.Species}.");


        }

    }
}
