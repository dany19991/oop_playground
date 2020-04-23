using System;
using System.Collections.Concurrent;

namespace factory_pattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SimplePizzaFactory simplePizzaFactory = new SimplePizzaFactory();
            PizzaStore pizzaStore = new PizzaStore(simplePizzaFactory);
            Pizza pizza  = pizzaStore.orderPizza("cheese");
        }
    }


    public class PizzaStore
    {
        SimplePizzaFactory simplePizzaFactory;

        public PizzaStore (SimplePizzaFactory simplePizzaFactory_)
        { simplePizzaFactory = simplePizzaFactory_; }

        public Pizza orderPizza(string type)
        {
            Pizza pizza = simplePizzaFactory.createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }

    public class SimplePizzaFactory
    {
        public Pizza createPizza(string type)
        {
            Pizza pizza = null;

            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza();
            }
            else if (type.Equals("greek"))
            {
                pizza = new GreekPizza();
            }
            else
            {
                pizza = new Pizza();
            }

            return pizza;
        }
    }
    public  class Pizza
    {
        public void prepare() { }
        public void bake() { }
        public void cut() { }
        public void box() { }
    }

    public class CheesePizza : Pizza
    { }

    public class GreekPizza : Pizza
    { }
    
}
