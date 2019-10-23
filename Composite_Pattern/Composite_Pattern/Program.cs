using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuComponent pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
            MenuComponent dinerMenu = new Menu("DINER MENU", "Lunch");
            MenuComponent cafeMenu = new Menu("CAFE MENU", "Dinner");
            MenuComponent dessertMenu = new Menu("DESSERT MENU", "Desser of course");

            MenuComponent allMenus = new Menu("ALL MENUS", "All menus combined");

            allMenus.add(pancakeHouseMenu);
            allMenus.add(dinerMenu);
            allMenus.add(cafeMenu);

            dinerMenu.add(new MenuItem("Pasta","spagheteeee",true,3.99));
            dinerMenu.add(dessertMenu);
            dessertMenu.add(new MenuItem("Some desert1", "some desert1 descr", false, 1.99));
            dessertMenu.add(new MenuItem("Some desert2", "some desert2 descr", false, 2.99));

            Waitress waitress = new Waitress(allMenus);

            waitress.printMenu();

        }
    }
}


public abstract class MenuComponent
{
    public virtual void add(MenuComponent menu)
    {
        //throw new NotImplementedException();
        Console.WriteLine("MenuComponent base class add fct");
    }

    public virtual void remove(MenuComponent menu)
    {
        //throw new NotImplementedException();
        Console.WriteLine("MenuComponent base class remove fct");
    }

    public virtual MenuComponent getChild(int i)
    {
        throw new NotImplementedException();
    }
    
    public virtual string getName()
    {
        throw new NotImplementedException();
    }

    public  virtual string getDescription()
    {
        throw new NotImplementedException();
    }

    public virtual double getPrice()
    {
        throw new NotImplementedException();
    }

    public virtual bool isVegetarian()
    {
        throw new NotImplementedException();
    }

    public virtual void print()
    {
        throw new NotImplementedException();
    }

}

public class MenuItem :MenuComponent
{
    string name;
    string description;
    bool vegetarian;
    double price; 

    public MenuItem(string name , string description , bool vegetarian, double price)
    {
        this.name = name;
        this.description = description;
        this.vegetarian = vegetarian;
        this.price = price;
    }

    public override string getName()
    {
        return name;
    }
    public override string getDescription()
    {
        return description;
    }
    public override bool isVegetarian()
    {
        return vegetarian;
    }
    public override double getPrice()
    {
        return price;
    }

    public override void print()
    {
        Console.Write(" " + getName());
        if(isVegetarian())
        { Console.Write("(v)"); }
        Console.Write(", " + getPrice());
        Console.WriteLine("  --" + getDescription());
    }
}

public class Menu:MenuComponent
{
    List<MenuComponent> menuComponents = new List<MenuComponent>();
    string name;
    string description;

    public Menu (string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public override void add( MenuComponent menuComponent)
    {
        menuComponents.Add(menuComponent);  //add cu A mare pt ca e vb de fct pt lista
    }
    public override void remove(MenuComponent menuComponent)
    {
        menuComponents.Remove(menuComponent);
    }
    public override MenuComponent getChild(int i)
    {
        return menuComponents[i];
    }
    public override string getName()
    {
        return name;
    }
    public override string getDescription()
    {
        return description;
    }

    public override void print()
    {
        Console.WriteLine(" ");
        Console.WriteLine(" "+ getName());
        Console.WriteLine(", "+ getDescription());
        Console.WriteLine("-------------------");
        IEnumerator<MenuComponent> enumerator = menuComponents.GetEnumerator();
        /*  mine :)
        while (enumerator.Current != null)
        {
            MenuComponent menuComponent = enumerator.Current;
            menuComponent.print();
            enumerator.MoveNext();
        }
        */

        while (enumerator.MoveNext())
        {
            MenuComponent menuComponent = enumerator.Current;
            menuComponent.print();
        }
    }
}

public class Waitress
{
    MenuComponent allMenus;

    public Waitress(MenuComponent allMenus)
    {
        this.allMenus = allMenus;
    }
    public void printMenu()
    {
        allMenus.print();
    }

}
