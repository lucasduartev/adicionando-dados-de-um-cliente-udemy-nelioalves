using Course.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Item { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime date, OrderStatus status, Client client, List<OrderItem> item)
        {
            Date = date;
            Status = status;
            Client = client;
            Item = item;
        }

        public void AddItem(OrderItem item)
        {
            Item.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
        }

        public double Total()
        {
            double sum = 0;

            foreach (OrderItem item in Item)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");

            sb.AppendLine("Order moment: "
                + Date.ToString("dd/MM/yyyy HH:mm:ss"));

            sb.AppendLine("Order status: "
                + Status);

            sb.AppendLine("Client: "
                + Client.Name
                + " ("
                + Client.BirthDate.ToString("dd/MM/yyyy")
                + ") - "
                + Client.Email);

            sb.AppendLine("Order items:");

            foreach (OrderItem item in Item)
            {
                sb.AppendLine(
                    item.Product.Name
                    + ", $"
                    + item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)
                    + ", Quantity: "
                    + item.Quantity
                    + ", Subtotal: $"
                    + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)
                );
            }

            sb.AppendLine("Total price: $"
                + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}