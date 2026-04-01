using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Creating customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Jane Doe", address2);

        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product(1, "Laptop", 999.99m, 1));
        order1.AddProduct(new Product(2, "Mouse", 29.99m, 2));
        order1.AddProduct(new Product(3, "Keyboard", 49.99m, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product(4, "Monitor", 299.99m, 1));
        order2.AddProduct(new Product(5, "Webcam", 79.99m, 2));

        Console.WriteLine("=== Order 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total: ${order1.CalculateTotal():F2}\n");

        Console.WriteLine("=== Order 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.CalculateTotal():F2}");
    }
}