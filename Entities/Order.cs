using OrderItems.Entities.enums;
using System.Globalization;
using System.Text;


namespace OrderItems.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = [];

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem items in Items)
            {
                sum += items.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new ();

            sb.AppendLine("Order moment: " + Moment.ToString());
            sb.AppendLine("Order status: " + Status.ToString());
            sb.AppendLine(Client.ToString());            
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());                
            }            
            sb.AppendLine("Total Price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));            
            
            return sb.ToString();

        }
    }
}
