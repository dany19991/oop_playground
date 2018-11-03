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
        {//0.4f
            Beverage houseBlend = new HouseBlend(); //nu merge daca obiectul creat e de tipul HouseBlend -> 
                                    //nu poate fi folosit in condiment decorator ....care primeste generic Beverage
            Console.WriteLine("Pret : "+ houseBlend.Cost());
            Console.WriteLine(houseBlend.getDescription());

            houseBlend = new Mocha(houseBlend);//0.3f
            houseBlend = new Milk(houseBlend);//0.2f

            Console.WriteLine(houseBlend.Cost());
            Console.WriteLine(houseBlend.getDescription());
        }
    }
    
    abstract class Beverage
    {
        public abstract string getDescription();
        public abstract float Cost();
    }
    
    class HouseBlend : Beverage
    {
        string descriptiontxt = "HouseBlend";


        public override float Cost()
        {
            return 0.4f;
        }

        public override string getDescription()
        {
            return descriptiontxt;
        }
    }

    class Expresso : Beverage
    {
        string descriptiontxt = "Expresso";
        public override float Cost()
        {
            return 0.4f;
        }

        public override string getDescription()
        {
            return descriptiontxt;
        }
    }

    abstract class  CondimentDecorator : Beverage
    {
        //public abstract override string getDescription();
        //public abstract override float Cost();
    }

    class Mocha : CondimentDecorator
    {
        public Beverage beverage;

        public Mocha( Beverage beverage_)
        {
            this.beverage = beverage_;
        }

        public override float Cost()
        {
            return 0.3f + beverage.Cost();
        }

        public override string getDescription()
        {
            return beverage.getDescription()+",mocha";
        }
    }

    class Milk : CondimentDecorator
    {
       public  Beverage beverage;

        public Milk(Beverage beverage_)
        {
            this.beverage = beverage_;
        }

        public override float Cost()
        {
            return 0.2f + beverage.Cost();
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ",milk";
        }
    }
    //comment to test older commit message change

    //second edit . new commit
}
