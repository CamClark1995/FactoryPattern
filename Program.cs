using System;
using System.Text.RegularExpressions;
using SF = FactoryPattern.SimpleFactory;
using FM = FactoryPattern.FactoryMethod;
using AF = FactoryPattern.AbstractFactory;

// All three patterns serve the purpose of object creation
// They are thus classified as creational design patterns
namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean endProgram = false;
            while (!endProgram)
            {
                Console.WriteLine("\nWhich demo would you like to run?");
                Console.WriteLine("a) Simple Factory");
                Console.WriteLine("b) Factory Method");
                Console.WriteLine("c) Abstract Factory");
                Console.WriteLine("d) Exit");

                var userDemo = Console.ReadLine();
                switch (userDemo.ToLower())
                {
                    case "a":
                        SimpleFactoryDemo();
                        break;
                    case "b":
                        FactoryMethodDemo();
                        break;
                    case "c":
                        AbstractFactoryDemo();
                        break;
                    default:
                        endProgram = true;
                        break;
                }
            }
        }

        // Simple factory, returns object based on parameter
        // Returns a sandwich type based on number of ingredients provided
        public static void SimpleFactoryDemo()
        {
            Console.WriteLine("How many ingredients would you like on your sandwich?");

            var numIngredients = Console.ReadLine();

            var sandwich = SF.SandwichFactory.Build(Int16.Parse(numIngredients));

            Console.WriteLine($"You ordered a {TypeNameAddSpaces(sandwich.GetType().Name)}");
        }

        // Factory method, adds classes based on specified object
        // Gives you specific ingredients based on chosen sandwich
        public static void FactoryMethodDemo()
        {
            FM.SandwichFactory sandwich;

            Console.WriteLine("Which sandwich would you like to learn about?");
            Console.WriteLine("a) Bread Sandwich");
            Console.WriteLine("b) Grilled Cheese");
            Console.WriteLine("c) Tuna Melt");

            var userSandwich = Console.ReadLine();
            switch (userSandwich.ToLower())
            {
                case "a":
                    sandwich = new FM.BreadSandwich();
                    break;
                case "b":
                    sandwich = new FM.GrilledCheese();
                    break;
                case "c":
                    sandwich = new FM.TunaMelt();
                    break;
                default:
                    Console.WriteLine("-----Not a viable option-----");
                    return;
            }

            Console.WriteLine(TypeNameAddSpaces(sandwich.GetType().Name) + " is made with:");
            foreach (FM.Ingredient a in sandwich.Ingredients)
            {
                Console.WriteLine(" " + a.GetType().Name);
            }
        }

        // Abstract Factory, creates families of classes
        // Allows you to see specific types of ingredients, not just ingredients themselves
        public static void AbstractFactoryDemo()
        {
            AF.SandwichFactory sandwichFactory;

            Console.WriteLine("Which sandwich would you like to learn about?");
            Console.WriteLine("a) Bread Sandwich");
            Console.WriteLine("b) Grilled Cheese");
            Console.WriteLine("c) Tuna Melt");

            var userSandwich = Console.ReadLine();
            switch (userSandwich.ToLower())
            {
                case "a":
                    sandwichFactory = new AF.BreadSandwich();
                    break;
                case "b":
                    sandwichFactory = new AF.GrilledCheese();
                    break;
                case "c":
                    sandwichFactory = new AF.TunaMelt();
                    break;
                default:
                    Console.WriteLine("-----Not a viable option-----");
                    return;
            }

            var sandwichBuilder = new AF.SandwichBuilder(sandwichFactory);
            sandwichBuilder.DescribeSandwich();
        }

        public static string TypeNameAddSpaces(string type)
        {
            return Regex.Replace(type, "([a-z])([A-Z])", "$1 $2");
        }

    }
}
