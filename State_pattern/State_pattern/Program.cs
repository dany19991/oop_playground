using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //tests :)
            GumballMachine gumballMachine = new GumballMachine(5);

            gumballMachine.gumballMachineStatus();

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            gumballMachine.gumballMachineStatus();

            gumballMachine.insertQuarter();
            gumballMachine.ejectQuarter();
            gumballMachine.turnCrank();

            gumballMachine.gumballMachineStatus();

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.ejectQuarter();

            gumballMachine.gumballMachineStatus();

            gumballMachine.insertQuarter();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            gumballMachine.gumballMachineStatus();
        }
    }
}


public class GumballMachine
{
    static int SOLD_OUT = 0; //nu merge static const , dc ?
    static int NO_QUARTER = 1;
    static int HAS_QUARTER = 2;
    static int SOLD = 3;

    int state = SOLD_OUT;
    int count=0;

    public GumballMachine ( int count)
    {
        this.count = count;
        if (count > 0)
        {
            state = NO_QUARTER;
        }
    }

    public void gumballMachineStatus()
    {
        Console.WriteLine();
        Console.WriteLine("The machine is in state:" + state);
        Console.WriteLine("The machine has " + count + " gumballs left");
        Console.WriteLine();
    }

    public void insertQuarter()
    {
        if(state == HAS_QUARTER)
        {
            Console.WriteLine("You cannot insert another quarter"); 
        }else if (state == NO_QUARTER) {
            state = HAS_QUARTER;
            Console.WriteLine("You inserted a quarter");
        }else if (state == SOLD_OUT){
            Console.WriteLine("You cannot insert a quarter , the machine is sold out");
        }else if (state == SOLD) {
            Console.WriteLine("Wait please, we're already giving you a gumball");
        }
    }

    public void ejectQuarter()
    {
        if (state == HAS_QUARTER)
        {
            Console.WriteLine("quarter returned");
            state = NO_QUARTER;
        }else if (state == NO_QUARTER)
        {
            Console.WriteLine("you haven't insterted a quarter");
        }else if (state == SOLD)
        {
            Console.WriteLine("sorry , you have already turned the crank");
        }else if(state == SOLD_OUT)
        {
            Console.WriteLine("you can't eject , you haven't insterted a quarter yet");
        }
    }

    public void turnCrank()
    {
        if (state == SOLD)
        {
            Console.WriteLine("Turning twice does not get you another gumball");
        }else if (state == NO_QUARTER)
        {
            Console.WriteLine("You turned but there is no quarter");
        }else if (state == SOLD_OUT)
        {
            Console.WriteLine("You turned, but there are no  gumballs");
        }else if (state == HAS_QUARTER)
        {
            Console.WriteLine("You turned ...");
            state = SOLD; // doar in stare sold facem dispense , in restul dam niste mesaje de eroare/informare
            dispense();
        }
    }

    public void dispense()
    {
        if (state == SOLD)
        {
            Console.WriteLine("A gumballs comes rolling out the slot");
            count--;
            if (count <= 0)
            {
                Console.WriteLine("Oops , out of gumballs");
                state = SOLD_OUT;
            }
            else
            { state = NO_QUARTER; }
        }else if (state == NO_QUARTER)
        {
            Console.WriteLine("You have to pay first");
        }else if (state == SOLD_OUT)
        {
            Console.WriteLine("No gumball to be dispensed");
        }else if( state == HAS_QUARTER)
        {
            Console.WriteLine("No gumball dispensed");
        }
    }
    

}