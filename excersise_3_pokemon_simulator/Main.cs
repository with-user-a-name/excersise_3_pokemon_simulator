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

            List<Attack> pkMnAttacks;
            Pokemon pkMn;

            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            pkMn = new FirePokemon(pkMnAttacks, _ui);

            _ui.WrLn("Init before pkMn.RandomAttack()");
            pkMn.RandomAttack();
            _ui.WrLn("Init after pkMn.RandomAttack()");

            //TODO 2511121648: Create some pokemons and put them in the list
            _pokemons = new List<Pokemon>();

            // 1
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            pkMn = new FirePokemon(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);

            // 2
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            pkMn = new Charmander(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);

            // 3
            pkMnAttacks = new List<Attack>();
            pkMnAttacks.Add(flamethrower);
            pkMnAttacks.Add(ember);
            pkMn = new FirePokemon(pkMnAttacks, _ui);
            _pokemons.Add(pkMn);
        }

        public void Run()
        {
            _ui.WrLn("POKEMON");
            Init();

            if (_pokemons == null)
            {
                return;
            }
            foreach (var pokemon in _pokemons)
            {
                _ui.WrLn("###############################");
                _ui.WrLn($"pokemon.Name: \"{pokemon.Name}\"");
                pokemon.RaiseLevel();
                //pokemon.Attack();
                pokemon.RandomAttack();
                if (pokemon is IEvolvable)
                {
                    IEvolvable tmp = (IEvolvable) pokemon;
                    tmp.Evolve();
                }
            }
        }

        public Main(ConsoleUI ui)
        {
            _ui = ui;
        }
    }
}
