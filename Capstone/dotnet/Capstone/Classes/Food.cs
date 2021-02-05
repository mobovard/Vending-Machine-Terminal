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

        public Food(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = 5;
        }

        public abstract string DispenseMessage();


    }
}
