using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compound_pattern_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DuckSimulator duckSimulator = new DuckSimulator();
            AbstractDuckFactory duckFactory = new DuckCountingFactory();
            duckSimulator.simulate(duckFactory);
        }
    }
}

public interface Quackable
{
    void quack();
}

public class MallardDuck : Quackable
{
    public void quack()
    {
        Console.WriteLine("Quack");
    }
}

public class ReadheadDuck : Quackable
{
    public void quack()
    {
        Console.WriteLine("Quack");
    }
}

public class DuckCall : Quackable
{
    public void quack()
    {
        Console.WriteLine("Kwak");
    }
}

public class RubberDuck : Quackable
{
    public void quack()
    {
        Console.WriteLine("Squeak");
    }
}

public class DuckSimulator
{
    public void simulate( AbstractDuckFactory duckFactory)
    {
        Quackable mallardDuck = duckFactory.createMallardDuck();
        Quackable redheadDuck = duckFactory.createRedheadDuck();
        Quackable duckCall = duckFactory.createDuckCall();
        Quackable rubberDuck = duckFactory.createRubberDuck();
        Goose goose = new Goose();
        Quackable gooseAdapter = new GooseAdapter(goose);

        Console.WriteLine("Duck Simulator");

        simulate(mallardDuck);
        simulate(redheadDuck);
        simulate(duckCall);
        simulate(rubberDuck);
        simulate(gooseAdapter);

        Console.WriteLine(" The ducks quacked " + QuackCounter.getQaucks() + " times");
    }

    void simulate(Quackable duck)
    {
        duck.quack();
    }
}

public class Goose
{
    public void honk()
    {
        Console.WriteLine("Honk");
    }
}

public class GooseAdapter : Quackable
{
    Goose goose;

    public GooseAdapter(Goose goose)
    {
        this.goose = goose;
    }

    public void quack()
    {
        goose.honk();
    }
}

public class QuackCounter : Quackable
{
    Quackable duck;
    static int numberOfQuacks;

    public QuackCounter(Quackable duck)
    {
        this.duck = duck;
    }

    public void quack()
    {
        duck.quack();
        numberOfQuacks++;
    }

    public static int getQaucks()
    {
        return numberOfQuacks;
    }
}

public abstract class AbstractDuckFactory
{
    public abstract Quackable createMallardDuck();
    public abstract Quackable createRedheadDuck();
    public abstract Quackable createDuckCall();
    public abstract Quackable createRubberDuck();
}

public class DuckFactory : AbstractDuckFactory
{
    public override Quackable createMallardDuck()
    {
        return new MallardDuck();
    }

    public override Quackable createRedheadDuck()
    {
        return new ReadheadDuck();
    }

    public override Quackable createDuckCall()
    {
        return new DuckCall();
    }

    public override Quackable createRubberDuck()
    {
        return new RubberDuck();
    }
}

public class DuckCountingFactory : AbstractDuckFactory
{
    public override Quackable createMallardDuck()
    {
        return new QuackCounter(new MallardDuck());
    }

    public override Quackable createRedheadDuck()
    {
        return new QuackCounter(new ReadheadDuck());
    }

    public override Quackable createDuckCall()
    {
        return new QuackCounter(new DuckCall());
    }

    public override Quackable createRubberDuck()
    {
        return new QuackCounter(new RubberDuck());
    }
}

