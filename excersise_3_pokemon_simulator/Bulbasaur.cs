using System;
using System.Collections.Generic;
using Utils.UI;


namespace excersise_3_pokemon_simulator
{
    class Bulbasaur : GrassPokemon
    {
        public Bulbasaur(List<Attack> attacks, ConsoleUI ui) : base(attacks, ui)
        {
            Name = this.GetType().Name;
        }

    }
}
