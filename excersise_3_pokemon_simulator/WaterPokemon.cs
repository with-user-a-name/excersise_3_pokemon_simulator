using System.Collections.Generic;
using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    class WaterPokemon : Pokemon
    {
        public WaterPokemon(List<Attack> attacks, ConsoleUI ui) : base(attacks, ElementType.Water, ui)
        {
            Name = this.GetType().Name;
        }
    }
}
