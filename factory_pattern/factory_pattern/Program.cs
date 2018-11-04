using System;

namespace factory_pattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SimplePizzaFactory factory = new SimplePizzaFactory();
            PizzaStore pizzaStore = new PizzaStore(factory);
            pizzaStore.OrderPizza("cheese");
            pizzaStore.OrderPizza("simple");
        }
    }

    class Pizza
    {
        public string pizzaName = "pizza";

        public void create()
        {
            Console.WriteLine("Created a " + pizzaName);
        }
    }

    class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            pizzaName = "cheesePizza";
        }

    }

    class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(); /*new chesee pizza*/
                    break;
                case "simple":
                    pizza = new Pizza();
                    break;
            }

            return pizza;
        }
    }

    class PizzaStore
    {
        SimplePizzaFactory factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            this.factory = factory;
        }

        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            pizza = factory.CreatePizza(type);
            pizza.create();

            return pizza;
        }

    }
}
