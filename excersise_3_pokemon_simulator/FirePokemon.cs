using System.Collections.Generic;
using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    class FirePokemon : Pokemon
    {
        public FirePokemon(List<Attack> attacks, ConsoleUI ui) : base(attacks, ElementType.Fire, ui)
        {
            Name = this.GetType().Name;
        }
    }
}
