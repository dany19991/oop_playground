using System;
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
    public List<MenuItem> getMenuItems()
    {
        return menuItems;
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

        addItem("vegetarian soup", "vegetables soup", true, 5.99);
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

    public MenuItem[] getMenuItems()
    {
        return menuItems;
    }

}

public class Alice
{
    //printMenu()
    //printBrakfastMenu()
    //printLunchMenu()
    //printVegetarianMenu()
    //isItemVegetarian(name)
    PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
    DinerMenu diner = new DinerMenu();


    public void printMenu()
    {
        
    }
}