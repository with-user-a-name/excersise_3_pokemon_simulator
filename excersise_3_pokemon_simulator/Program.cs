using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI ui = new ConsoleUI();

            Main main = new Main(ui);
            main.Run();
        }
    }
}
