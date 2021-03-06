﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iterator_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();
            Waitress waitress = new Waitress(pancakeHouseMenu,dinerMenu);

            waitress.printMenu();
            Console.ReadKey();
        }
    }
}

public class MenuItem
{
    String name;
    String description;
    Boolean vegetarian;
    double price;

    public MenuItem(String name,
        String description,
        Boolean vegetarian,
        double price
        )
    {
        this.name = name;
        this.description = description;
        this.vegetarian = vegetarian;
        this.price = price;
    }

    public String getName()
    { return name; }

    public String getDescription()
    { return description; }

    public double getPrice()
    { return price; }

    public Boolean isVegetarian()
    { return vegetarian; }
}

public class PancakeHouseMenu
{
    List<MenuItem> menuItems;
    
    public PancakeHouseMenu()
    {
        menuItems = new List<MenuItem>();
        
        addItem("pancake1","pancake1 description",false,2.99);
        addItem("pancake2", "pancake2 description", true, 1.99);
        addItem("waffles", "waffles description", true, 3.59);
    }

    public void addItem (String name ,String description, Boolean vegetarian, double price)
    {
        menuItems.Add(new MenuItem(name,description,vegetarian,price));
    }
    /*
    public List<MenuItem> getMenuItems()
    {
        return menuItems;
    }
    */

    public Iterator createIterator()
    {
       return new PancakeMenuIterator(menuItems);
     
    }

}

public class DinerMenu
{
    const int MAX_ITEMS = 6;
    int numberOfItems = 0;
    MenuItem[] menuItems;

    public DinerMenu()
    {
        menuItems = new MenuItem[MAX_ITEMS];

        addItem("vegetarian soup", "vegetables soup", true, 4.99);
        addItem("meat soup", "meat soup", false, 5.99);
    }

    public void addItem ( String name, String description, Boolean vegetarian, double price)
    {
        MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
        if (numberOfItems >= MAX_ITEMS)
        {
            Console.WriteLine("error. trying to add more than the max number of menuitems");
        }
        else
        {
            menuItems[numberOfItems] = menuItem;
            numberOfItems++;
        }
    }

    /*
    public MenuItem[] getMenuItems()
    {
        return menuItems;
    }
    */

    public Iterator createIterator ()
    {
        return new DinerMenuIterator(menuItems);
    }

}

public class Waitress
{
    //printMenu()
    //printBrakfastMenu()
    //printLunchMenu()
    //printVegetarianMenu()
    //isItemVegetarian(name)
    PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
    DinerMenu dinerMenu = new DinerMenu();

    public Waitress (PancakeHouseMenu pancakeHouseMenu , 
                        DinerMenu dinerMenu)
    {
        this.pancakeHouseMenu = pancakeHouseMenu;
        this.dinerMenu = dinerMenu;
    }
    
    public void printMenu()
    {
        Iterator dinerIterator = dinerMenu.createIterator();
        Iterator pancakeIterator = pancakeHouseMenu.createIterator();
        Console.WriteLine("Pancake menu : ");
        printMenu(pancakeIterator);
        Console.WriteLine("Diner Menu : ");
        printMenu(dinerIterator);
    }

    private void printMenu(Iterator iterator)
    {
        while ( iterator.hasNext())
        {
            MenuItem menuItem = (MenuItem)iterator.next();
            Console.WriteLine(menuItem.getName());
            Console.WriteLine(menuItem.getDescription());
            Console.WriteLine(menuItem.getPrice().ToString());
        }
    }
}

public interface Iterator
{
    Boolean hasNext();
    Object next();
}

public class DinerMenuIterator : Iterator
{
    MenuItem[] items;
    int position = 0;

    public DinerMenuIterator(MenuItem[] items)
    {
        this.items = items;
    }

    public bool hasNext()
    {
        if (position >= items.Length || items[position] == null)
            return false;
        else
            return true;
    }

    public object next()
    {
        MenuItem menuItem = items[position];
        position++;
        return menuItem;
    }
}

public class PancakeMenuIterator : Iterator
{
    List<MenuItem> items;
    int position = 0;

    public PancakeMenuIterator( List<MenuItem> items)
    {
        this.items = items;
    }

    public bool hasNext()
    {
        if (position>=items.Count || items[position] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public object next()
    {
        MenuItem item = items[position];
        position++;
        return item;
    }
}