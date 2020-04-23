using System;
using System.Collections.Concurrent;

namespace factory_pattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PizzaStore NYpizzaStore = new NYPizzaStore();
            Pizza pizza  = NYpizzaStore.orderPizza("cheese");
            PizzaStore ChpizzaStore = new ChPizzaStore();
            Pizza pizza1 = ChpizzaStore.orderPizza("greek");

        }
    }

    public abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza =createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        public abstract Pizza createPizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;

            if (type.Equals("cheese"))
            {
                pizza = new NYCheesePizza();
            }
            else if (type.Equals("greek"))
            {
                pizza = new NYGreekPizza();
            }
            else
            {
                pizza = new NYPizza();
            }

            return pizza;
        }
    }

    public class ChPizzaStore : PizzaStore
    {
        public override Pizza createPizza(string type)
        {
            Pizza pizza = null;

            if (type.Equals("cheese"))
            {
                pizza = new ChCheesePizza();
            }
            else if (type.Equals("greek"))
            {
                pizza = new ChGreekPizza();
            }
            else
            {
                pizza = new ChPizza();
            }

            return pizza;
        }
    }


    public class Pizza
    {
        public virtual void prepare() {Console.WriteLine("classic pizza"); } 
        //daca vreau sa suprascriu o functie in clasele derivate 
        //trebuie sa fie cel putin virtuala (poate avea implmenetare si in clasa de baza
        public void bake() { }
        public void cut() { }
        public void box() { }
    }

    public class CheesePizza : Pizza
    {
        public override void prepare() { Console.WriteLine("cheese pizza");}
    }

    public class GreekPizza : Pizza
    {
        public override void prepare() { Console.WriteLine("classic greek pizza"); }
    }
    public class NYPizza :Pizza
    {
        public override void prepare() { Console.WriteLine("NY pizza"); }
    }

    public class NYCheesePizza : Pizza
    {
        public override void prepare() { Console.WriteLine("NY cheese pizza"); }
    }

    public class NYGreekPizza : Pizza
    {
        public override void prepare() { Console.WriteLine("NY greek pizza"); }
    }
        public class ChPizza :Pizza
    {
        public override void prepare() { Console.WriteLine("Chicago pizza"); }
    }

    public class ChCheesePizza : Pizza
    {
        public override void prepare() { Console.WriteLine("Chicago cheese pizza"); }
    }

    public class ChGreekPizza : Pizza
    {
        public override void prepare() { Console.WriteLine("Chicago greek pizza"); }
    }

}
