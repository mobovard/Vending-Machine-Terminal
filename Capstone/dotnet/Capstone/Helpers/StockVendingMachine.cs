using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;


namespace Capstone
{
    public static class VendingMachine
    {
        //Stock the Vending Maching
        //Use filePath to read a CSV file then populate a dictionary with Food objects
        public static Dictionary<string, Food> Stock(string filePath)
        {
            Dictionary<string, Food> dictionary = new Dictionary<string, Food>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] foodArray = line.Split("|");

                        string slot = foodArray[0];
                        string name = foodArray[1];
                        decimal price = Convert.ToDecimal(foodArray[2]);
                        string type = foodArray[3];

                        if (type == "Candy")
                        {
                            Food f = new Candy(name, price);
                            dictionary.Add(slot, f);
                        }
                        else if (type == "Chip")
                        {
                            Food f = new Chip(name, price);
                            dictionary.Add(slot, f);
                        }
                        else if (type == "Drink")
                        {
                            Food f = new Drink(name, price);
                            dictionary.Add(slot, f);
                        }
                        else if (type == "Gum")
                        {
                            Food f = new Gum(name, price);
                            dictionary.Add(slot, f);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dictionary;
        }

        //Display the initial prompt to the user
        public static void DisplayPromptToUser()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit\n");
        }

        //Display each item to the user in the format SLOT, NAME, PRICE, QUANTITY
        public static void DisplayItems(Dictionary<string, Food> dictionary)
        {
            foreach (KeyValuePair<string, Food> item in dictionary)
            {
                string slot = item.Key;
                Food food = item.Value;

                if (food.Quantity == 0)
                {
                    Console.WriteLine($"{slot} | {food.Name} | {food.Price} | SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{slot} | {food.Name} | {food.Price} | {food.Quantity}");
                }


            }
        }



    }
}
