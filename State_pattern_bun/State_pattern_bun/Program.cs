using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_pattern_bun
{
    class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.getStatus();

            gumballMachine.getStatus();

            gumballMachine.insertQuarter();
            gumballMachine.ejectQuarter();
            gumballMachine.turnCrank();

            gumballMachine.getStatus();

            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.ejectQuarter();

            gumballMachine.getStatus();

            gumballMachine.insertQuarter();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();
            gumballMachine.insertQuarter();
            gumballMachine.turnCrank();

            gumballMachine.getStatus();
            
        }
    }
}

public interface State
{
    void insertQuarter();
    void ejectQuarter();
    void turnCrank();
    void dispense();
}

public class GumballMachine
{
    int count=0;
    State state= null;
    NoQarterState noQarterState;
    HasQuarterState hasQuarterState;
    SoldState soldState;
    SoldOutState soldOutState;

    public GumballMachine (int count)
    {
        noQarterState = new NoQarterState(this);
        hasQuarterState = new HasQuarterState(this);
        soldState = new SoldState(this);
        soldOutState = new SoldOutState(this);
        
        this.count = count;

        if (count > 0)
        { setState(noQarterState); }
        else
        { setState(soldOutState); }
    }

    public void insertQuarter()
    {
        state.insertQuarter();
    }

    public void ejectQuarter()
    {
        state.ejectQuarter();
    }

    public void turnCrank()
    {
        state.turnCrank(); //impreuna 
        state.dispense();
    }

    public void setState ( State state)
    { this.state = state; }

    public State getState()
    { return state; }

    public State getHasQuarterState()
    {
        return hasQuarterState;
    }
    public State getNoQuarterState()
    {
        return noQarterState;
    }
    public State getSoldOutState()
    {
        return soldOutState;
    }
    public State getSoldState()
    {
        return soldState;
    }
    
    public void decreaseCount()
    {
        count--;
        if (count <= 0)
        {
            setState(getSoldOutState());
        }else {}
    }

    public void getStatus()
    {
        Console.WriteLine();
        Console.WriteLine("State is: "+getState());
        Console.WriteLine("Count is: " + count);
        Console.WriteLine();
    }
    public int getCount()
    {
        return count;
    }
}

public class SoldState :State
{
    GumballMachine gumballMachine;

    public SoldState (GumballMachine gumballMachine)
    { this.gumballMachine = gumballMachine; }

    public void dispense()
    {
        gumballMachine.decreaseCount();
        Console.WriteLine("Here is your gumball");
        if (gumballMachine.getCount() > 0)
        {
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        }
        else
        {
            gumballMachine.setState(gumballMachine.getSoldOutState());
        }
    }

    public void ejectQuarter()
    {
        Console.WriteLine("Sorry, you already turned the crank");
    }

    public void insertQuarter()
    {
        Console.WriteLine("Please wait , we're already giving you a gumball");
    }

    public void turnCrank()
    {
        Console.WriteLine("Turning twice does not give you another gumball");
    }
}


public class NoQarterState:State
{
    GumballMachine gumballMachine;

    public NoQarterState ( GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void dispense()
    {
        Console.WriteLine("You need to pay first");
    }

    public void ejectQuarter()
    {
        Console.WriteLine("You haven't inserted a quarter");
    }

    public void insertQuarter()
    {
        Console.WriteLine("You inserted a quarter");
        gumballMachine.setState(gumballMachine.getHasQuarterState());
    }

    public void turnCrank()
    {
        Console.WriteLine("You turned but you haven't inserted a quarter");
    }
}

public class HasQuarterState : State
{
    GumballMachine gumballMachine;

    public HasQuarterState(GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void dispense()
    {
        Console.WriteLine("No gumball dispensed");
    }

    public void ejectQuarter()
    {
        Console.WriteLine("Here is your quarter");
        gumballMachine.decreaseCount();
        gumballMachine.setState(gumballMachine.getNoQuarterState());
    }

    public void insertQuarter()
    {
        Console.WriteLine("You have already inserted a quarter");
    }

    public void turnCrank()
    {
        Console.WriteLine("You turned...");
        gumballMachine.setState(gumballMachine.getSoldState());
    }
}

public class SoldOutState : State
{
    GumballMachine gumballMachine;
    public SoldOutState( GumballMachine gumballMachine)
    {
        this.gumballMachine = gumballMachine;
    }

    public void dispense()
    {
        Console.WriteLine("There are no gumballs to dispense");
    }

    public void ejectQuarter()
    {
        Console.WriteLine("You cannot eject , you haven't inserted a quarter yet");
    }

    public void insertQuarter()
    {
        Console.WriteLine("You cannot insert a quarter, the machine is sold out");
    }

    public void turnCrank()
    {
        Console.WriteLine("You turned but there are no gumballs");
    }
}