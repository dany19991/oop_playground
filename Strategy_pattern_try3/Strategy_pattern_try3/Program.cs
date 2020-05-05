using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_pattern_try3
{
    class Program
    {
        static void Main(string[] args)
        {
            //user 
            Duck rubberDuck = new RubberDuck();
            rubberDuck.display();
            rubberDuck.fly();
            rubberDuck.quack();
        }
    }

    interface QuackBehaviour //abstract strategy
    {
        void quack();
    }

    interface FlyBehaviour 
    {
        void fly();
    }

    public class NoFly : FlyBehaviour
    {
        public void fly()
        { Console.WriteLine("Cannot fly");}
    }
    public class Fly : FlyBehaviour
    {
        public void fly()
        { Console.WriteLine("Flies away"); }
    }
    public class Squeak : QuackBehaviour
    {
        public void quack()
        { Console.WriteLine("Squeak"); }
    }
    public class Quack : QuackBehaviour
    {
        public void quack()
        { Console.WriteLine("Quack!");}
    }
    public class NoQuack : QuackBehaviour
    {
        public void quack()
        { Console.WriteLine("Silent");}
    }

    abstract class Duck //context ?
    {
        protected QuackBehaviour _quackBehaviour;
        protected FlyBehaviour _flyBehaviour;

        //public abstract void setFlyBehaviour(FlyBehaviour fly); //facem atribuirea direct in constructor
        //{ _flyBehaviour = fly; } //facem abstracta sa obligam specificarea unei behaviour , schimbat, vezi mai sus 

        public void setQuackBehaviour(QuackBehaviour quack) //pentru a putea schimba la runtime
        {_quackBehaviour = quack;}

        public virtual void display() { Console.WriteLine("this is a abstract duck"); }
        public void quack() { if (_quackBehaviour!=null)  _quackBehaviour.quack(); }
        public void fly() { if (_flyBehaviour != null) _flyBehaviour.fly(); }
    }

    class RubberDuck : Duck
    {   
        public RubberDuck()
        {
            _flyBehaviour = new NoFly();
            _quackBehaviour = new Squeak();
        }

        public override void display()
        { Console.WriteLine("This is a rubber duck"); }
    }

    class DecoyDuck : Duck
    {
        //de pus behaviour si aici 
        public override void display()
        { Console.WriteLine("This is a decoy duck"); }
    }

    class MallardDuck : Duck
    {
        //de pus behaviour si aici 
        public override void display()
        { Console.WriteLine("This is a Mallard duck"); }
    }
}
