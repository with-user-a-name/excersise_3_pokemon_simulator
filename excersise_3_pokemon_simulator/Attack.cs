using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    internal class Attack
    {
        private ConsoleUI _ui;
        public int BasePower { get; private set; }
        public ElementType Type { get; private set; }
        public string Name { get; private set; }

        public Attack(string name, ElementType type, int basePower, ConsoleUI ui)
        {
            Name = name;
            Type = type;
            BasePower = basePower;
            _ui = ui;
        }

        public void Use(int level)
        {
            _ui.WrLn($"{Name} hit with a total power of {BasePower+level}");
        }
    }
}
