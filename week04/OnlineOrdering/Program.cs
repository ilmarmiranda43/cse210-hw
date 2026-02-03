using System;

class Program
{
    static void Main(string[] args)
    {
        // Order #1 (USA)
        Address address1 = new Address("123 Main St", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Jordan Miller", address1);

        Order order1 = new Order(customer1);
        order1.AddItem(new Product("Wireless Mouse", "WM-104", 19.99m, 2));
        order1.AddItem(new Product("Keyboard", "KB-220", 34.50m, 1));

        PrintOrder(order1);

        // Order #2 (International)
        Address address2 = new Address("Avenida Paulista, 1000", "Sao Paulo", "SP", "Brazil");
        Customer customer2 = new Customer("Taylor Souza", address2);

        Order order2 = new Order(customer2);
        order2.AddItem(new Product("Notebook", "NB-777", 8.25m, 5));
        order2.AddItem(new Product("Pen Set", "PN-019", 3.40m, 3));
        order2.AddItem(new Product("Desk Lamp", "DL-500", 22.00m, 1));

        PrintOrder(order2);
    }

    private static void PrintOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"TOTAL: ${order.GetTotalCost():0.00}");
        Console.WriteLine("\n=================================\n");
    }
}
