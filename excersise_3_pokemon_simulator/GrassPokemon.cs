using System.Collections.Generic;
using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    class GrassPokemon : Pokemon
    {
        public GrassPokemon(List<Attack> attacks, ConsoleUI ui) : base(attacks, ElementType.Grass, ui)
        {
            Name = this.GetType().Name;
        }
    }
}
