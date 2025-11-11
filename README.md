
# Pokémon Simulator – C#

## Purpose

Build a simple Pokémon simulation in C#. The project should demonstrate your understanding of:

- Encapsulation (fields + validation)
- Inheritance and abstraction
- Polymorphism
- Implementation of interfaces
- Use of enums and composition
- Use of exceptions

## Functionality

You will create a small simulator for a Pokémon training program. Each Pokémon has an elemental type, can attack, and some can evolve. Your trainer can level up their Pokémon and observe their attacks.

## Instructions

1. Define ElementType Enum
   Create an enum called ElementType with the values:
   - Fire
   - Water
   - Grass

   This will be used for both Pokémon and attacks.

2. Create the Attack Class
   Define a class Attack with:
   - string Name
   - ElementType Type
   - int BasePower
    
   Include a method:

   `public void Use(int level)`

   It shall print a message to the console like for instance:

   `Flamethrower hit with a total power of 13`
        
   Where 13 resembles BasePower + level

3. Create Predefined Attacks
   Before the program starts (e.g., in Main()), create at least two attacks per type and assign them to variables:

   ```C#
   Attack flamethrower = new Attack("Flamethrower", ElementType.Fire, 12);
   Attack ember = new Attack("Ember", ElementType.Fire, 6);
   ```

4. Create an Abstract Class Pokemon
   Use public properties and include validation logic to ensure data integrity. Appropriate exceptions should be thrown if something goes wrong in validation.

   - A property for Name (2–15 characters)
   - A property for Level (must be ≥ 1)
   - A property for Type representing the elemental type of your Pokémon
   - A field List<Attack> named Attacks, which should be provided via the constructor. This list represents the attacks your Pokémon knows.
   
   Three methods shall exist:
   
   ```C#
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
   ```

5. Create Three Pokémon Subclasses
   Create subclasses for each type:

   - FirePokemon : Pokemon
   - WaterPokemon : Pokemon
   - GrassPokemon : Pokemon

   These should automatically set the Type field to the corresponding enum value (ElementType.Fire, ElementType.Water, ElementType.Grass).
   
   Then create at least three named Pokémon subclasses (e.g., Charmander, Squirtle, Bulbasaur) that inherit from the correct type class:

   - Charmander : FirePokemon
   - Squirtle : WaterPokemon
   - Bulbasaur: GrassPokemon

6. Add an Interface for Evolution
   Create an interface:

   ```C#
   public interface IEvolvable
   {
       void Evolve();
   }
   ```

   Let at least one Pokémon implement this interface. Upon evolving, it should:

   - Change its Name
   - Increase its Level by 10
   - Print a message, e.g. "Evolved to {NewName}!"

7. Simulate the Trainer
   In your Main()-method:

   - Create several Pokémon and store them in a List<Pokemon>
   - Call RaiseLevel() and Attack() on each Pokémon
   - If a Pokémon implements IEvolvable, call its Evolve() method
   - Handle any exceptions thrown.

## Reflection Questions

* When you create a Pokémon and try to access its fields directly – does it work? Why or why not?
* If you later want to add a new property applicable to all Grass-type Pokémon, where should you place it to avoid repetition?
* If the new property is to apply to all Pokémon, where is the correct place to define it?
* What happens if you try to add a Charmander to a list that only allows WaterPokemon?
* You want to store different types of Pokémon – Charmander, Squirtle, and Bulbasaur – in the same list. What type should the list be to make it work?
* When you loop through the list and call Attack(), what enables the correct attack behavior to execute for each Pokémon?
* If you create a method that only exists on Bulbasaur, why can’t you call it directly when it’s in a List<Pokemon>? How would you access it nonetheless?

## Submission

- All code should be well-structured in separate files if possible.
- Avoid hard-coded values in methods (pass level to the attack, for example).
- You may add additional Pokémon, attacks, or features as a bonus.

