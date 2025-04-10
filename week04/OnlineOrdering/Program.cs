using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Kamen", new Address("33 Kapiolani Blvd", "Honolulu", "T.H", "USA"));
        Customer customer2 = new Customer("Bosco", new Address("600 Dunsmuuir St", "Vancouver", "B.C", "Canada"));


        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Hard Drive", 006, 77.99, 6));
        order1.AddProduct(new Product("Mouse", 091, 13.50, 2));
        order1.AddProduct(new Product("Modem", 092, 10.99, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Printer", 221, 21.99, 1));
        order2.AddProduct(new Product("Laptop", 222, 455.99, 1));


        Console.WriteLine("===== Order 1 =====");
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.OrderCost()}\n");


        Console.WriteLine("===== Order 2 =====");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.OrderCost()}");

    }
}