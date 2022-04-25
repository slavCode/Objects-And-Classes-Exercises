using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AndreyAndBilliard
{
    internal class Program
    {
        static void Main()
        {
            int entityCount = int.Parse(Console.ReadLine());
            var entities = new Dictionary<string, decimal>();
            CreateShopList(entityCount, entities);

            var clients = new List<Client>();

            string input = Console.ReadLine();
            while (input != "end of clients")
            {
                string[] inputClient = input.Split('-').ToArray();
                string clientName = inputClient[0];
                var productAndQuantity = inputClient[1].Split(',').ToArray();
                string productName = productAndQuantity[0];
                if (entities.ContainsKey(productName))
                {
                    int quantity = int.Parse(productAndQuantity[1]);
                    var products = new Dictionary<string, int>();
                    products.Add(productName, quantity);

                    if (!clients.Any(c => c.Name == clientName))
                    {
                        Client client = new Client();
                        client.Name = clientName;
                        client.Products = products;
                        decimal currPrice = entities[productName];
                        client.Bill = currPrice * quantity;

                        clients.Add(client);
                    }
                    else
                    {
                        foreach (var client in clients)
                        {
                            if (client.Name == clientName)
                            {
                                if (!client.Products.ContainsKey(productName))
                                {
                                    client.Products.Add(productName, quantity);
                                }
                                else client.Products[productName] += quantity;

                                decimal currPrice = entities[productName];
                                client.Bill += currPrice * quantity;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintBill(clients);
        }

        private static void PrintBill(List<Client> clients)
        {
            foreach (var client in clients.OrderBy(c => c.Name))
            {
                Console.WriteLine(client.Name);

                foreach (var product in client.Products)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }

                Console.WriteLine($"Bill: {client.Bill:F2}");
            }

            decimal totalBill = clients.Sum(c => c.Bill);
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }

        private static void CreateShopList(int entityCount, Dictionary<string, decimal> products)
        {
            for (int i = 0; i < entityCount; i++)
            {
                var product = Console.ReadLine().Split('-');
                string productName = product[0];
                decimal price = decimal.Parse(product[1], CultureInfo.InvariantCulture);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName, price);
                }
                else
                {
                    products[productName] = price;
                }
            }
        }
    }
    class Client
    {
        public string Name { get; set; }
        public Dictionary<string, int> Products { get; set; }
        public decimal Bill { get; set; }
    }
}
