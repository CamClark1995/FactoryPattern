using System.Collections.Generic;

/*
The factory method patern defines an interface (SandwichFactory) for creating an object,
but lets its subclasses (GrilledCheese, TunaMelt) decide which class (Ingredients) to instantiate.
AKA uses inheritance to decide the object to be instantiated.

Could have also set this up as a one-to-one where the sandwich returns either a bread, meat, or cheese.
*/
namespace FactoryPattern.FactoryMethod
{
    abstract class Ingredient
    {
    }

    class Bread : Ingredient
    {
    }
    class Meat : Ingredient
    {
    }
    class Cheese : Ingredient
    {
    }

    abstract class SandwichFactory
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        public List<Ingredient> Ingredients
        {
            get { return _ingredients; }
        }

        public SandwichFactory()
        {
            this.AddIngredients();
        }

        public abstract void AddIngredients();
    }

    class BreadSandwich : SandwichFactory
    {
        public override void AddIngredients()
        {
            Ingredients.Add(new Bread());
        }
    }

    class GrilledCheese : SandwichFactory
    {
        public override void AddIngredients()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new Cheese());
        }
    }

    class TunaMelt : SandwichFactory
    {
        public override void AddIngredients()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new Cheese());
            Ingredients.Add(new Meat());
        }
    }
}