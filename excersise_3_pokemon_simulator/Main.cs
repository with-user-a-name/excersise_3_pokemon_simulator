using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace excersise_3_pokemon_simulator
{
    enum ElementType
    {
        Fire,
        Water,
        Grass
    }


    internal class Attack
    {

        public int BasePower { get; set; }
        public ElementType ElementType { get; set; }
        public string Name { get; set; }

        public Attack(string name, ElementType elementType, int basePower)
        {
            Name = name;
            ElementType = elementType;
            BasePower = basePower;
        }

        public void Use(int level)
        {
            Console.WriteLine($"Flamethrower hit with a total power of {BasePower+level}");
        }
    }


    abstract class Pokemon
    {
        private List<Attack>? _attacks;

        //TODO 2511121551: Validate that it is 2–15 characters.
        public int Name { get; set; }
        //TODO 2511121552: Validate that it is greater than 1 (>=1).
        public uint Level{ get; set; }
        public ElementType Type { get; set; }

        protected Pokemon(List<Attack> attacks)
        {
            //TODO 2511121559: Make a deep copy of attacks in _attacks ?!
            //Or whats the purpose, how will it be used...
        }

        public void RandomAttack()
        {
            // Selects a random attack from the list and calls its .Use method.
        }

        public void Attack()
        {
            // Allows the user to choose an attack from the list and calls its .Use method.
        }

        public void RaiseLevel()
        {
            // Increases the Pokémon's level and prints that it has leveled up.
        }
    }


    class FirePokemon : Pokemon
    {
        public FirePokemon(List<Attack> attacks) : base(attacks)
        {

        }
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

        public void Init()
        {
            // 3. Create at least two attacks per type.
            Attack flamethrower = new Attack(name: "Flamethrower", elementType: ElementType.Fire, basePower: 12);
            Attack ember = new Attack("Ember", ElementType.Fire, 6);

            _pokemons = new List<Pokemon>();
            //TODO 2511121648: Create some pokemons and put them in the list
        }

        public void Run()
        {
            Console.WriteLine("POKEMON");
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
    }
}
