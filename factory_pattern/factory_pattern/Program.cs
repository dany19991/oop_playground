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
            pizzaStore.OrderPizza("simple");
        }
    }

    public class Pizza
    {
        public string pizzaName = "pizza";

        public void create()
        {
            Console.WriteLine("Created a " + pizzaName);
        }
    }

    public class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            pizzaName = "cheesePizza";
        }

    }

    public class ChicagoCheesePizza :Pizza
    {
        public ChicagoCheesePizza(){
            pizzaName = "ChCheesePizza";
        }

    }

    class NYCheesePizza : Pizza
    {
        public NYCheesePizza (){
            pizzaName = "NYCheesePizza";
        }

    }

    class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;

            switch (type)
            {
                case "cheese":
                    pizza = new NYCheesePizza(); /*new chesee pizza*/
                    break;
                case "simple":
                    pizza = new Pizza();
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
}
