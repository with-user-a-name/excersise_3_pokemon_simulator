using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.UI;


namespace excersise_3_pokemon_simulator
{
    enum ElementType
    {
        Fire,
        Water,
        Grass
    }


    class Charmander : FirePokemon, IEvolvable
    {
        public Charmander(List<Attack> attacks) : base(attacks)
        {

        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }
    }


    public interface IEvolvable
    {
        void Evolve();
    }


    internal class Main
    {
        private List<Pokemon>? _pokemons;
        private ConsoleUI _ui;

        public void Init()
        {
            // 3. Create at least two attacks per type.
            Attack flamethrower = new Attack(name: "Flamethrower", ElementType.Fire,  basePower: 12, _ui);
            Attack ember        = new Attack(name: "Ember",        ElementType.Fire,  basePower:  6, _ui);
            Attack poison       = new Attack(name: "Poison",       ElementType.Grass, basePower: 18, _ui);
            Attack cut          = new Attack(name: "Cut",          ElementType.Grass, basePower: 11, _ui);
            Attack choke        = new Attack(name: "Choke",        ElementType.Water, basePower:  9, _ui);
            Attack tsunami      = new Attack(name: "Tsunami",      ElementType.Water, basePower: 24, _ui);

            // Just a quick test.
            flamethrower.Use(10);
            ember.Use(20);

            var pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            //pkMnAttacks.Add(flamethrower);
            //pkMnAttacks.Add(choke);
            var pkMn = new FirePokemon(pkMnAttacks);

            _ui.WrLn("Init before pkMn.RandomAttack()");
            pkMn.RandomAttack();
            _ui.WrLn("Init after pkMn.RandomAttack()");

            //TODO 2511121648: Create some pokemons and put them in the list
            _pokemons = new List<Pokemon>();
            _pokemons.Add(pkMn);

        }

        public void Run()
        {
            _ui.WrLn("POKEMON");
            Init();

            //TODO 2511121629: Run through the pokemon list once for a starter to see how things work...
            foreach (var pokemon in _pokemons)
            {
                pokemon.RaiseLevel();
                pokemon.Attack();
                //TODO 2511121651: Check if pokemon implements IEvolvable and call Evolve in that case.
                //pokemon.Evolve();
            }
        }

        public Main(ConsoleUI ui)
        {
            _ui = ui;
        }
    }
}
