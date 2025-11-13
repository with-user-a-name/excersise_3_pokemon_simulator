using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    internal class Attack
    {
        private ConsoleUI _ui;
        public int BasePower { get; set; }
        public ElementType ElementType { get; set; }
        public string Name { get; set; }

        public Attack(string name, ElementType elementType, int basePower, ConsoleUI ui)
        {
            Name = name;
            ElementType = elementType;
            BasePower = basePower;
            _ui = ui;
        }

        public void Use(int level)
        {
            _ui.WrLn($"{Name} hit with a total power of {BasePower+level}");
        }
    }
}
