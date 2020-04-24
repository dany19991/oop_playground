using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace factory_pattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PizzaStore NYPizzaStore = new NYPizzaStore();
            Pizza pizza  = NYPizzaStore.orderPizza("cheese");
            System.Console.WriteLine(pizza.Name);
            PizzaStore ChPizzaStore = new ChPizzaStore();
            Pizza pizza1 = ChPizzaStore.orderPizza("greek");
        }
    }

    public class Dough { }
    public class Sauce { }
    public class Topping { }
    public class Pepperoni : Topping { }
    public class Jalpenio: Topping { }


    public interface IngredientsAbstractFactory
    {
        public Dough createDough();
        public Sauce createSauce();
        public Topping[] createToppings();
    }

    public class NYIngredients : IngredientsAbstractFactory //
    {
        public Dough createDough()
        { return new Dough(); //poate fi extins, sa fie un tip de aluat special
        }
        public Sauce createSauce()
        { return new Sauce();
        }
        public Topping[] createToppings()
        {
            Topping[] toppings = { new Topping(),new Jalpenio(), new Pepperoni() };
            return toppings;
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
            IngredientsAbstractFactory ingredientsAbstractFactory = new NYIngredients();
            
            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientsAbstractFactory);
                pizza.Name = "NY " + pizza.Name;
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


    public abstract class Pizza
    {
        private String name;
        protected Dough dough;
        protected Sauce sauce;
        protected Topping[] toppings;

        public string Name { get => name; set => name = value; }

        public abstract void prepare();// {Console.WriteLine("classic pizza"); } 
        //daca vreau sa suprascriu o functie in clasele derivate 
        //trebuie sa fie cel putin virtuala (poate avea implmenetare si in clasa de baza
        public void bake() { }
        public void cut() { }
        public void box() { }
    }

    public class CheesePizza : Pizza
    {
        IngredientsAbstractFactory ingredientsAbstractFactory; //controlez din factory ce ingrediente sa contina, si factory zice pt ce zona 
        //astfel nu mai trebuie cate un tip de cheese pizza pentru fiecare oras 
        public CheesePizza (IngredientsAbstractFactory ingredientsAbstractFactory_)
        { ingredientsAbstractFactory = ingredientsAbstractFactory_; }
        public override void prepare() { 
            Name = "cheese pizzaa";
            dough = ingredientsAbstractFactory.createDough();
            sauce = ingredientsAbstractFactory.createSauce();
            toppings = ingredientsAbstractFactory.createToppings();
        }
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
