using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml;
using System.Collections.Generic; 
using System.Diagnostics.Contracts;
using Course.Entities;
using Course.Entities.Enums;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Birth date (DD/MM/YYYY)");
            DateTime birthDate = DateTime.Parse(Console.ReadLine()!);

            Client client = new Client();
            client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()!);

            Order order = new Order(DateTime.Now, status , client , new List<OrderItem>());

            Console.WriteLine();
            Console.Write("Hom many items to this order?: ");
            int nContagens = int.Parse(Console.ReadLine()! , CultureInfo.InvariantCulture);
            for (int i = 0; i < nContagens; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data:");
                Console.Write("Product name: ");
                string nameItem = Console.ReadLine()!;

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine()! , CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine()!);
                
                Product product = new Product(nameItem , productPrice);

                OrderItem item = new OrderItem(quantity , product);

                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine(order.ToString());
        }
    }
}