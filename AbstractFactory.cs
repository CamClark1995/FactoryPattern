/*
Abstract Factory provides an interface (SandwichFactory) for creating FAMILIES of related
objects (Cheese, Meat) without specifiying their concrete classes (Cheddar, Tuna, etc).

Instead of using inheritance like factory method, abstract factory uses composition
(classes containing instances of other classes).
*/
using System;

namespace FactoryPattern.AbstractFactory
{
    // Our abstract factory
    abstract class SandwichFactory
    {
        public abstract Cheese CreateCheese();
        public abstract Meat CreateMeat();
    }

    // These are our concrete factories
    class BreadSandwich : SandwichFactory
    {
        public override Cheese CreateCheese()
        {
            return null;
        }
        public override Meat CreateMeat()
        {
            return null;
        }
    }

    class GrilledCheese : SandwichFactory
    {
        public override Cheese CreateCheese()
        {
            return new Cheddar();
        }
        public override Meat CreateMeat()
        {
            return null;
        }
    }

    class TunaMelt : SandwichFactory
    {
        public override Cheese CreateCheese()
        {
            return new Swiss();
        }
        public override Meat CreateMeat()
        {
            return new Tuna();
        }
    }

    // Abstract products
    abstract class Cheese
    {
    }

    abstract class Meat
    {
    }

    // Concrete products
    class Swiss : Cheese
    {
    }

    class Cheddar : Cheese
    {
    }

    class Tuna : Meat
    {
    }

    /*
    Our client class, makes use of the interfaces declared by abstract factory and abstract product classes
    Client class does not know anything about concrete classes - types of sandwich/ingredients
    */
    class SandwichBuilder
    {
        public Cheese cheese;
        public Meat meat;
        public SandwichBuilder(SandwichFactory factory)
        {
            cheese = factory.CreateCheese();
            meat = factory.CreateMeat();
        }

        public void DescribeSandwich()
        {
            var msg = "This sandwich is made with ";
            if (this.meat != null)
            {
                msg += this.meat.GetType().Name;
                if (this.cheese != null)
                    msg += $" and {this.cheese.GetType().Name} Cheese";
            }
            else if (this.cheese != null)
                msg += $"{this.cheese.GetType().Name} Cheese";
            else
                msg += "bread";
            Console.WriteLine(msg);
        }
    }

}