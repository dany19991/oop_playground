using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage houseBlend = new HouseBlend(); //nu merge daca obiectul creat e de tipul HouseBlend -> 
                                    //nu poate fi folosit in condiment decorator ....care primeste generic Beverage
            Console.WriteLine("Pret : "+ houseBlend.Cost());

            houseBlend = new Mocha(houseBlend);

        }
    }

    class Beverage
    {
        string description = "None";

        public string getDescription()
        {
            return description;
        }

        public float Cost()
        {
            return 0.5f;
        }
    }

    class HouseBlend : Beverage
    {
        public new string getDescription()
        {
            return "HouseBlend";
        }

        public new float Cost()
        {
            return 0.2f ;
        }
    }

    class Expresso : Beverage
    {
        public new string getDescription()
        {
            return "Expresso";
        }

        public new float Cost()
        {
            return 0.1f ;
        }
    }

    abstract class  CondimentDecorator : Beverage
    {
        public abstract float Cost();
    }

    class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha( Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override float Cost()
        {
            return 0.3f + beverage.Cost();
        }
    }

    class Milk : CondimentDecorator
    {
        Beverage beverage;

        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override float Cost()
        {
            return 0.2f + beverage.Cost();
        }
    }

}
