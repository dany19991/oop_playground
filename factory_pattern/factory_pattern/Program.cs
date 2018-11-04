using System;

namespace factory_pattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Pizza {

        public void create() { };
    }


    class SimplePizzaFactory {
        
        public Pizza CreatePizza (string type ){
            Pizza pizza = null; 

            switch (type)
            {
                case "chesee":
                    pizza = new Pizza(); /*new chesee pizza*/
                    break;
            }

            return pizza;
        }
    }

    class PizzaStore {
        SimplePizzaFactory factory;

        public PizzaStore (SimplePizzaFactory factory)
        {
            this.factory = factory;
        }

        public Pizza OrderPizza( string type){
            Pizza pizza;

            pizza = factory.CreatePizza("chesee");
            pizza.create();

            return pizza;
        }


    }
}
