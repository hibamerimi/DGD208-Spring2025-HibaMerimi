using System;
using PetSimulator.Models;

namespace PetSimulator.Services
{
    public static class EventManager
    {
        public static void SubscribeToDeath(Pet pet)
        {
            pet.OnDeath += name =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} has passed away. Game Over.");
                Console.ResetColor();
            };
        }
    }
}
