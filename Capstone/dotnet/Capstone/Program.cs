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
            string userInput = "";

            while (userInput != "3")
            {
                //use filePath to create a dictionary<slot, Food>
                string filePath = @"C:\Users\Student\workspace\TestCapstone\dont_push-module1-capstone-c-team-4\Capstone\dotnet\Capstone\Files\Inventory.txt";

                Dictionary<string, Food> foodDictionary = VendingMachine.Stock(filePath);

                //instantiate a user that has a Balance property
                User currentUser = new User();

                //promt the user
                VendingMachine.DisplayPromptToUser();

                //capture users response
                userInput = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (userInput)
                {
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

                    case "2":
                        {
                            while (userInput != "3")
                            {
                                //PURCHASE SCREEN
                                Console.WriteLine("(1) Feed Money");
                                Console.WriteLine("(2) Select Product");
                                Console.WriteLine("(3) Finish Transaction");
                                Console.WriteLine($"Current Money Provided: ${currentUser.Balance}\n");

                                string purchaseScreenInput = Console.ReadLine();
                                Console.WriteLine();

                                //allow user to FEED MONEY to their balance
                                VendingMachine.FeedMoney(currentUser, purchaseScreenInput);

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
                                        VendingMachine.ValidateUserInput(foodDictionary, currentUser, userSelection);
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

                                    Console.WriteLine($"Here's your change: {numberOfQuarters} Quarter(s), {numberOfDimes} Dime(s), and {numberOfNickels} Nickel(s)");

                                    break;
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}

