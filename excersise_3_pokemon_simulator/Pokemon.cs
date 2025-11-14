using System;
using System.Collections.Generic;
using System.Threading;
using Utils.Ex;
using Utils.UI;

namespace excersise_3_pokemon_simulator
{
    abstract class Pokemon
    {
        protected readonly ConsoleUI _ui;
        protected List<Attack> _attacks;
        private static Random _rand = new Random();

        //TODO 2511131808: Perhaps extract min/max values for a prop to an enum?
        private const int _levelMinVal = 1;
        private const int _nameMaxLen = 15;
        private const int _nameMinLen = 2;

        private uint _level = _levelMinVal;
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

        protected Pokemon(List<Attack> attacks, ElementType type, ConsoleUI ui)
        {
            _ui = ui;
            Type = type;
            Name = this.GetType().Name;

            ArgumentNullException.ThrowIfNull(attacks);

            _attacks = attacks;
            ValidateElementType();
        }

        private void ValidateElementType()
        {
            //NOTE 2511132237: Update _attacks with the new ElementType
            //verified list tmpAttacks. The tmpAttacks list is a completely
            //different list from _attacks and the only reference to it once
            //tmpAttacks goes out of scope, when this method returns, is the
            //protected _attacks field in this Pokemon-class.
            //Hovewer, the Attack elements in the tmpAttacks list are the same
            //between both lists (tmpAttacks, _attacks) but that should not
            //matter as the props in the Attack class are only possible to read
            //from the outside.
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

            //TODO 2511132319: Should there be additional checks to make sure all Attack's are unique.
            //Perhaps existing functionality in the List<T> type to ensure there are no duplicates?
        }

        public void RandomAttack()
        {
            // Selects a random attack from the list and calls its .Use method.
            //_ui.WrLn($"{Name}: RandomAttack: _attacks.Count: {_attacks.Count}");
            int attackIx = _rand.Next(0, ((_attacks.Count-1) * 100));
            attackIx = (int)Math.Round((double)attackIx / 100.0);
            _attacks[attackIx].Use((int)Level);
        }

        public void Attack()
        {
            // Allows the user to choose an attack from the list and calls its .Use method.
            //_ui.WrLn($"{Name}: Attack");
            bool okSelection = false;
            int selectedAttack;

            do
            {
                ShowAttackMenu();
                string inputStr = _ui.GetInput();
                if (!int.TryParse(inputStr, out selectedAttack)
                    || ((selectedAttack < 1) || (_attacks.Count < selectedAttack)) )
                {
                    _ui.WrLn($"Invalid choice \"{inputStr}\" please try again.");
                    _ui.PressAnyKeyToContinue();
                }
                else
                {
                    okSelection = true;
                }
            } while (!okSelection);
            _attacks[selectedAttack-1].Use((int)Level);
        }

        private void ShowAttackMenu()
        {
            _ui.WrLn($"Select which of {Name} attacks to use from the list:");
            for (int i = 0; i < _attacks.Count; i++)
            {
                _ui.WrLn($"   {i+1} - {_attacks[i].Name} attack.");
            }
            _ui.Wr($"Enter choice 1 to {_attacks.Count}: ");
        }

        public void RaiseLevel()
        {
            // Increases the Pokémon's level and prints that it has leveled up.
            _ui.Wr($"{Name} has leveled up from {Level} ");
            Level += 1;
            _ui.WrLn($"to {Level}.");
        }
    }
}
