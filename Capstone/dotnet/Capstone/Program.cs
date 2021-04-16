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
            //use filePath to create a dictionary<slot, Food>
            string filePath = @"C:\Users\Student\workspace\module1-capstone-c-team-4\Example Files\Inventory.txt";

            Dictionary<string, Food> foodDictionary = VendingMachine.Stock(filePath);

            string userInput = "";
            bool running = true;


            while (running)
            {
                //instantiate a user that has a Balance property
                User currentUser = new User();


                //use logpath to create a new log class
                string logPath = @"C:\Users\Student\workspace\module1-capstone-c-team-4\module1-capstone-c-team-4\Capstone\dotnet\Capstone\Logs\Log.txt";


                //construct log class
                Log log = new Log(logPath);

                //prompt the user
                VendingMachine.DisplayPromptToUser();

                //capture users response
                userInput = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (userInput)
                {
                    //View Vending Machine options
                    case "1":
                        {
                            while (userInput != "e")
                            {
                                //Display vending machine items
                                VendingMachine.DisplayItems(foodDictionary);
                                Console.WriteLine();

                                //Allow user to exit and return to main prompt
                                Console.Write("Press e to exit: ");
                                userInput = Console.ReadLine();

                                Console.Clear();
                            }

                            break;
                        }

                    //Purchase
                    case "2":
                        {

                            while (userInput == "2")
                            {


                                //PURCHASE SCREEN
                                Console.WriteLine("(1) Feed Money");
                                Console.WriteLine("(2) Select Product");
                                Console.WriteLine("(3) Finish Transaction");
                                Console.WriteLine($"Current Money Provided: ${currentUser.Balance}\n");

                                string purchaseScreenInput = Console.ReadLine();
                                Console.WriteLine();

                                //allow user to FEED MONEY to their balance
                                VendingMachine.FeedMoney(currentUser, purchaseScreenInput, log);

                                //SELECT PRODUCT
                                while (purchaseScreenInput == "2")
                                {
                                    Console.Clear();

                                    //Display items to user
                                    VendingMachine.DisplayItems(foodDictionary);
                                    Console.WriteLine();

                                    //prompt user to select an item
                                    Console.Write("Please enter the slot code of the item you want: ");
                                    string userSelection = Console.ReadLine();

                                    //check that the user selection is in the vending machine
                                    if (foodDictionary.ContainsKey(userSelection))
                                    {
                                        //make sure the user is able to purchase an item
                                        VendingMachine.ValidateUserInput(foodDictionary, currentUser, userSelection, log);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Sorry, item not found...\n");
                                        break;
                                    }

                                    break;
                                }
                                //FINISH TRANSACTION
                                while (purchaseScreenInput == "3")
                                {
                                    decimal beforeBalance = currentUser.Balance;
                                    //Format balance to only have 2 decimal places
                                    decimal balance = VendingMachine.FormatBalance(currentUser);

                                    //Make balance a whole number
                                    balance *= 100;

                                    double numberOfQuarters = 0;
                                    double numberOfDimes = 0;
                                    double numberOfNickels = 0;

                                    while (balance > 25)
                                    {
                                        balance -= 25;
                                        numberOfQuarters++;
                                    }

                                    while (balance > 10)
                                    {
                                        balance -= 10;
                                        numberOfDimes++;
                                    }

                                    while (balance > 0)
                                    {
                                        balance -= 5;
                                        numberOfNickels++;
                                    }

                                    Console.Clear();
                                    currentUser.Balance = balance;

                                    Console.WriteLine($"Here's your change: {numberOfQuarters} Quarter(s), {numberOfDimes} Dime(s), and {numberOfNickels} Nickel(s)\n");

                                    //writing log message after giving change
                                    string date = $"{DateTime.Now:yyyy-MM-dd}";
                                    string time = $"{DateTime.Now:HH:mm:ss}";
                                    string amOrPm = $"{DateTime.Now:tt}";
                                    string logMessage = $"{date} {time} {amOrPm} GIVE CHANGE: ${beforeBalance.ToString("0.00")} ${balance.ToString("0.00")}";
                                    log.WriteMessage(logMessage);



                                    //switching userInput allows the program to get out of switch: "2"
                                    userInput = "";

                                    break;
                                }

                            }
                            break;
                        }

                    //Exit
                    case "3":
                        {
                            running = false;
                            break;
                        }

                    //Hidden option, Sales Report
                    case "4":
                        {
                            //Define totalSales and format to only have 2 places after the decimal
                            decimal totalSales = 0;
                            string totalSalesString = totalSales.ToString("0.00");
                            totalSales = Convert.ToDecimal(totalSalesString);

                            //Format date and time to be used in the sales report file name
                            string date = $"{DateTime.Now:yyyy-MM-dd}";
                            string time = $"{DateTime.Now:HH-mm-ss}";

                            //get directory and create the full path
                            string directory = $@"C:\Users\Student\workspace\module1-capstone-c-team-4\module1-capstone-c-team-4\Capstone\dotnet\Capstone\SalesReports";
                            string fullFilePath = Path.Combine(directory, @$"{date}_{time}.txt");

                            //Loop through each item foodDictionary to create a sales report with the item name and # of times it was purchased
                            foreach (KeyValuePair<string, Food> item in foodDictionary)
                            {
                                Food food = item.Value;
                                totalSales += (food.Price * food.NumberOfTimesPurchased);

                                string report = $"{food.Name}|{food.NumberOfTimesPurchased}";

                                try
                                {
                                    using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                                    {
                                        sw.WriteLine(report);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }

                            try
                            {
                                //Finally, add the total sales to the bottom of the sales report
                                using (StreamWriter sw = new StreamWriter(fullFilePath, true))
                                {
                                    sw.WriteLine($"\n**TOTAL SALES** ${totalSales}");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            break;
                        }
                }
            }
        }
    }
}

