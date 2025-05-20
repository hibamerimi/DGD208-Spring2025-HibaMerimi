namespace PetSimulator.Models
{
    public class Pet
    {
        public string Name { get; set; } = "Unnamed";
        public int Hunger { get; private set; } = 50;
        public int Happiness { get; private set; } = 50;

        public void Feed()
        {
            if (Hunger > 0)
            {
                Hunger = Math.Max(0, Hunger - 10);
                Console.WriteLine($"{Name} has been fed.");
            }
            else
            {
                Console.WriteLine($"{Name} is already full.");
            }
        }

        public void Play()
        {
            if (Happiness < 100)
            {
                Happiness = Math.Min(100, Happiness + 10);
                Console.WriteLine($"{Name} is happier now.");
            }
            else
            {
                Console.WriteLine($"{Name} is already very happy!");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nPet: {Name}");
            Console.WriteLine($"Hunger: {Hunger}/100");
            Console.WriteLine($"Happiness: {Happiness}/100\n");
        }
    }
}
