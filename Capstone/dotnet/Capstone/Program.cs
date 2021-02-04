using System;
using System.IO;
using System.Collections.Generic;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Student\workspace\module1-capstone-c-team-4\Example Files\Inventory.txt"; 
            Dictionary<string, Food> foodDictionary = StockVendingMachine.Stock(filePath);

            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine();

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                DisplayItems(foodDictionary);
            }
            else if (userInput == "2")
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                //TODO make dynamic
                Console.WriteLine("Current Money Provided: 0");
            }
        }

        public static void DisplayItems(Dictionary<string, Food> dictionary)
        {
            foreach (KeyValuePair<string, Food> item in dictionary)
            {
                string slot = item.Key;
                Food food = item.Value;

                Console.WriteLine($"{slot}|{food.Name}|{food.Price}|{food.Quantity}");
            }
        }
    }
}
