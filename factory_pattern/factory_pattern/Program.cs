using System;

namespace factory_pattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PizzaStore pizzaStore = new NYPizzaStore();
            pizzaStore.OrderPizza("cheese");
            pizzaStore.OrderPizza("clam");
        }
    }

    public abstract class Pizza
    {
        public string pizzaName = "pizza";
        public Dough dough;
        public Sauce sauce;
        public Cheese cheese;
        public Veggies[] veggies;
        public Perroni perroni;
        public Clams clams;

        public abstract void prepare();

        public void create()
        {
            Console.WriteLine("Created a " + pizzaName);
            prepare();
        }
        public void setName (string name)
        {
            this.pizzaName = name;
        }
        public string getName ()
        {
            return this.pizzaName;
        }
    }

    public class CheesePizza : Pizza
    {
        PizzaIngredientsFactory pizzaIngredientsFactory;

        public CheesePizza(PizzaIngredientsFactory ingredientsFactory)
        {
            pizzaIngredientsFactory = ingredientsFactory;
            pizzaName = "cheesePizza";
        }

        public override void prepare()
        {
            Console.WriteLine("Preparing " + pizzaName);
            dough = pizzaIngredientsFactory.createDough();
            sauce = pizzaIngredientsFactory.createSauce();
            cheese = pizzaIngredientsFactory.createCheese();
        }
    }

    public class ClamPizza : Pizza{
        PizzaIngredientsFactory pizzaIngredientsFactory;

        public ClamPizza (PizzaIngredientsFactory ingredientsFactory){
            pizzaIngredientsFactory = ingredientsFactory;
            pizzaName = "ClamPizza";
        }

        public override void prepare(){
            Console.WriteLine("Preparing " + pizzaName);
            dough = pizzaIngredientsFactory.createDough();
            sauce = pizzaIngredientsFactory.createSauce();
            cheese  = pizzaIngredientsFactory.createCheese();
            clams = pizzaIngredientsFactory.createClam();
        }
    }
    /*
    public class ChicagoCheesePizza :Pizza
    {
        public ChicagoCheesePizza(){
            pizzaName = "ChCheesePizza";
        }

        public override void prepare()
        {
            throw new NotImplementedException();
        }
    }

    class NYCheesePizza : Pizza
    {
        public NYCheesePizza (){
            pizzaName = "NYCheesePizza";
        }

        public override void prepare()
        {
            throw new NotImplementedException();
        }
    }
    */
    class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            PizzaIngredientsFactory ingredientsFactory = new NYPizzaIngredientFactory();
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientsFactory); /*new chesee pizza*/
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientsFactory);
                    break;
                default:
                    pizza = null;
                    break;
            }
            return pizza;
        }
    }

    class ChPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            PizzaIngredientsFactory ingredientsFactory = new ChPizzaIngredientFactory();
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(ingredientsFactory);
                    pizza.setName("Chicago Cheese Pizza");
                    break;
                case "clam":
                    pizza = new ClamPizza(ingredientsFactory);
                    break;
                default:
                    pizza = null;
                    break;
            }
            return pizza;
        }
    }


    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            pizza = CreatePizza(type);
            pizza.create();

            return pizza;
        }

        public abstract Pizza CreatePizza(string type);
    }

    public interface PizzaIngredientsFactory {
        Dough createDough();
        Sauce createSauce();
        Cheese createCheese();
        Veggies[] createVeggies();
        Perroni createPerroni();
        Clams createClam();
    }

    public class NYPizzaIngredientFactory : PizzaIngredientsFactory
    {
        public Cheese createCheese()
        {
            return new Cheese();
        }

        public Clams createClam()
        {
            return new Clams();
        }

        public Dough createDough()
        {
            return new Dough();
        }

        public Perroni createPerroni()
        {
            return new Perroni();
        }

        public Sauce createSauce()
        {
            return new Sauce();
        }

        public Veggies[] createVeggies()
        {
            return new Veggies[5];
        }
    }

    public class ChPizzaIngredientFactory : PizzaIngredientsFactory
    {
        public Cheese createCheese()
        {
            return new Cheese();
        }

        public Clams createClam()
        {
            return new Clams();
        }

        public Dough createDough()
        {
            return new Dough();
        }

        public Perroni createPerroni()
        {
            return new Perroni();
        }

        public Sauce createSauce()
        {
            return new Sauce();
        }

        public Veggies[] createVeggies()
        {
            return new Veggies[5];
        }
    }

    public class Veggies
    {
        public Veggies() { Console.WriteLine("Created Veggies"); }

    }

    public class Sauce
    {
        public Sauce() { Console.WriteLine("Created Sauce"); }
    }

    public class Perroni
    {
        public Perroni() { Console.WriteLine("Created Perroni"); }
    }

    public class Dough
    {
        public Dough() { Console.WriteLine("Created Dough"); }
    }

    public class Cheese
    {
        public Cheese() { Console.WriteLine("Created Cheese"); }
    }
    public class Clams
    {
        public Clams() { Console.WriteLine("Created Clams"); }
    }
}

