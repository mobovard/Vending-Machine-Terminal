using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;


namespace Capstone
{
    public static class StockVendingMachine
    {
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
          

    }
}
