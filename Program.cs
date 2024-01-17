using OrderItems.Entities;
using OrderItems.Entities.enums;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter client data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        DateTime now = DateTime.Now;

        Console.WriteLine();

        Console.WriteLine("Enter order data: ");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Client client = new Client(name, email, date);
        Order order = new Order(now, status, client);

        Console.WriteLine();

        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data: ");
            Console.Write("Product name: ");
            string prodName = Console.ReadLine();
            Console.Write("Product price: ");
            double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantity: ");
            int prodQuant = int.Parse(Console.ReadLine());

            Product product = new Product(prodName, prodPrice);
            OrderItem item = new OrderItem(prodQuant, prodPrice, product);
            order.AddItem(item);
            Console.WriteLine();

        }
        Console.WriteLine();
        Console.WriteLine("Order Summary: ");
        Console.WriteLine(order);

    }
}