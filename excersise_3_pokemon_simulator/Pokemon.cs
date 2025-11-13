namespace excersise_3_pokemon_simulator
{
    abstract class Pokemon
    {
        protected List<Attack> _attacks;

        //TODO 2511131808: Perhaps extract min/max values for a prop to an enum?
        private const int _levelMinVal = 1;
        private const int _nameMaxLen = 15;
        private const int _nameMinLen = 2;

        private uint _level;
        private string _name = "";

        public uint Level
        {
            get => _level;
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan<uint>
                    (value, _levelMinVal, nameof(value));
                _level = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                //The Name property must contain between 2 < 15 characters.
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                ArgumentOutOfRangeException.ThrowIfGreaterThan<int>
                    (value.Length
                    ,_nameMaxLen
                    ,$"{nameof(value)}.{nameof(value.Length)}");
                ArgumentOutOfRangeException.ThrowIfLessThan<int>
                    (value.Length
                    ,_nameMinLen
                    ,$"{nameof(value)}.{nameof(value.Length)}");
                _name = value;
            }
        }

        public ElementType Type { get; protected set; }

        protected Pokemon(List<Attack> attacks)
        {
            ArgumentNullException.ThrowIfNull(attacks);
            _attacks = attacks;
        }

        public void RandomAttack()
        {
            // Selects a random attack from the list and calls its .Use method.
            int i = 1;
            foreach (var attack in _attacks)
            {
                attack.Use(i++);
            }
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
}
