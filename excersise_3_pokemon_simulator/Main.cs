using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.UI;


namespace excersise_3_pokemon_simulator
{
    internal class Main
    {
        private List<Pokemon> _pokemons = new List<Pokemon>();
        private ConsoleUI _ui;

        public void Init()
        {
            Attack flamethrower = new Attack(name: "Flamethrower", ElementType.Fire, basePower: 12, _ui);
            Attack ember = new Attack(name: "Ember", ElementType.Fire, basePower: 6, _ui);
            Attack choke = new Attack(name: "Choke", ElementType.Water, basePower: 9, _ui);
            Attack tsunami = new Attack(name: "Tsunami", ElementType.Water, basePower: 24, _ui);
            Attack poison = new Attack(name: "Poison", ElementType.Grass, basePower: 18, _ui);
            Attack cut = new Attack(name: "Cut", ElementType.Grass, basePower: 11, _ui);

            List<Attack> pkMnAttacks;
            Pokemon pkMn;

            // Charmander
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            pkMn = new Charmander(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);

            // Squirtle
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(choke);
            pkMnAttacks.Add(tsunami);
            pkMn = new Squirtle(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);

            // Bulbasaur
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(poison);
            pkMnAttacks.Add(cut);
            pkMn = new Bulbasaur(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);
        }

        public void Run()
        {
            bool quit = false;

            _ui.WrLn("###############################     POKEMON     ###############################");
            Init();

            while (!quit)
            {
                foreach (var pokemon in _pokemons)
                {
                    _ui.WrLn("-------------------------------------------------------------------------------");
                    pokemon.RaiseLevel();
                    pokemon.Attack();
                    //pokemon.RandomAttack();
                    if (pokemon is IEvolvable)
                        ((IEvolvable)pokemon).Evolve();

                }
                _ui.Wr("Hit 'q' if you want to quit: ");
                quit = _ui.IsKeyPressed("q");
                _ui.WrLn();
            }
        }

        public Main(ConsoleUI ui)
        {
            _ui = ui;
        }
    }
}
