/***
* The simple factory is an object for creating other objects, without exposing instantiation logic.
* Sandwich factory returns a type of sandwich based on number of ingredients.
***/
namespace FactoryPattern.SimpleFactory
{
    public interface ISandwich
    {
    }

    public class BreadSandwich : ISandwich
    {
    }
    public class GrilledCheese : ISandwich
    {
    }

    public class TunaMelt : ISandwich
    {
    }

    public class Deluxe : ISandwich
    {
    }

    public static class SandwichFactory
    {
        public static ISandwich Build(int numIngredients)
        {
            switch (numIngredients)
            {
                case 0:
                    return new BreadSandwich();
                case 1:
                    return new BreadSandwich();
                case 2:
                    return new GrilledCheese();
                case 3:
                    return new TunaMelt();
                default:
                    return new Deluxe();
            }
        }
    }

}