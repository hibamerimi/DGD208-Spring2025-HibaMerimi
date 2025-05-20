using PetSimulator.Models;

namespace PetSimulator.Services
{
    public class GameLoop
    {
        private Pet pet;

        public GameLoop()
        {
            pet = new Pet();
        }

        public void Start()
        {
            Console.Write("Enter your pet's name: ");
            string? inputName = Console.ReadLine();
            pet.Name = string.IsNullOrWhiteSpace(inputName) ? "Unnamed" : inputName.Trim();

            bool running = true;
            while (running)
            {
                Console.WriteLine("=== Pet Menu ===");
                Console.WriteLine("1. Feed Pet");
                Console.WriteLine("2. Play with Pet");
                Console.WriteLine("3. Show Pet Status");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.ShowStatus();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                        break;
                }
            }
        }
    }
}
