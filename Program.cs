using PetSimulator.Services;

namespace PetSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            game.Start();
        }
    }
}
