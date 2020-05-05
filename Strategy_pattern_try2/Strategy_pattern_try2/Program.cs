using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_pattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            //client
            Context context = new Context();
            Strategy strategy_type1 = new ConctreteStrategy1();
            context.setStrategy(strategy_type1);
            context.doStuff(1);
            Strategy strategy_type2 = new ConctreteStrategy2();
            context.setStrategy(strategy_type2);
            context.doStuff(2);
        }
    }

    class Context 
    {
        private Strategy _strategy;

        public void setStrategy(Strategy strategy)
        {
            _strategy = strategy;
        }
        public void doStuff(int data)
        {
            _strategy.execute(data);
        }
    }

    interface Strategy 
    {
        void execute(int data);        
    }

    class ConctreteStrategy1 : Strategy
    {
        public void execute(int data)
        {
            Console.WriteLine("this is done by strategy1 and data  is : " + data);
        }
    }

    class ConctreteStrategy2 : Strategy
    {
        public void execute(int data)
        {
            Console.WriteLine("this is done by strategy2 and data  is : " + data);
        }
    }

}
