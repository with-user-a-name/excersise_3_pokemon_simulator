namespace excersise_3_pokemon_simulator
{

    public class ValuesNotEqualException<T> : Exception
    {
        public T OpA { get; }
        public T OpB { get; }

        public ValuesNotEqualException(string message, T opA, T opB)
            : base(message)
        {
            OpA = opA;
            OpB = opB;
        }
    }

    class FirePokemon : Pokemon
    {
        public FirePokemon(List<Attack> attacks) : base(attacks)
        {
            Type = ElementType.Fire;

            //TODO 2511132244: Move check of Type so it wont have to be repeated in every subclass of Pokemon.
            //NOTE 2511132237: Update _attacks with the new Type verified
            //list tmpAttacks. tmpAttacks is a completely different list
            //from _attacks/attacks and the only reference to it once
            //tmpAttacks goes out of scope, when this ctor returns, is the
            //protected _attacks field in the base class Pokemon.
            //Hovewer, the Attack elements in the tmpAttacks list are the same
            //between all three lists (attacks, tmpAttacks, _attacks) but that
            //should not matter as the props in the Attack class are only
            //possible to read from the outside.
            var tmpAttacks = new List<Attack>();
            foreach (var attack in _attacks)
            {
                if (Type != attack.Type)
                {
                    throw new ValuesNotEqualException<ElementType>("(Type != attack.Type)", Type, attack.Type);
                }
                tmpAttacks.Add(attack);
            }
            _attacks = tmpAttacks;
        }
    }
}
