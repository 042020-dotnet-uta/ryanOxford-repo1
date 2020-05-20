using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            CalculatorClient client = new CalculatorClient();
            var Fruits = client.CreateList();
            // Step 2: Call the service operations.
            // Call the Add service operation.
            Console.WriteLine("List of fruits:");
            foreach (var f in Fruits)
            {
                Console.WriteLine(f.Name);
            }
            Fruits = client.AddToList(Fruits, "Raspberry");


            var fruit = client.ExtractFromList(Fruits,"Banana");
            Console.WriteLine("Extracted fruit: " + fruit.Name);
            Console.WriteLine("New List State:");
            foreach (Fruit f in Fruits)
            {
                Console.WriteLine(f.Name);
            }

            Console.WriteLine("Count of items in list: " + client.CountList(Fruits));


            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            client.Close();
        }
    }
}