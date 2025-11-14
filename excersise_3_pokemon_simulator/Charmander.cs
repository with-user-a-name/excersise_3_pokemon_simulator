using System;
using System.Collections.Generic;
using Utils.UI;


namespace excersise_3_pokemon_simulator
{
    class Charmander : FirePokemon, IEvolvable
    {
        public Charmander(List<Attack> attacks, ConsoleUI ui) : base(attacks, ui)
        {
            Name = this.GetType().Name;
        }

        public void Evolve()
        {
            _ui.Wr($"{Name} is evolving... ");
            Level += 10;
            Name = "Charmeleon";
            _ui.WrLn($"Now it is a {Name} and its level {Level}");
        }
    }
}
