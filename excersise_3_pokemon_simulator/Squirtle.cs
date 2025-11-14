using System;
using System.Collections.Generic;
using Utils.UI;


namespace excersise_3_pokemon_simulator
{
    class Squirtle : WaterPokemon
    {
        public Squirtle(List<Attack> attacks, ConsoleUI ui) : base(attacks, ui)
        {
            Name = this.GetType().Name;
        }

    }
}
