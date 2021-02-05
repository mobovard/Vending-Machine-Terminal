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
            string filePath = @"C:\Users\Student\workspace\TestCapstone\dont_push-module1-capstone-c-team-4\Capstone\dotnet\Capstone\Files\Inventory.txt";
            Dictionary<string, Food> foodDictionary = VendingMachine.Stock(filePath);

            //instantiate a user that has a Balance property
            User currentUser = new User();

            //promt the user
            prompt: VendingMachine.DisplayPromptToUser();

            //capture users response
            string userInput = Console.ReadLine();
            Console.WriteLine();



            switch (userInput)
            {
                case "1":
                    {
                        //Display vending machine items
                        VendingMachine.DisplayItems(foodDictionary);
                        Console.WriteLine();
                        //Allow user to exit and return to main prompt
                        //TODO maybe refactor with a while loop and call VendingMachine.DisplayPromptToUser()
                        pressE: Console.Write("Press e to exit: ");
                        var exit = Console.ReadLine();

                        if (exit == "e")
                        {
                            Console.Clear();
                            goto prompt;
                        }
                        else
                        {
                            goto pressE;
                        }

                    }

                case "2":
                    {
                        //PURCHASE SCREEN
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine($"Current Money Provided: {currentUser.Balance}\n");

                        string twoInput = Console.ReadLine();
                        Console.WriteLine();

                        //FEED MONEY
                        if (twoInput == "1")
                        {
                            //user can add money to their balance
                            Console.Write("Please add a whole dollar amount to your balance: ");
                            double currentBalance = currentUser.Balance += Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"Your current balance is now: {currentBalance}\n");

                            //Allow user to exit and return to purchase prompt
                            pressE: Console.Write("Press e to exit: ");
                            var exit = Console.ReadLine();

                            if (exit == "e")
                            {
                                Console.Clear();
                                goto case "2";
                            }
                            else
                            {
                                goto pressE;
                            }

                        }
                        //SELECT PRODUCT
                        else if (twoInput == "2")
                        {
                            //Display items to user
                            Console.Clear();
                            VendingMachine.DisplayItems(foodDictionary);
                            Console.WriteLine();

                            //prompt user to select an item
                            Console.Write("Please enter the slot code of the item you want: ");
                            string userSelection = Console.ReadLine();

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
                                            goto case "2";
                                        }
                                        //check the user's balance, make sure they have enough money
                                        else if (currentUser.Balance < Convert.ToDouble(food.Price))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Sorry, insufficient funds...\n");
                                            goto case "2";
                                        }
                                        //if there's inventory and the user has enough money,
                                        //subtract the cost from their balance
                                        //decrement the inventory
                                        //and dispense the item 
                                        else
                                        {
                                            currentUser.Balance -= Convert.ToDouble(food.Price);
                                            food.Quantity--;

                                            Console.Clear();
                                            Console.WriteLine($"{food.DispenseMessage()} Enjoy your snack, you have ${currentUser.Balance} remaining.\n");
                                            goto prompt;

                                        }

                                    }

                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Sorry, item not found...\n");
                                goto case "2";
                            }

                        }
                        //FINISH TRANSACTION
                        else if (twoInput == "3")
                        {

                        }

                        break;
                    }




            }
        }
    }
}
