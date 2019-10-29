﻿using System;
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
            duckSimulator.simulate();

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
    public void simulate()
    {
        Quackable mallardDuck = new MallardDuck();
        Quackable redheadDuck = new ReadheadDuck();
        Quackable duckCall = new DuckCall();
        Quackable rubberDuck = new RubberDuck();
        Goose goose = new Goose();
        Quackable gooseAdapter = new GooseAdapter(goose);

        Console.WriteLine("Duck Simulator");

        simulate(mallardDuck);
        simulate(redheadDuck);
        simulate(duckCall);
        simulate(rubberDuck);
        simulate(gooseAdapter);
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