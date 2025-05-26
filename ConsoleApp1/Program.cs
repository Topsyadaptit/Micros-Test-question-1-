using System;
using System.Collections.Generic;

// Base class representing a general menu item
class MenuItem
{
    // Name of the menu item
    public string Name { get; set; }

    public decimal Price { get; set; }

    // Constructor to initialize name and price
    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    // Virtual method to get item details
    // we use the "virtual" to allow the code to override this method in future when we want the derived classes to insert additional informartion
    public virtual string GetDetails()
    {
        return $"{Name} - R{Price:F2}";
    }
}

// Derived class representing a food item
class FoodItem : MenuItem
{
    // Indicates whether the food is spicy
    //before we can display whether or not the food is spicy we have to GET the answer then SET the answer
    public bool IsSpicy { get; set; }

    // Constructor to initialize name, price, and spiciness
    public FoodItem(string name, decimal price, bool isSpicy)
        : base(name, price)
    {
        IsSpicy = isSpicy;
    }

    // Override to include spicy info in details
    public override string GetDetails()
    {
        return $"{base.GetDetails()} | Spicy: {(IsSpicy ? "Yes" : "No")}";
    }
}

// Derived class representing a beverage item
class BeverageItem : MenuItem
{
    // Indicates whether the beverage is cold
    public bool IsCold { get; set; }

    // Constructor to initialize name, price, and temperature
    public BeverageItem(string name, decimal price, bool isCold)
        : base(name, price)
    {
        IsCold = isCold;
    }

    // Override to include cold/hot info in details
    public override string GetDetails()
    {
        return $"{base.GetDetails()} | Cold: {(IsCold ? "Yes" : "No")}";
    }
}

// Class representing an order containing menu items
class Order
{
    // List to store the ordered items
    //create a list to store menu items 

    private List<MenuItem> items = new List<MenuItem>();
    private decimal total;

    // Method to add an item to the order
    public void AddItem(MenuItem item)//this in the brackets tells the method what items were getting
    {
        items.Add(item);
    }

    // Method to print all order details and total cost
    public void PrintOrder()
    {
         total = 0;

        Console.WriteLine("Order Summary:");
        Console.WriteLine("--------------");

        // Loop through each item and print details
        foreach (var item in items)
        {
            Console.WriteLine(item.GetDetails());
            total += item.Price;
        }

        Console.WriteLine("--------------");
        Console.WriteLine($"Total: R{total:F2}");
    }

    //create method to inform customers about a special if they spend over a certain amount
    public void Discount()
    {
        if (total < 15.99m)
        {
            Console.WriteLine("You qualify for the 20% off special!");
        }
        else
        {
            Console.WriteLine("Spend R25 to get 20% off!");
        }
    }
}

// Main class to run the program
class Program
{
    static void Main(string[] args)
    {
        // Create a spicy food item
        FoodItem food = new FoodItem("Spicy Chicken Wings", 8.99m, true);

        FoodItem Burger = new FoodItem("Vegan Royale Burger", 9.99m, false);

        // Create a cold beverage item
        BeverageItem drink = new BeverageItem("Iced Lemonade", 3.50m, true);

        // Create an order and add items to it
        Order order = new Order();
        order.AddItem(food);
        order.AddItem(Burger);
        order.AddItem(drink);

        // Print the order summary
        order.PrintOrder();
        order.Discount();

        
    }
}
