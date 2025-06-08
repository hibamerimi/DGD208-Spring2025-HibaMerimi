using System;
using PetSimulator.Services;

namespace PetSimulator.Models
{
    public class Pet
    {
        public string Name { get; }
        public int Hunger { get; private set; } = 100;
        public int Energy { get; private set; } = 100;
        public int Happiness { get; private set; } = 100;

        public bool IsDead { get; private set; } = false;

        public event Action<string>? OnDeath;

        public Pet(string name)
        {
            Name = name;
        }

        public void Feed()
        {
            Hunger = Math.Min(100, Hunger + 20);
            Logger.Log($"{Name} was fed.");
        }

        public void Play()
        {
            if (Energy >= 10)
            {
                Happiness = Math.Min(100, Happiness + 15);
                Energy -= 10;
                Logger.Log($"{Name} played.");
            }
            else
            {
                Logger.Log($"{Name} is too tired to play.");
            }
        }

        public void Sleep()
        {
            Energy = Math.Min(100, Energy + 25);
            Logger.Log($"{Name} took a nap.");
        }

        public void Update()
        {
            Hunger -= 30;
            Energy -= 20;
            Happiness -= 25;

            if (Hunger <= 0 || Energy <= 0 || Happiness <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (!IsDead)
            {
                IsDead = true;
                Logger.Log($"{Name} has died...");
                OnDeath?.Invoke(Name);
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"\n{Name}'s Stats → Hunger: {Hunger}, Energy: {Energy}, Happiness: {Happiness}");
        }
    }
}
