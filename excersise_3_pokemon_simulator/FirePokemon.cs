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

    class FirePokemon(List<Attack> attacks) : Pokemon(attacks, ElementType.Fire) {}
}
