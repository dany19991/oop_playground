using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategy_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Rubberduck rubberduck = new Rubberduck();
            rubberduck.performFly();
            
        }
    }

    class Duck
    {
        public FlyBehaviour flyBehaviour;

        void quack()
        {
            Console.WriteLine("main duck class quack");
        }
        public void performFly()
        {
            //    Console.WriteLine("main duck class fly");
            flyBehaviour.fly();
        }
        void display()
        {
            Console.WriteLine("this is a main class duck");
        }   
    }

    interface FlyBehaviour
    {
        void fly();
    }
    
    class NoFly : FlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("no fly");
        }
    }

    class Rubberduck : Duck
    {
        public Rubberduck()
        {
            flyBehaviour = new NoFly();   
        }


    }
}
