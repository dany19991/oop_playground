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

public interface Quackable:QuackObservable
{
    void quack();
}

public class MallardDuck : Quackable
{
    QuackObservable observable;

    public MallardDuck()
    {
        observable = new Observable(this);
    }

    public void quack()
    {
        Console.WriteLine("Quack");
        notifyObersevers();
    }

    public void registerObserver(Observer observer)
    {
        observable.registerObserver(observer);
    }
    public void notifyObersevers()
    {
        observable.notifyObersevers();
    }
}

public class ReadheadDuck : Quackable
{
    QuackObservable observable;

    public ReadheadDuck()
    {
        observable = new Observable(this);
    }

    public void quack()
    {
        Console.WriteLine("Quack");
        notifyObersevers();
    }

    public void registerObserver(Observer observer)
    {
        observable.registerObserver(observer);
    }
    public void notifyObersevers()
    {
        observable.notifyObersevers();
    }
}

public class DuckCall : Quackable
{
    Observable observable;

    public DuckCall()
    {
        observable = new Observable(this);
    }

    public void quack()
    {
        Console.WriteLine("Kwak");
        notifyObersevers();
    }

    public void registerObserver(Observer observer)
    {
        observable.registerObserver(observer);
    }
    public void notifyObersevers()
    {
        observable.notifyObersevers();
    }
}

public class RubberDuck : Quackable
{
    Observable observable;

    public RubberDuck()
    {
        observable = new Observable(this);
    }
    
    public void quack()
    {
        Console.WriteLine("Squeak");
        notifyObersevers();
    }

    public void registerObserver(Observer observer)
    {
        observable.registerObserver(observer);
    }
    public void notifyObersevers()
    {
        observable.notifyObersevers();
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

        Flock flockOfDucks = new Flock();

        Quackologist quackologist = new Quackologist();
        
        flockOfDucks.add(mallardDuck);
        flockOfDucks.add(redheadDuck);
        flockOfDucks.add(duckCall);
        flockOfDucks.add(rubberDuck);

        //foarte important sa fie dupa ce am adaugat lez ducks ,
        //inregistrarea observerului se face cu interator pt toate lez ducks existente
        flockOfDucks.registerObserver(quackologist); 
        
        Console.WriteLine("Duck Simulator");

        simulate(flockOfDucks);

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

    public void registerObserver(Observer observer)
    {
        throw new NotImplementedException();
    }
    public void notifyObersevers()
    {
        throw new NotImplementedException();
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

    public void registerObserver(Observer observer)
    {
        duck.registerObserver(observer); //important , se ajunge mai intai la decorator si dupa la obiectul efectiv
    }

    public void notifyObersevers()
    {
        duck.notifyObersevers(); //important , se ajunge mai intai la decorator si dupa la obiectul efectiv
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

public class Flock : Quackable
{
    List<Quackable> quackers = new List<Quackable>();

    public void add(Quackable quacker)
    {
        quackers.Add(quacker);
    }
    
    public void quack()
    {
        IEnumerator<Quackable> enumerable = quackers.GetEnumerator();
        while (enumerable.MoveNext())
        {
            Quackable quacker = enumerable.Current;
            quacker.quack();
        }
    }

    public void registerObserver(Observer observer)
    {
        //foarte important as parcurgem si sa face inregistrare la fiecare in parte
        IEnumerator<Quackable> enumerable = quackers.GetEnumerator();
        while (enumerable.MoveNext())
        {
            Quackable quacker = enumerable.Current;
            quacker.registerObserver(observer);
        }
    }
    public void notifyObersevers()
    {
        //observable.notifyObersevers();
    }
}

public interface QuackObservable
{
    void registerObserver(Observer observer);
    void notifyObersevers();
}

public class Observable : QuackObservable
{
    List<Observer> observers = new List<Observer>();
    QuackObservable duck;

    public Observable(QuackObservable duck)
    {
        this.duck = duck;
    }

    public void notifyObersevers()
    {
        //foreach (var observer in observers)
        //{ observer.update(duck); }
        IEnumerator<Observer> enumerable = observers.GetEnumerator();
        while (enumerable.MoveNext())
        {
            Observer observer = enumerable.Current;
            observer.update(duck);
        }
    }

    public void registerObserver(Observer observer)
    {
        observers.Add(observer);
    }
}

public interface Observer
{
    void update(QuackObservable duck);
}

public class Quackologist : Observer
{
    public void update(QuackObservable duck)
    {
        Console.WriteLine("quackologist: " + duck + " just quacked");
    }
}
