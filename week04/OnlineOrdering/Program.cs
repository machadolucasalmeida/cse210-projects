using System;
using System.Collections.Generic; // Required for List<T>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Online Ordering Program Output ---");
        Console.WriteLine("====================================\n");

        Console.WriteLine("--- Order 1 Details ---");
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", "LAP-001", 1200.00, 1),
            new Product("Wireless Mouse", "ACC-005", 25.50, 2)
        };

        Order order1 = new Order(products1, customer1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Order Cost: ${order1.GetTotalOrderCost():F2}\n");

        Console.WriteLine("--- Order 2 Details ---");
        Address address2 = new Address("45 Rue de la Paix", "Paris", "Ile-de-France", "France");
        Customer customer2 = new Customer("Marie Dubois", address2);

        List<Product> products2 = new List<Product>
        {
            new Product("Headphones", "AUD-010", 150.00, 1),
            new Product("USB-C Cable", "CAB-003", 10.00, 3),
            new Product("Portable Charger", "PWR-020", 40.00, 1)
        };

        Order order2 = new Order(products2, customer2);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Order Cost: ${order2.GetTotalOrderCost():F2}\n");

        Console.WriteLine("====================================");
        Console.WriteLine("Program execution complete.");
    }
}