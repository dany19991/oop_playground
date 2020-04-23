using System;
using System.Collections.Concurrent;

namespace factory_pattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
        }
        Pizza orderPizza(string type)
        {
            Pizza pizza;

            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza();
            }else if (type.Equals("greek"))
            {
                pizza = new GreekPizza();
            } else 
            {
                pizza = new Pizza();
            }

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }

    class Pizza
    {
        public void prepare() { }
        public void bake() { }
        public void cut() { }
        public void box() { }
    }

    class CheesePizza : Pizza
    { }

    class GreekPizza : Pizza
    { }
    
}
