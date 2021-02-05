using System;
using System.IO;
using System.Collections.Generic;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
<<<<<<< HEAD
        {
            //use filePath to create a dictionary<slot, Food>
            string filePath = @"C:\Users\Student\workspace\module1-capstone-c-team-4\Example Files\Inventory.txt";
            Dictionary<string, Food> foodDictionary = VendingMachine.Stock(filePath);
=======
        {         
            string userInput = "";
>>>>>>> 6a19437ecf8970e1d154f6f47cc7e6357bc68361

            while (userInput != "3")
            {
                //use filePath to create a dictionary<slot, Food>
                string filePath = @"C:\Users\Student\workspace\TestCapstone\dont_push-module1-capstone-c-team-4\Capstone\dotnet\Capstone\Files\Inventory.txt";

<<<<<<< HEAD
            string userInput = "";

            while (userInput != "3")
            {
                //prompt the user
                VendingMachine.DisplayPromptToUser();

                //capture user response
                userInput = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        {
                            while (userInput != "e")
                            {
                                Console.Clear();
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
                            while (userInput != "e")
                            {
                                //PURCHASE SCREEN
                                Console.WriteLine("(1) Feed Money");
                                Console.WriteLine("(2) Select Product");
                                Console.WriteLine("(3) Finish Transaction");
                                Console.WriteLine($"Current Money Provided: {currentUser.Balance}\n");

                                string purchaseScreenInput = Console.ReadLine();
                                Console.WriteLine();

                                //FEED MONEY
                                if (purchaseScreenInput == "1")
                                {
                                    Console.Clear();
                                    //user can add money to their balance
                                    Console.Write("Please add a whole dollar amount to your balance: ");
                                    decimal currentBalance = currentUser.Balance += Convert.ToDecimal(Console.ReadLine());
                                    Console.Clear();
                                }

                                //SELECT PRODUCT
                                while (purchaseScreenInput == "2")
                                {
                                    //Display items to user
                                    Console.Clear();
                                    VendingMachine.DisplayItems(foodDictionary);
                                    Console.WriteLine();

                                    //prompt user to select an item
                                    Console.Write("Please enter the slot code of the item you want: ");
                                    string userSelection = Console.ReadLine();

=======
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

                                //FEED MONEY
                                if (purchaseScreenInput == "1")
                                {
                                    Console.Clear();

                                    //user can add money to their balance
                                    Console.Write("Please add a whole dollar amount to your balance: ");
                                    decimal currentBalance = currentUser.Balance += Convert.ToDecimal(Console.ReadLine());

                                    //Allow user to exit and return to purchase prompt
                                    Console.Clear();
                                }

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

>>>>>>> 6a19437ecf8970e1d154f6f47cc7e6357bc68361
                                    //check that the user selection is in the vending machine
                                    if (foodDictionary.ContainsKey(userSelection))
                                    {
                                        //loop through foodDictionary 
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
                                                    currentUser.Balance -= food.Price;
                                                    food.Quantity--;

                                                    Console.Clear();
                                                    Console.WriteLine($"{food.DispenseMessage()} Enjoy your snack, you have ${currentUser.Balance} remaining.\n");


                                                }

                                            }
<<<<<<< HEAD

                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Sorry, item not found...\n");
                                        break;
                                    }
                                    break;
                                }

                                // FINISH TRANSACTION
                                while (purchaseScreenInput == "3")
                                {
                                    decimal balance = currentUser.Balance;
                                    string balanceString = balance.ToString("0.00");
                                    balance = Convert.ToDecimal(balanceString);
                                    balance *= 100;

                                    int numberOfQuarters = 0;
                                    int numberOfDimes = 0;
                                    int numberOfNickels = 0;

                                    while (balance > 25)
                                    {
                                        numberOfQuarters++;
                                        balance -= 25;
=======

                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Sorry, item not found...\n");
                                        break;
>>>>>>> 6a19437ecf8970e1d154f6f47cc7e6357bc68361
                                    }
                                    while (balance > 10)
                                    {
                                        numberOfDimes++;
                                        balance -= 10;
                                    }
                                    while (balance > 0)
                                    {
                                        numberOfNickels++;
                                        balance -= 5;
                                    }

                                    Console.Clear();
                                    currentUser.Balance = balance;
                                    Console.WriteLine($"Here is your change, you have {numberOfQuarters} quarters, {numberOfDimes} dimes and {numberOfNickels} nickels");
                                    userInput = "3";
                                    break;

                                    break;
                                }
<<<<<<< HEAD

                            }

                            break;
=======
                                //FINISH TRANSACTION
                                while (purchaseScreenInput == "3")
                                {
                                    decimal balance = currentUser.Balance;
                                    string balanceString = balance.ToString("0.00");
                                    balance = Convert.ToDecimal(balanceString);

                                    //Make balance a whole number
                                    balance *= 100;
>>>>>>> 6a19437ecf8970e1d154f6f47cc7e6357bc68361

                                    double numberOfQuarters = 0;
                                    double numberOfDimes = 0;
                                    double numberOfNickels = 0;

                                    while (balance > 25)
                                    {
                                        balance -= 25;
                                        numberOfQuarters++;
                                    }

<<<<<<< HEAD

                }
=======
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
>>>>>>> 6a19437ecf8970e1d154f6f47cc7e6357bc68361

                                    userInput = "3";
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

