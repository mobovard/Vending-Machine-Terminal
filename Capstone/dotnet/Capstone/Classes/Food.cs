using Capstone.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    abstract public class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int NumberOfTimesPurchased { get; set; }

        public Food(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 5;
            this.NumberOfTimesPurchased = 0;
        }

        public abstract string DispenseMessage();

        public abstract void TimesPurchased();
    }
}
