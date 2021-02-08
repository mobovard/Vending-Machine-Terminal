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



        //loop through foodDictionary - make sure they're able to purchase the item
        public static void ValidateUserInput(Dictionary<string, Food> foodDictionary, User currentUser, string userSelection, Log log)
        { 
            foreach (KeyValuePair<string, Food> item in foodDictionary)
            {
                string slot = item.Key;
                Food food = item.Value;

                //if the user picks a valid option... 
                if (userSelection == slot)
                {
                    //check inventory
                    if (food.Quantity == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry, item is sold out...");
                        break;
                    }
                    //check the user's balance, make sure they have enough money
                    else if (currentUser.Balance < food.Price)
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry, insufficient funds...\n");
                        break;
                    }
                    //if there's inventory and the user has enough money,
                    //subtract the cost from their balance
                    //decrement the inventory
                    //and dispense the item 
                    else
                    {
                        //before balance for the log message to store the beginning balance
                        decimal beforeBalance = currentUser.Balance;

                        //count number of times the item is purchased
                        food.TimesPurchased();

                        //subtract price from user's balance and decrement food quantity
                        currentUser.Balance -= food.Price;
                        food.Quantity--;                        

                        Console.Clear();
                        Console.WriteLine($"{food.DispenseMessage()} Enjoy your snack, you have ${currentUser.Balance} remaining.\n");

                        // to write log message with date time and before and after balance
                        string date = $"{DateTime.Now:yyyy-MM-dd}";
                        string time = $"{DateTime.Now:HH:mm:ss}";
                        string amOrPm = $"{DateTime.Now:tt}";
                        string logMessage = $"{date} {time} {amOrPm} {food.Name.ToUpper()} {userSelection} ${beforeBalance.ToString("0.00")} ${currentUser.Balance.ToString("0.00")}";
                        log.WriteMessage(logMessage);


                    }
                }
            }
        }



        //Feed money to the user's balance
        public static void FeedMoney(User currentUser, string purchaseScreenInput, Log log)
        {
            //FEED MONEY
            if (purchaseScreenInput == "1")
            {
                Console.Clear();

                //user can add money to their balance
                Console.Write("Please add a whole dollar amount to your balance: ");
                decimal userInput = Convert.ToDecimal(Console.ReadLine());
                decimal currentBalance = currentUser.Balance += (userInput);

                //generate log message
                string date = $"{DateTime.Now:yyyy-MM-dd}";
                string time = $"{DateTime.Now:HH:mm:ss}";
                string amOrPm = $"{DateTime.Now:tt}";
                string logMessage = $"{date} {time} {amOrPm} FEED MONEY: ${userInput.ToString("0.00")} ${currentBalance.ToString("0.00")}";
                log.WriteMessage(logMessage);

                //Allow user to exit and return to purchase prompt
                Console.Clear();
            }
        }



        //Format currentUser.balance to only have 2 decimal places
        public static decimal FormatBalance(User currentUser)
        {
            //Get the balance and format it
            decimal balance = currentUser.Balance;
            string balanceString = balance.ToString("0.00");
            balance = Convert.ToDecimal(balanceString);
            return balance;
        }
    }
}
