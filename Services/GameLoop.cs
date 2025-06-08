using System;
using System.Collections.Generic;
using PetSimulator.Models;

namespace PetSimulator.Services
{
    public static class GameLoop
    {
        public static void Run()
        {
            List<Pet> pets = new();

            int petCount = AskPetCount();
            for (int i = 1; i <= petCount; i++)
            {
                Console.Write($"Name your pet #{i}: ");
                string name = Console.ReadLine() ?? $"Pet{i}";
                var pet = new Pet(name);
                EventManager.SubscribeToDeath(pet);
                pets.Add(pet);
            }

            while (pets.Exists(p => !p.IsDead))
            {
                Console.Clear();
                Console.WriteLine("Your pets:");
                for (int i = 0; i < pets.Count; i++)
                {
                    var pet = pets[i];
                    string status = pet.IsDead
                        ? "DEAD"
                        : $"Hunger: {pet.Hunger} | Energy: {pet.Energy} | Happiness: {pet.Happiness}";
                    Console.WriteLine($"{i + 1}. {pet.Name} - {status}");
                }

                Console.Write("\nSelect a pet to manage (1-" + petCount + "), or 0 to quit: ");
                string petInput = Console.ReadLine() ?? "0";

                if (petInput == "0") break;

                if (int.TryParse(petInput, out int index) && index >= 1 && index <= petCount)
                {
                    var selectedPet = pets[index - 1];
                    if (selectedPet.IsDead)
                    {
                        Console.WriteLine("That pet is dead. Press Enter to continue...");
                        Console.ReadLine();
                        continue;
                    }

                    HandlePet(selectedPet);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                }

                foreach (var pet in pets)
                {
                    if (!pet.IsDead) pet.Update();
                }

                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("\nAll pets are dead or the game was exited. Final logs:");
            Logger.ShowLastLogs(20);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static int AskPetCount()
        {
            while (true)
            {
                Console.Write("How many pets do you want to create? (1–4): ");
                string input = Console.ReadLine() ?? "1";
                if (int.TryParse(input, out int count) && count >= 1 && count <= 4)
                    return count;

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        private static void HandlePet(Pet pet)
        {
            Console.Clear();
            pet.ShowStats();
            Console.WriteLine($"\nChoose an action for {pet.Name}:");
            Console.WriteLine("1. Feed\n2. Play\n3. Sleep\n4. View Logs\n5. Back");

            string input = Console.ReadLine() ?? "5";

            switch (input)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Sleep();
                    break;
                case "4":
                    Logger.ShowLastLogs();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid input. Press Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
